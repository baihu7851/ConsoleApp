using System;

namespace Lambda_Expression
{
    class Alarm
    {
        public Alarm(int alarmTemperature,Action<int> fireHardHandler)
        {
            this.AlarmTemperature = alarmTemperature;
            this.CurrentTemperature = alarmTemperature;
            FireHardHandler = fireHardHandler;
        }
        int CurrentTemperature;
        int AlarmTemperature;
        Action<int> FireHardHandler;

        public bool IsOverheat { get { return CurrentTemperature >= AlarmTemperature; } }
        public void ChangeFireHardHandler(Action<int> fireHardHandler)
        {
            FireHardHandler = fireHardHandler;
            Console.WriteLine("ChangeOK");
        }
        public void ChangeTemperature(int temperature)
        {
            this.CurrentTemperature = temperature;
            if (IsOverheat && FireHardHandler!=null)
            {
                FireHardHandler(temperature);
            }
            else
            {
                Console.WriteLine("溫度正常");
            }
        }
    }
}
