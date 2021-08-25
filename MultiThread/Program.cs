using System;
using System.Threading;

namespace MultiThread
{
    class Program
    {
        static int Conter = 0;
        static readonly object Obj = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(x => GetTicked("T1"));
            Thread t2 = new Thread(x => GetTicked("T2"));
            Thread t3 = new Thread(x => GetTicked("T3"));
            t1.Start();
            t2.Start();
            t3.Start();
            Console.ReadKey();
        }

        static void GetTicked(string tickedNo)
        {
            for (int i = 0; i < 1000; i++)
            {
                lock (Obj)
                {
                    int ticked = Conter + 1;
                    Console.WriteLine($"{tickedNo}:{ticked}");
                    Conter = ticked;
                }
            }
        }
    }
}
