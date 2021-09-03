using System;
using System.Linq;

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
            for (var i = 0; i <= source.Length - pattern.Length; i++)
            {
                matched = true;
                for (var j = 0; j < pattern.Length; j++)
                {
                    if (source[i + j] != pattern[j])
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
            for (var i = 0; i < source.Length;)
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