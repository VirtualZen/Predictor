using Predictor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor.Core
{
    public class Core : IHeartbeat
    {
        public bool IsAlive()
        {
            return true;
        }
    }
}
