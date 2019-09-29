using System;
using System.Collections.Generic;
using System.Text;

namespace Predictor.Core.Interfaces
{
    public interface ILicensePlateRule
    {
        string GetCase(string licensePlateIdentifier);
    }
}
