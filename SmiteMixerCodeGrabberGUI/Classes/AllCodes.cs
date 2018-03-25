using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmiteMixerCodeGrabberGUI.Classes
{
    public static class AllCodes
    {
        static List<SmiteCode> _AllCodes;

        static AllCodes()
        {
            _AllCodes = new List<SmiteCode>();
        }

        public static void AddCodeToCodeList(string code)
        {
            Console.WriteLine("\tAdded code: " + code + " to code list.");
            _AllCodes.Add(new SmiteCode(code));
        }

        public static void RemoveCodeFromList(string code)
        {
            Console.WriteLine("Removed code: " + code + " from redeem queue.");
            _AllCodes.Remove(_AllCodes.Where(x=>x.GetCode() == code).First());
        }

        public static List<SmiteCode> GetActiveCodes()
        {
            return _AllCodes.Where(x => x.GetIsActive() == true).ToList();
        }

        public static List<SmiteCode> GetExpiredCodes()
        {
            return _AllCodes.Where(x => x.GetIsActive() == false).ToList();
        }
    }
}
