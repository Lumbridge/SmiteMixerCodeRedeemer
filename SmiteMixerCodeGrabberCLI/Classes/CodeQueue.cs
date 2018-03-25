using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmiteMixerListener.Classes
{
    static class CodeQueue
    {
        static List<string> _CodeQueue;

        static CodeQueue()
        {
            _CodeQueue = new List<string>();
        }

        public static void AddCodeToQueue(string code)
        {
            Console.WriteLine("Added code: " + code + " to redeem queue.");
            _CodeQueue.Add(code);
        }

        public static List<string> GetCodeQueue()
        {
            return _CodeQueue;
        }

        public static void RemoveCodeFromQueue(string code)
        {
            Console.WriteLine("Removed code: " + code + " from redeem queue.");
            _CodeQueue.Remove(code);
        }
    }
}
