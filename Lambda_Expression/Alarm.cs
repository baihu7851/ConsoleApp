using System;

namespace Lambda_Expression
{
    /// <summary>
    /// 溫度警報器
    /// </summary>
    class Alarm
    {
        /// <summary>
        /// 警報器初始化
        /// </summary>
        /// <param name="alarmTemperature">報警溫度</param>
        /// <param name="fireHardHandler">報警動作</param>
        public Alarm(int alarmTemperature,Action<int> fireHardHandler)
        {
            this.AlarmTemperature = alarmTemperature;
            this.CurrentTemperature = alarmTemperature;
            this.FireHardHandler = fireHardHandler;
        }
        int CurrentTemperature;
        int AlarmTemperature;
        Action<int> FireHardHandler;
        /// <summary>
        /// 是否超過溫度
        /// </summary>
        public bool IsOverheat { get { return CurrentTemperature >= AlarmTemperature; } }
        /// <summary>
        /// 變更報警動作
        /// </summary>
        /// <param name="fireHardHandler">報警動作</param>
        public void ChangeFireHardHandler(Action<int> fireHardHandler)
        {
            FireHardHandler = fireHardHandler;
            Console.WriteLine("ChangeOK");
        }
        /// <summary>
        /// 溫度偵測
        /// </summary>
        /// <param name="temperature">目前溫度</param>
        public void ChangeTemperature(int temperature)
        {
            CurrentTemperature = temperature;
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
