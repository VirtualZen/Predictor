using Predictor.Core.Interfaces;
using System;

namespace Predictor.Core
{
    public class Main : IHeartbeat
    {
        public bool IsAlive()
        {
            return true;
        }
    }
}
