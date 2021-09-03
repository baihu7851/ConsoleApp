using System;

namespace Lambda_Expression
{
    /// <summary>
    /// 溫度警報器
    /// </summary>
    internal class Alarm
    {
        /// <summary>
        /// 警報器初始化
        /// </summary>
        /// <param name="alarmTemperature">報警溫度</param>
        /// <param name="fireHardHandler">報警動作</param>
        public Alarm(int alarmTemperature, Action<int> fireHardHandler)
        {
            this._alarmTemperature = alarmTemperature;
            this._currentTemperature = alarmTemperature;
            this._fireHardHandler = fireHardHandler;
        }

        private int _currentTemperature;
        private readonly int _alarmTemperature;
        private Action<int> _fireHardHandler;

        /// <summary>
        /// 是否超過溫度
        /// </summary>
        public bool IsOverheat => _currentTemperature >= _alarmTemperature;

        /// <summary>
        /// 變更報警動作
        /// </summary>
        /// <param name="fireHardHandler">報警動作</param>
        public void ChangeHandler(Action<int> fireHardHandler)
        {
            _fireHardHandler = fireHardHandler;
            Console.WriteLine("ChangeOK");
        }

        /// <summary>
        /// 溫度偵測
        /// </summary>
        /// <param name="temperature">目前溫度</param>
        public void ChangeTemperature(int temperature)
        {
            _currentTemperature = temperature;
            if (IsOverheat && _fireHardHandler != null)
            {
                _fireHardHandler(temperature);
            }
            else
            {
                Console.WriteLine("溫度正常");
            }
        }
    }
}