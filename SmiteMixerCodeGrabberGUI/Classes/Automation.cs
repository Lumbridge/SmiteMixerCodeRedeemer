using System;
using System.Linq;
using System.Text;
using System.Threading; 
using System.Threading.Tasks;
using System.Collections.Generic;

using MixerChat;
using MixerChat.Classes;

using DolphinScript.Lib.Backend;
using DolphinScript.Lib.ScriptEventClasses;

using SmiteMixerListener.Classes;
using static SmiteMixerListener.Classes.Common;
using static SmiteMixerCodeGrabberGUI.Classes.AllCodes;
using static DolphinScript.Lib.Backend.Common;

using static SmiteMixerCodeGrabberGUI.Classes.DynamicResolution;

namespace SmiteMixerCodeGrabberGUI.Classes
{
    class Automation
    {
        public static void RedeemSingle(SmiteCode sc)
        {
            // get the event list and pass it the code we want it to type
            //
            var loop = GetRedeemLoop(sc.GetCode());

            foreach (var ev in loop)
                if(IsRunning)
                    ev.DoEvent();

            if(IsRunning)
                sc.SetIsRedeemed(true);
        }

        public static void RedeemAllActive()
        {
            foreach (var code in GetActiveCodes())
            {
                if (code.GetIsRedeemed() == false)
                {
                    // get the event list and pass it the code we want it to type
                    //
                    var loop = GetRedeemLoop(code.GetCode());

                    foreach (var ev in loop)
                        if(IsRunning)
                            ev.DoEvent();

                    if(IsRunning)
                        code.SetIsRedeemed(true);
                }
            }
        }
    }
}
