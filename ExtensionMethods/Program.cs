using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("test String".Index("String"));
            Console.WriteLine("test baihu.String?".WordCount("!?,. "));
            Console.ReadKey();
        }
        public static int Index(this string source, string pattern)
        {
            bool matched;
            for (int i = 0; i <= source.Length-pattern.Length; i++)
            {
                matched = true;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (source[i+j]!=pattern[j])
                    {
                        matched = false;
                        break;
                    }
                }
                if (matched)
                {
                    return i;
                }
            }
            return -1;
        }
        public static int WordCount(this string source, string delimiter)
        {
            int resoult = 0;
            for (int i = 0; i < source.Length;)
            {
                while (i < source.Length && delimiter.Contains(source[i])) i++;
                if (i >= source.Length) break;
                while (i < source.Length && !delimiter.Contains(source[i])) i++;
                resoult++;
            }
            return resoult;
        }
    }
}
