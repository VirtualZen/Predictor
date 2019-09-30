using Microsoft.VisualStudio.TestTools.UnitTesting;
using Predictor.Core;
using Predictor.Core.Scheduler;
using Predictor.Entities;

namespace Predictor.Test
{
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void MainIsAliveTest()
        {
            Assert.IsTrue(new Main().IsAlive());
        }
        [TestMethod]
        public void CanIDrive_Positive_PicoPlaca_Weekday()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/3/2019", "09:15"), new PicoYPlacaScheduler());
            Assert.IsTrue(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Negative_PicoPlaca_Weekday_OtherCar()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4831", "6/3/2019", "09:15"), new PicoYPlacaScheduler());
            Assert.IsFalse(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Positive_PicoPlaca_Restrictedday_Early()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "06:59"), new PicoYPlacaScheduler());
            Assert.IsTrue(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Negative_PicoPlaca_Restrictedday_StartMorning()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "07:00"), new PicoYPlacaScheduler());
            Assert.IsFalse(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Negative_PicoPlaca_Restrictedday()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "09:15"), new PicoYPlacaScheduler());
            Assert.IsFalse(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Negative_PicoPlaca_Restrictedday_EndMorning()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "09:30"), new PicoYPlacaScheduler());
            Assert.IsFalse(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Positive_PicoPlaca_Restrictedday_Morning()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "09:31"), new PicoYPlacaScheduler());
            Assert.IsTrue(result.CanDrive);
        }

        // HERE
        [TestMethod]
        public void CanIDrive_Positive_PicoPlaca_Restrictedday_BeforeAfternoon()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "15:59"), new PicoYPlacaScheduler());
            Assert.IsTrue(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Negative_PicoPlaca_Restrictedday_StartAfternoon()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "16:00"), new PicoYPlacaScheduler());
            Assert.IsFalse(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Negative_PicoPlaca_RestrictedAfternoon()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "17:15"), new PicoYPlacaScheduler());
            Assert.IsFalse(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Negative_PicoPlaca_Restrictedday_EndAfternoon()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "19:30"), new PicoYPlacaScheduler());
            Assert.IsFalse(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Positive_PicoPlaca_Restrictedday_Evening()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "19:31"), new PicoYPlacaScheduler());
            Assert.IsTrue(result.CanDrive);
        }
        // HERE
        [TestMethod]
        public void CanIDrive_Positive_PicoPlaca_Weekend()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/2/2019", "8:30"), new PicoYPlacaScheduler());
            Assert.IsTrue(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Positive_HoyNoCircula_Weekend()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "9/29/2019", "06:59"), new HoyNoCirculaScheduler());
            Assert.IsTrue(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Positive_HoyNoCircula_GoodDay()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "9/30/2019", "06:59"), new HoyNoCirculaScheduler());
            Assert.IsTrue(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Positive_HoyNoCircula_BadDay_Early()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "10/01/2019", "4:59"), new HoyNoCirculaScheduler());
            Assert.IsTrue(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Negative_HoyNoCircula_BadDay_StartMorning()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "10/01/2019", "05:00"), new HoyNoCirculaScheduler());
            Assert.IsFalse(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Negative_HoyNoCircula_BadDay_Morning()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "10/01/2019", "06:59"), new HoyNoCirculaScheduler());
            Assert.IsFalse(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Negative_HoyNoCircula_BadDay_Afternoon()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "10/01/2019", "19:59"), new HoyNoCirculaScheduler());
            Assert.IsFalse(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Positive_HoyNoCircula_BadDay_Evening()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "10/01/2019", "20:01"), new HoyNoCirculaScheduler());
            Assert.IsTrue(result.CanDrive);
        }
    }
}
