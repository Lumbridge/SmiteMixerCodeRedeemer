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
                Console.WriteLine("[{0}] {1}", DateTime.Now, msg);
            else
                Console.WriteLine("{0}", msg);
        }
    }
}
