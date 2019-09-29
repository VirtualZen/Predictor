using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor.Entities
{
    public class DrivingQueryResult
    {
        public DrivingQueryResult(bool canDrive)
        {
            CanDrive = CanDrive;
        }

        public DrivingQueryResult() : this(false)
        {
        }

        public bool CanDrive { get; }
    }
}
