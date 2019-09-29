using Predictor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor.Core.Interfaces
{
    public interface IRestrictionScheduler
    {
        List<Restriction> GetRestrictions();
        ILicensePlateRule GetLicensePlateRule();
    }
}
