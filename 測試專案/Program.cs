using System;
using System.Linq.Expressions;

namespace 測試專案
{
    internal class Program
    {
        private static void Main()
        {
            OtherDel namedMethod = Add20;
            OtherDel anonymousMethod = delegate (int x)
            {
                return x + 20;
            };

            Expression<Func<int, int, int>> exp = (x, y) => x + y + 1;
            var func = exp.Compile();
            func.Invoke(3, 2);
            OtherDel anonmousMethod2 = (int x) => x + 20;

            OtherDel lambda = x => x + 20;
            Console.WriteLine($"具名方法：{namedMethod(1)}");
            Console.WriteLine($"具名方法：{namedMethod(2)}");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"匿名方法：{anonymousMethod(3)}");
            Console.WriteLine($"匿名方法：{anonymousMethod(4)}");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Lambda：{lambda(5)}");
            Console.WriteLine($"Lambda：{lambda(6)}");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"講解：{anonmousMethod2(5)}");
            Console.WriteLine($"講解：{anonmousMethod2(6)}");
            Console.ReadKey();
        }

        public static int Add20(int x)
        {
            return x + 20;
        }

        private delegate int OtherDel(int InParam);
    }
}