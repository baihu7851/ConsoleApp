using System;

namespace Lambda_Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            Alarm alarm = new Alarm(25,x=>Console.WriteLine($"溫度超過上限{x}度"));
            alarm.ChangeTemperature(99);
            alarm.ChangeTemperature(15);
            alarm.ChangeTemperature(105);
            Console.WriteLine("切換方式");
            alarm.ChangeFireHardHandler(x => Console.WriteLine("失火啦！"));
            alarm.ChangeTemperature(99);
            alarm.ChangeTemperature(15);
            alarm.ChangeTemperature(105);
            Console.ReadKey();
        }
    }
}
