using System;

namespace Lambda_Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            Alarm alarm = new Alarm(70,x=>Console.WriteLine($"現在溫度為{x}度，已通知消防隊"));
            alarm.ChangeTemperature(69);
            alarm.ChangeTemperature(70);
            alarm.ChangeTemperature(71);
            alarm.ChangeTemperature(15);
            alarm.ChangeTemperature(105);
            alarm.ChangeFireHardHandler(x => Console.WriteLine("失火啦！"));
            alarm.ChangeTemperature(69);
            alarm.ChangeTemperature(70);
            alarm.ChangeTemperature(71);
            alarm.ChangeTemperature(15);
            alarm.ChangeTemperature(105);
            Console.ReadKey();
        }
    }
}
