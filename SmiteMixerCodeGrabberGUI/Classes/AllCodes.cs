﻿using System;
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

        public static void AddCodeToCodeList(string code, bool isActive)
        {
            if (isActive)
            {
                Console.WriteLine("\t[{0}] Added Active code: " + code + " to the code list.", DateTime.Now);
                _AllCodes.Add(new SmiteCode(code));
            }
            else
            {
                Console.WriteLine("\t[{0}] Added Expried code: " + code + " to the code list.", DateTime.Now);
                _AllCodes.Add(new SmiteCode(code, isActive));
            }
        }

        public static void AddCodeToCodeListDebug(string code, bool isActive, DateTime CreationTime)
        {
            if (isActive)
            {
                Console.WriteLine("\t[{0}] Added Active code: " + code + " to the code list.", DateTime.Now);
                _AllCodes.Add(new SmiteCode(code, true, CreationTime));
            }
            else
            {
                Console.WriteLine("\t[{0}] Added Expried code: " + code + " to the code list.", DateTime.Now);
                _AllCodes.Add(new SmiteCode(code, isActive));
            }
        }

        public static void RemoveCodeFromList(string code)
        {
            Console.WriteLine("Removed code: " + code + " from the code list.");
            _AllCodes.Remove(_AllCodes.Where(x => x.GetCode() == code).First());
        }

        public static List<SmiteCode> GetActiveCodes()
        {
            return _AllCodes.Where(x => x.GetIsActive() == true).ToList();
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
