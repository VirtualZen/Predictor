using Predictor.Core.Interfaces;
using Predictor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor.Core
{
    public class HoyNoCirculaScheduler : IRestrictionScheduler
    {
        public ILicensePlateRule GetLicensePlateRule()
        {
            throw new NotImplementedException();
        }

        public List<Restriction> GetRestrictions()
        {
            throw new NotImplementedException();
        }
    }
}
