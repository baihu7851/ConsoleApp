using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingLot
    {
        /// <summary>
        /// 幾分鐘內免費
        /// </summary>
        const int FreeTime = 5;
        /// <summary>
        /// 基礎費率
        /// </summary>
        const int BaseMoney = 60;
        /// <summary>
        /// 基礎時間 
        /// </summary>
        const int BaseTime = 60;
        /// <summary>
        /// 增長時間
        /// </summary>
        const double additionalTime = 30;
        /// <summary>
        /// 增長費率
        /// </summary>
        const int additionalMoney = 30;

        /// <summary>
        /// 建造停車場
        /// </summary>
        /// <param name="carport">停車格數量</param>
        public ParkingLot(int carport)
        {
            Carport = carport;
            Cars = new List<Car>();
        }
        /// <summary>
        /// 已停車列表
        /// </summary>
        private List<Car> Cars;
        /// <summary>
        /// 停車格數量
        /// </summary>
        private int Carport { get; set; }
        /// <summary>
        /// 進入停車場
        /// </summary>
        /// <param name="licensePlate">車牌號碼</param>
        /// <returns>是否成功進入</returns>
        public bool Entity(string licensePlate)
        {
            if (Cars.Count >= Carport) return false;
            Cars.Add(new Car(licensePlate));
            return true;
        }

        private int GetCarCount()
        {
            return Cars.Count;
        }
        /// <summary>
        /// 尋找停車場內車輛
        /// </summary>
        /// <param name="licensePlate">車牌號碼</param>
        /// <returns>車輛資訊或Null</returns>
        public Car FindCar(string licensePlate)
        {
            return Cars.Find(x => x.LicensePlate == licensePlate);
        }
        /// <summary>
        /// 離開停車場
        /// </summary>
        /// <param name="car">離開車輛</param>
        /// <returns></returns>
        public int Exit(Car car)
        {
            if (car == null)
            {
                return -1;
            }
            car.LeaveTime = DateTime.Now;
            Cars.Remove(car);
            return ParkingFeeLogic(car.EnterTime, car.LeaveTime);
        }
        /// <summary>
        /// 離開測試
        /// </summary>
        /// <param name="car">離開車輛</param>
        /// <param name="minut">增加分鐘數</param>
        /// <returns></returns>
        public int Exit(Car car, int minut)
        {
            if (car == null)
            {
                return -1;
            }
            car.LeaveTime = DateTime.Now.AddMinutes(minut);
            Cars.Remove(car);
            return ParkingFeeLogic(car.EnterTime, car.LeaveTime);
        }

        /// <summary>
        /// 停車費計算
        /// </summary>
        /// <param name="enterTime">進入時間</param>
        /// <param name="leaveTime">離開時間</param>
        /// <returns></returns>
        private int ParkingFeeLogic(DateTime enterTime, DateTime leaveTime)
        {
            int minute = (int)leaveTime.Subtract(enterTime).TotalMinutes;
            if (minute <= FreeTime) return 0;
            if (minute <= BaseTime) return BaseMoney;
            return (int)Math.Ceiling((minute - BaseTime) / additionalTime) * additionalMoney + BaseMoney;
        }
    }
}
