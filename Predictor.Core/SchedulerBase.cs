using Predictor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor.Core
{
    public abstract class SchedulerBase
    {
        // TODO model restrictions so random scheduler is possible
        public SchedulerBase()
        {
            Restrictions = new List<Restriction>();
        }
        public List<Restriction> Restrictions { get; }
        protected void SetDay(DayOfWeek dayOfWeek, List<string> cases, List<HourRange> ranges)
        {
            foreach (var range in ranges)
            {
                Restrictions.Add(new Restriction(dayOfWeek, range, cases));
            }
        }
        public List<Restriction> GetRestrictions()
        {
            return Restrictions;
        }
    }
}
