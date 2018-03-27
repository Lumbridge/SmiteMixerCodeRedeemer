using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmiteMixerCodeGrabberGUI.Classes
{
    public static class MetaInfo
    {
        public static string Version = "v0.9.9-Beta";

        public static string GetMetaInfoConsole()
        {
            return  "\n\tSmite Mixer Code Redeemer " + Version + " By github.com/Lumbridge.\n\n" +
                    "\tCredits to myself for Dolphin Script & SmiteMixerCodeGrabberCLI/GUI Projects,\n" +
                    "\tCredits to github.com/Breeser for the Mixer Chat API.\n\n";
        }

        public static string GetMetaInfoMessageBox()
        {
            return "Smite Mixer Code Redeemer " + Version + " By github.com/Lumbridge.\n\n" +
                    "Credits to myself for Dolphin Script & SmiteMixerCodeGrabberCLI/GUI Projects.\n\n" +
                    "Credits to github.com/Breeser for the Mixer Chat API.";
        }
    }
}
