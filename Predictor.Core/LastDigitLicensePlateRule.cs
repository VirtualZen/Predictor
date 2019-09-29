using Predictor.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Predictor.Core
{
    class LastDigitLicensePlateRule : ILicensePlateRule
    {
        public string GetCase(string licensePlateIdentifier)
        {
            return licensePlateIdentifier.Substring(licensePlateIdentifier.Length - 1);
        }
    }
}
