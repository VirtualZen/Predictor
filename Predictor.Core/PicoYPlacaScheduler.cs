using Predictor.Core.Interfaces;
using Predictor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor.Core
{
    public class PicoYPlacaScheduler : IRestrictionScheduler
    {
        // TODO model restrictions so random scheduler is possible
        public List<Restriction> Restrictions { get; }

        // TODO should be configurable, for now restrictions in constructor (hideous)
        public PicoYPlacaScheduler()
        {
            Restrictions = new List<Restriction>();

            SetDay(DayOfWeek.Monday, new List<string>() {"1","2"});
            SetDay(DayOfWeek.Tuesday, new List<string>() { "3", "4" });
            SetDay(DayOfWeek.Wednesday, new List<string>() { "5","6"});
            SetDay(DayOfWeek.Thursday, new List<string>() { "7", "8" });
            SetDay(DayOfWeek.Friday, new List<string>() { "9", "0" });
        }

        private void SetDay(DayOfWeek dayOfWeek, List<string> cases)
        {
            HourRange morning = new HourRange("07:00", "09:30");
            HourRange evening = new HourRange("16:00", "19:30");
            Restrictions.Add(new Restriction(dayOfWeek, morning, cases));
            Restrictions.Add(new Restriction(dayOfWeek, evening, cases));
        }

        public ILicensePlateRule GetLicensePlateRule()
        {
            return new LastDigitLicensePlateRule();
        }

        public List<Restriction> GetRestrictions()
        {
            return Restrictions;
        }
    }
}
