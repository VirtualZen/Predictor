using Predictor.Core.Interfaces;
using Predictor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor.Core
{
    public class PicoYPlacaScheduler : SchedulerBase, IRestrictionScheduler
    {

        // TODO should be configurable, for now restrictions in constructor (hideous)
        public PicoYPlacaScheduler() : base()
        {
            HourRange morning = new HourRange("07:00", "09:30");
            HourRange evening = new HourRange("16:00", "19:30");

            var ranges = new List<HourRange>() { morning, evening };
            SetDay(DayOfWeek.Monday, new List<string>() {"1","2"}, ranges);
            SetDay(DayOfWeek.Tuesday, new List<string>() { "3", "4" }, ranges);
            SetDay(DayOfWeek.Wednesday, new List<string>() { "5","6"}, ranges);
            SetDay(DayOfWeek.Thursday, new List<string>() { "7", "8" }, ranges);
            SetDay(DayOfWeek.Friday, new List<string>() { "9", "0" }, ranges);
        }

        public ILicensePlateRule GetLicensePlateRule()
        {
            return new LastDigitLicensePlateRule();
        }
    }
}
