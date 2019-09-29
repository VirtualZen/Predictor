using Microsoft.VisualStudio.TestTools.UnitTesting;
using Predictor.Core;
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
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/3/2019", "09:15"));
            Assert.IsTrue(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Positive_PicoPlaca_Restrictedday_Early()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "06:59"));
            Assert.IsTrue(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Negative_PicoPlaca_Restrictedday_StartMorning()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "07:00"));
            Assert.IsFalse(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Negative_PicoPlaca_Restrictedday()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "09:15"));
            Assert.IsFalse(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Negative_PicoPlaca_Restrictedday_EndMorning()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "09:30"));
            Assert.IsFalse(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Positive_PicoPlaca_Restrictedday_Morning()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "09:31"));
            Assert.IsTrue(result.CanDrive);
        }

        // HERE
        [TestMethod]
        public void CanIDrive_Positive_PicoPlaca_Restrictedday_BeforeAfternoon()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "15:59"));
            Assert.IsTrue(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Negative_PicoPlaca_Restrictedday_StartAfternoon()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "16:00"));
            Assert.IsFalse(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Negative_PicoPlaca_RestrictedAfternoon()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "17:15"));
            Assert.IsFalse(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Negative_PicoPlaca_Restrictedday_EndAfternoon()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "19:30"));
            Assert.IsFalse(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Positive_PicoPlaca_Restrictedday_Evening()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/4/2019", "19:31"));
            Assert.IsTrue(result.CanDrive);
        }
        // HERE
        [TestMethod]
        public void CanIDrive_Positive_PicoPlaca_Weekend()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "6/2/2019", "8:30"));
            Assert.IsTrue(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Positive_HoyNoCircula_Weekend()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "9/29/2019", "06:59"));
            Assert.IsTrue(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Positive_HoyNoCircula_GoodDay()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "9/30/2019", "06:59"));
            Assert.IsTrue(result.CanDrive);
        }
        [TestMethod]
        public void CanIDrive_Positive_HoyNoCircula_BadDay()
        {
            var result = new Main().CanDrive(new DrivingQueryInfo("PCR-4834", "10/01/2019", "06:59"));
            Assert.IsTrue(result.CanDrive);
        }
    }
}
