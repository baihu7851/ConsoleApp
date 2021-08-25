using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Car
    {
        public Car(string licensePlate)
        {
            LicensePlate = licensePlate;
            EnterTime = DateTime.Now;
        }
        /// <summary>
        /// 車牌號碼
        /// </summary>
        public string LicensePlate { get; set; }
        /// <summary>
        /// 進入時間
        /// </summary>
        public DateTime EnterTime { get; set; }
        /// <summary>
        /// 離開時間
        /// </summary>
        public DateTime LeaveTime { get; set; }
        /// <summary>
        /// 複寫ToString()
        /// </summary>
        /// <returns>傳出車牌及進入離開時間</returns>
        public override string ToString()
        {
            return $"車牌：{LicensePlate}\n進入時間：{EnterTime.ToString("t")}，離開時間：{LeaveTime.ToString("t")}";
        }
    }
}
