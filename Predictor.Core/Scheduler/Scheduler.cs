using Predictor.Core.Interfaces;
using Predictor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor.Core.Scheduler
{
    public class Scheduler
    {
        private IDictionary<string,IRestrictionScheduler> _schedulerStorage;

        public Scheduler()
        {
            _schedulerStorage = new Dictionary<string, IRestrictionScheduler>();


            // TODO get from configuration, and sort keys
            _schedulerStorage.Add("9/9/2019", new HoyNoCirculaScheduler());
            _schedulerStorage.Add("3/1/2010", new PicoYPlacaScheduler());
            _schedulerStorage.Add("1/1/1900", new NullScheduler()); 
        }
        public IRestrictionScheduler GetScheduler(string date)
        {
            var array = new string[_schedulerStorage.Keys.Count];
            _schedulerStorage.Keys.CopyTo(array,0);

            var searchDate = DateTime.Parse(date).Date;

            // TODO make it work even if keys not sorted in reverse order
            foreach (string key in _schedulerStorage.Keys)
            {
                if (DateTime.Compare(searchDate, DateTime.Parse(key).Date) >= 0)
                {
                    return _schedulerStorage[key];
                }
            }
            return new NullScheduler();
        }
    }
}
