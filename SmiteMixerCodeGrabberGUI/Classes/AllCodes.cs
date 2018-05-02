using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmiteMixerCodeGrabberGUI.Classes.Common;

namespace SmiteMixerCodeGrabberGUI.Classes
{
    public static class AllCodes
    {
        static List<SmiteCode> _AllCodes;

        static AllCodes()
        {
            _AllCodes = new List<SmiteCode>();
        }

        public static void AddCodeToCodeList(string code, bool isActive)
        {
            if (isActive)
            {
                Console.WriteLine("Added Active code: " + code + " to the code list.");
                _AllCodes.Add(new SmiteCode(code));
                if (Properties.Settings.Default.notificationSound)
                    PlayNotificationSound();
                if (Properties.Settings.Default.notificationSetting)
                    DisplayNotification("New potential code added to active codes: \n" + code);
            }
            else
            {
                Console.WriteLine("Added Expried code: " + code + " to the code list.");
                _AllCodes.Add(new SmiteCode(code, isActive));
            }
        }

        public static void AddCodeToCodeListDebug(string code, bool isActive, DateTime CreationTime)
        {
            if (isActive)
            {
                Console.WriteLine("Added Active code: " + code + " to the code list.");
                _AllCodes.Add(new SmiteCode(code, true, CreationTime));
                Globals.shouldUpdateActiveList = true;
            }
            else
            {
                Console.WriteLine("Added Expried code: " + code + " to the code list.");
                _AllCodes.Add(new SmiteCode(code, isActive));
            }
        }

        public static void RemoveCodeFromList(string code)
        {
            Console.WriteLine("Removed code: " + code + " from the code list.");
            _AllCodes.Remove(_AllCodes.Where(x => x.GetCode() == code).First());
        }

        public static List<SmiteCode> GetAllCodes()
        {
            return _AllCodes;
        }

        public static List<SmiteCode> GetActiveCodes()
        {
            return _AllCodes.Where(x => x.GetIsActive() == true).ToList();
        }

        public static List<SmiteCode> GetActiveCodesPastRedeemTimer()
        {
            return _AllCodes.Where(x => x.GetIsActive() == true && x.Time_RedeemingAt <= DateTime.Now).ToList();
        }

        public static List<SmiteCode> GetExpiredCodes()
        {
            return _AllCodes.Where(x => x.GetIsActive() == false).ToList();
        }

        public static void ClearActiveCodes()
        {
            foreach(var code in GetActiveCodes())
            {
                if (code.GetIsActive() == true)
                    RemoveCodeFromList(code.GetCode());
            }
        }

        public static void ClearExpiredCodes()
        {
            foreach (var code in GetExpiredCodes())
            {
                if (code.GetIsActive() == false)
                    RemoveCodeFromList(code.GetCode());
            }
        }
    }
}
