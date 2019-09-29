using Microsoft.VisualStudio.TestTools.UnitTesting;
using Predictor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor.Test
{
    [TestClass]
    public class EntitiesTest
    {
        [TestMethod]
        public void DrivingQueryInfoTest_Valid_All_Entity()
        {
            Assert.IsTrue(new DrivingQueryInfo("PCR-4834", "9/24/2018", "06:30").isValidEntity());
        }
        [TestMethod]
        public void DrivingQueryInfoTest_Valid_LicensePlate()
        {
            Assert.IsTrue(new DrivingQueryInfo("PCR-4834", "9/24/2018", "06:30").isValidLicensePlate());
        }
        [TestMethod]
        public void DrivingQueryInfoTest_Valid_Date()
        {
            Assert.IsTrue(new DrivingQueryInfo("PCR-4834", "9/24/2018", "06:30").isValidDate());
        }
        [TestMethod]
        public void DrivingQueryInfoTest_Valid_Time()
        {
            Assert.IsTrue(new DrivingQueryInfo("PCR-4834", "9/24/2018", "06:30").isValidTime());
        }
        [TestMethod]
        public void DrivingQueryInfoTest_Bad_LicensePlate_Province()
        {
            Assert.IsFalse(new DrivingQueryInfo("DCR-4834", "9/24/2018", "06:30").isValidLicensePlate());
        }

        [TestMethod]
        public void DrivingQueryInfoTest_Bad_LicensePlate_Letters()
        {
            Assert.IsFalse(new DrivingQueryInfo("PCRX-4834", "9/24/2018", "06:30").isValidLicensePlate());
        }

        [TestMethod]
        public void DrivingQueryInfoTest_Bad_LicensePlate_MoreDigits()
        {
            Assert.IsFalse(new DrivingQueryInfo("PCR-48345", "9/24/2018", "06:30").isValidLicensePlate());
        }

        [TestMethod]
        public void DrivingQueryInfoTest_Bad_LicensePlate_LessDigits()
        {
            Assert.IsFalse(new DrivingQueryInfo("PCR-48", "9/24/2018", "06:30").isValidLicensePlate());
        }

        [TestMethod]
        public void DrivingQueryInfoTest_Bad_LicensePlate_NoDash()
        {
            Assert.IsFalse(new DrivingQueryInfo("PCR4834", "9/24/2018", "06:30").isValidLicensePlate());
        }
        [TestMethod]
        public void DrivingQueryInfoTest_Bad_Date_Separator()
        {
            Assert.IsFalse(new DrivingQueryInfo("PCR-4834", "9-24-2018", "06:30").isValidDate());
        }
        [TestMethod]
        public void DrivingQueryInfoTest_Bad_Date_2Separator()
        {
            Assert.IsFalse(new DrivingQueryInfo("PCR-4834", "9//24/2018", "06:30").isValidDate());
        }

        [TestMethod]
        public void DrivingQueryInfoTest_Bad_Date_Order()
        {
            Assert.IsFalse(new DrivingQueryInfo("PCR-4834", "24/9/2018", "06:30").isValidDate());
        }
        [TestMethod]
        public void DrivingQueryInfoTest_Bad_Time_Hours()
        {
            Assert.IsFalse(new DrivingQueryInfo("PCR-4834", "24/9/2018", "006:30").isValidTime());
        }
        [TestMethod]
        public void DrivingQueryInfoTest_Bad_Time_Minutes()
        {
            Assert.IsFalse(new DrivingQueryInfo("PCR-4834", "24/9/2018", "06:3").isValidTime());
        }
        [TestMethod]
        public void DrivingQueryInfoTest_Bad_Time_NoColon()
        {
            Assert.IsFalse(new DrivingQueryInfo("PCR-4834", "24/9/2018", "0630").isValidTime());
        }
        [TestMethod]
        public void DrivingQueryInfoTest_Bad_Time_Empty()
        {
            Assert.IsFalse(new DrivingQueryInfo("PCR-4834", "24/9/2018", "").isValidTime());
        }
        [TestMethod]
        public void DrivingQueryInfoTest_Bad_Time_MissingHours()
        {
            Assert.IsFalse(new DrivingQueryInfo("PCR-4834", "24/9/2018", ":30").isValidTime());
        }
        [TestMethod]
        public void DrivingQueryInfoTest_Bad_Time_MissingMinutes()
        {
            Assert.IsFalse(new DrivingQueryInfo("PCR-4834", "24/9/2018", "06:").isValidTime());
        }
    }
}
