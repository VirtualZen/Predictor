using Predictor.Core.Interfaces;
using Predictor.Core.LicensePlateRule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor.Core.Scheduler
{
    public class NullScheduler : SchedulerBase, IRestrictionScheduler
    {
        // TODO should be configurable, for now restrictions in constructor (hideous)
        public NullScheduler() : base()
        {
        }
        public ILicensePlateRule GetLicensePlateRule()
        {
            return new LastDigitLicensePlateRule();
        }
    }
}
