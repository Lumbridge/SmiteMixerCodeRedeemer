using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmiteMixerListener.Classes
{
    class Common
    {
        /// <summary>
        /// Returns a substring between two sub-parts of the string
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string GetSubstringBetweenStrings(string a, string b, string c)
        {
            try { return c.Substring((c.IndexOf(a) + a.Length), (c.IndexOf(b) - c.IndexOf(a) - a.Length)); }
            catch { Console.WriteLine("ERROR CREATING SUBSTRING"); return "ERROR CREATING SUBSTRING"; }
        }
    }
}
