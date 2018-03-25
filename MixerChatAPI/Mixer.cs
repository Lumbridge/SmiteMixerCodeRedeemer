using Newtonsoft.Json;
using System;
using System.Linq;
using WebSocket4Net;
using MixerChat.Classes;
using System.Net;
using System.Threading;
using System.IO;
using System.Timers;

namespace MixerChat
{
    public class Mixer
    {
        private WebSocket ws;
        public delegate void MessageUpdateHandler(ChatMessageEventArgs e);
        public delegate void UserEventHandler(UserEventArgs e);
        public delegate void MixerErrorHandler(Classes.ErrorEventArgs e);
        public event MixerErrorHandler OnError;
        public event MessageUpdateHandler OnMessageReceived;
        public event UserEventHandler OnUserJoined;
        public event UserEventHandler OnUserLeft;
        private string BaseUrl = "https://mixer.com/api/v1/";
        private Chats chats;
        private System.Timers.Timer timer = new System.Timers.Timer();
        private Channel channelId;
        private long heartbeatCount = 1;
        public bool Connect(String channel)
        {
            try
            {
                var res = Request(String.Format("{0}channels/{1}", BaseUrl, channel));
                if (!string.IsNullOrEmpty(res))
                {
                    channelId = JsonConvert.DeserializeObject<Channel>(res);
                    res = Request(String.Format("{0}chats/{1}", BaseUrl, channelId.id));
                    chats = JsonConvert.DeserializeObject<Chats>(res);
                    ws = new WebSocket(chats.endpoints.LastOrDefault());
                    ws.MessageReceived += Ws_MessageReceived;
                    ws.Closed += Ws_Closed;
                    ws.Error += Ws_Error;
                    ws.Open();
                    return true;
                } 
                else
                {
                    OnError?.Invoke(new Classes.ErrorEventArgs(new Exception("Mixer Api not responding")));
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke(new Classes.ErrorEventArgs(ex));
            }
            return false;
        }

        private void Ws_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            try
            {
                ChatEvents cEvent = JsonConvert.DeserializeObject<ChatEvents>(e.Message);
                if (!timer.Enabled)
                {
                    timer = new System.Timers.Timer(30000)
                    {
                        AutoReset = false
                    };
                    timer.Elapsed += (object obj, ElapsedEventArgs args) =>
                    {
                        ws.Close();
                    };
                    timer.Start();
                }
                else
                {
                    timer.Stop();
                    timer.Start();
                }
                if (cEvent.type == "event")
                {
                    switch (cEvent.@event)
                    {
                        case "ChatMessage":
                            string message = String.Join(" ", cEvent.data.message.message.Select(x => x.text.Trim()).ToArray());
                            OnMessageReceived?.Invoke(new ChatMessageEventArgs(cEvent.data.user_name, message));
                            break;
                        case "WelcomeEvent":
                            Console.WriteLine("\tConnected to channel, Listening for codes...\n" + 
                                "\tMake sure Smite is open & in windowed mode (1920x1080)!\n");
                            ws.Send(JsonConvert.SerializeObject(new Auth(channelId.id)));
                            break;
                        case "UserLeave":
                            OnUserLeft?.Invoke(new UserEventArgs(cEvent.data.username));
                            break;
                        case "UserJoin":
                            OnUserJoined?.Invoke(new UserEventArgs(cEvent.data.username));
                            break;
                        default:
                            //Console.WriteLine(String.Format("Event {0} not properly handled", cEvent.@event));
                            break;
                    }
                }
                else if (cEvent.type == "reply")
                {
                    new Thread(() =>
                    {
                        Thread.Sleep(5000);
                        if (ws.State == WebSocketState.Open)
                        {
                            ws.Send(JsonConvert.SerializeObject(new HeartBeat(heartbeatCount++)));
                        }
                    }).Start();
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke(new Classes.ErrorEventArgs(ex));
            }
        }

        private void Ws_Closed(object sender, EventArgs e)
        {
            Random rand = new Random();
            var endpoint = chats.endpoints.OrderBy(x => rand.Next()).LastOrDefault();
            ws = new WebSocket(endpoint);
            ws.MessageReceived += Ws_MessageReceived;
            ws.Closed += Ws_Closed;
            ws.Error += Ws_Error;
            ws.Open();
        }

        private void Ws_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            OnError?.Invoke(new Classes.ErrorEventArgs(e.Exception));
            Thread.Sleep(5000);
            ws.Close();
        }

        private String Request(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                return responseFromServer;
            }
            catch (Exception ex)
            {
                OnError(new Classes.ErrorEventArgs(ex));
            }
            return "";
        }
    }
}
