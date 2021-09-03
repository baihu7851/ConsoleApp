using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParkingLot.Tests
{
    [TestClass()]
    public class ParkingLotTests
    {
        [TestMethod()]
        public void ExitTest_OneHouse()
        {
            ParkingLot pk = new ParkingLot(50);
            pk.Entity("ABC");
            pk.Entity("AAA");
            var car = pk.FindCar("ABC");
            var rmoney = pk.Exit(car, 6);
            Assert.AreEqual(60, rmoney, "基礎費率算錯誤");
            var car2 = pk.FindCar("AAA");
            var rmoney2 = pk.Exit(car2, 91);
            Assert.AreEqual(120, rmoney2, "額計算錯誤");
            pk.Entity("BBB");
            var car3 = pk.FindCar("BBB");
            var rmoney3 = pk.Exit(car3, 3);
            Assert.AreEqual(0, rmoney3, "免費計算錯誤");
        }
    }
}