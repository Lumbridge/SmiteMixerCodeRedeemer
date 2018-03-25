using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmiteMixerListener.Classes
{
    public class Common
    {
        public static void Write(string msg, bool showDateTime)
        {
            if(showDateTime)
                Console.WriteLine("\t[{0}] {1}\n", DateTime.Now, msg);
            else
                Console.WriteLine("\t{0}\n", msg);
        }
    }
}
