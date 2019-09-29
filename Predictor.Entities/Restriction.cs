using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor.Entities
{
    public class Restriction
    {
        public Restriction(DayOfWeek dayOfWeek, string startTime, string endTime, List<string> cases) : this(dayOfWeek, new HourRange(startTime, endTime), cases)
        {
        }

        public Restriction(DayOfWeek dayOfWeek, HourRange hourRange, List<string> cases)
        {
            DayOfWeek = dayOfWeek;
            HourRange = hourRange;
            Cases = cases;
        }

        public DayOfWeek DayOfWeek { get; }
        public HourRange HourRange { get; }
        public IList<string> Cases { get; }
    }
}
