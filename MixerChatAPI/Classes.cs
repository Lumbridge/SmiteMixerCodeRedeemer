using System;
using System.Collections.Generic;

namespace MixerChat.Classes
{
    public class ErrorEventArgs : EventArgs
    {
        public Exception Exception { get; private set; }
        public ErrorEventArgs(Exception ex)
        {
            this.Exception = ex;
        }
    }

    public class ChatMessageEventArgs : EventArgs
    {
        public String Message { get; private set; }
        public String User { get; private set; }
        public ChatMessageEventArgs(String User, String Message )
        {
            this.Message = Message;
            this.User = User;
        }
    }

    public class UserEventArgs : EventArgs
    {
        public String User { get; private set; }
        public UserEventArgs(String User)
        {
            this.User = User;
        }
    }

    internal class Channel
    {
        public int id { get; set; }
    }

    internal class Chats
    {
        public List<string> roles { get; set; }
        public string authkey { get; set; }
        public List<string> permissions { get; set; }
        public List<string> endpoints { get; set; }
    }

    internal class Message
    {
        public List<Message2> message { get; set; }
    }

    internal class Message2
    {
        public string type { get; set; }
        public string data { get; set; }
        public string text { get; set; }
    }

    internal class Data
    {
        public string user_name { get; set; }
        public Message message { get; set; }
        public string username { get; set; }
    }

    internal class HeartBeat
    {
        public string type { get; set; }
        public string method { get; set; }
        public List<object> arguments { get; set; }
        public long id { get; set; }
        public HeartBeat(long id)
        {
            type = "method";
            method = "ping";
            arguments = new List<object>();
            this.id = id;
        }
    }

    internal class ChatEvents
    {
        public string type { get; set; }
        public string @event { get; set; }
        public Data data { get; set; }
        public long id { get; set; }
    }

    internal class Auth
    {
        public string type { get; set; }
        public string method { get; set; }
        public List<int?> arguments { get; set; }
        public int id { get; set; }
        public Auth(int id)
        {
            type = "method";
            method = "auth";
            arguments = new List<int?>() { id, null, null };
            id = 0;
        }
    }
}
