using Microsoft.VisualStudio.TestTools.UnitTesting;
using Predictor.Core.Scheduler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor.Test
{
    [TestClass]
    public class SchedulerTest
    {
        [TestMethod]
        public void CanIDrive_SchedulerSelector_Null_Date()
        {
            var s = new Scheduler().GetScheduler("1/1/1");
            Assert.IsTrue(s.GetType().Name == "NullScheduler");
        }
        [TestMethod]
        public void CanIDrive_SchedulerSelector_Null_BeforeStart()
        {
            var s = new Scheduler().GetScheduler("12/31/1899");
            Assert.IsTrue(s.GetType().Name == "NullScheduler");
        }
        [TestMethod]
        public void CanIDrive_SchedulerSelector_Null_Start()
        {
            var s = new Scheduler().GetScheduler("1/1/1900");
            Assert.IsTrue(s.GetType().Name == "NullScheduler");
        }
        [TestMethod]
        public void CanIDrive_SchedulerSelector_Null_End()
        {
            var s = new Scheduler().GetScheduler("2/28/2010");
            Assert.IsTrue(s.GetType().Name == "NullScheduler");
        }
        [TestMethod]
        public void CanIDrive_SchedulerSelector_PicoYPlaca_Start()
        {
            var s = new Scheduler().GetScheduler("3/1/2010");
            Assert.IsTrue(s.GetType().Name == "PicoYPlacaScheduler");
        }
        [TestMethod]
        public void CanIDrive_SchedulerSelector_PicoYPlaca_End()
        {
            var s = new Scheduler().GetScheduler("9/8/2019");
            Assert.IsTrue(s.GetType().Name == "PicoYPlacaScheduler");
        }
        [TestMethod]
        public void CanIDrive_SchedulerSelector_HoyNoCircula_Start()
        {
            var s = new Scheduler().GetScheduler("9/9/2019");
            Assert.IsTrue(s.GetType().Name == "HoyNoCirculaScheduler");
        }
        [TestMethod]
        public void CanIDrive_SchedulerSelector_HoyNoCircula_End()
        {
            var s = new Scheduler().GetScheduler("12/31/2021");
            Assert.IsTrue(s.GetType().Name == "HoyNoCirculaScheduler");
        }
    }
}
