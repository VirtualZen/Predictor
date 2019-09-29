using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor.Entities
{
    public class HourRange
    {
        public HourRange(string startTime, string endTime)
        {
            StartTime = GetTime(startTime);
            EndTime = GetTime(endTime);
        }

        public TimeSpan StartTime { get; }
        public TimeSpan EndTime { get; }

        private TimeSpan GetTime(string startTime)
        {
            var time = startTime.Split(':');
            return new TimeSpan(Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), 0);
        }
    }
}
