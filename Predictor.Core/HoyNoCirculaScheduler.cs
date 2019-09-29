using Predictor.Core.Interfaces;
using Predictor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor.Core
{
    public class HoyNoCirculaScheduler : SchedulerBase, IRestrictionScheduler
    {
        // TODO should be configurable, for now restrictions in constructor (hideous)
        public HoyNoCirculaScheduler() : base()
        {
            HourRange allDay = new HourRange("05:00", "20:00");

            var ranges = new List<HourRange>() { allDay };
            SetDay(DayOfWeek.Monday, new List<string>() { "1", "2" }, ranges);
            SetDay(DayOfWeek.Tuesday, new List<string>() { "3", "4" }, ranges);
            SetDay(DayOfWeek.Wednesday, new List<string>() { "5", "6" }, ranges);
            SetDay(DayOfWeek.Thursday, new List<string>() { "7", "8" }, ranges);
            SetDay(DayOfWeek.Friday, new List<string>() { "9", "0" }, ranges);
        }
        public ILicensePlateRule GetLicensePlateRule()
        {
            return new LastDigitLicensePlateRule();
        }
    }
}
