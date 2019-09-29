using Predictor.Core.Interfaces;
using Predictor.Entities;
using System;

namespace Predictor.Core
{
    public class Main : IHeartbeat
    {
        public bool IsAlive()
        {
            return true;
        }

        public DrivingQueryResult CanDrive(DrivingQueryInfo info)
        {
            var r = new DrivingQueryResult(true);
            return r;
        }
    }
}
