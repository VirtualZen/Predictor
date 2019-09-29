using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Predictor.Entities
{
    public class DrivingQueryInfo
    {
        public DrivingQueryInfo(string licensePlateIdentifier, string queryDate, string queryTime)
        {
            LicensePlateIdentifier = licensePlateIdentifier;
            QueryDate = queryDate;
            QueryTime = queryTime;
        }
        public string LicensePlateIdentifier { get; }

        public (bool valid, List<string> fieldResults) IsValidEntity()
        {
            bool isValid = true;
            var fieldResults = new List<string>();

            isValid = isValid && Validator.isValidField("LicensePlateIdentifier", LicensePlateIdentifier, @"^[GPAWSBUIQCLYXRJMKOVTENZ][A-Z]{2}[\-][0-9]{3,4}$", fieldResults);
            isValid = isValid && Validator.isValidDate("QueryDate", QueryDate,fieldResults);
            isValid = isValid && Validator.isValidField("QueryTime", QueryTime, @"^[0-9]{1,2}[:][0-9][0-9]$",fieldResults);

            return (isValid, fieldResults);
        }
        public string QueryDate { get; }
        public string QueryTime { get; }
    }
}
