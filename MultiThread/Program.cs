using System;
using System.Threading;

namespace MultiThread
{
    internal class Program
    {
        private static int _conter;
        private static readonly object Obj = new object();

        private static void Main()
        {
            Thread t1 = new Thread(x => GetTicked("T1"));
            Thread t2 = new Thread(x => GetTicked("T2"));
            Thread t3 = new Thread(x => GetTicked("T3"));
            t1.Start();
            t2.Start();
            t3.Start();
            Console.ReadKey();
        }

        private static void GetTicked(string tickedNo)
        {
            for (var i = 0; i < 1000; i++)
            {
                lock (Obj)
                {
                    int ticked = _conter + 1;
                    Console.WriteLine($"{tickedNo}:{ticked}");
                    _conter = ticked;
                }
            }
        }
    }
}