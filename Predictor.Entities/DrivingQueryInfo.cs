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

        public bool isValidEntity()
        {
            if (Validator.isNullEmptyWhiteSpace(LicensePlateIdentifier)) return false;
            if (Validator.isNullEmptyWhiteSpace(QueryDate)) return false;
            if (Validator.isNullEmptyWhiteSpace(QueryTime)) return false;

            return true;
        }

        public bool isValidLicensePlate()
        {
            // TODO all license plate cases, this case has private cars only, not diplomatic or others
            return Validator.isValidExpression(LicensePlateIdentifier, @"^[GPAWSBUIQCLYXRJMKOVTENZ][A-Z]{2}[\-][0-9]{3,4}$");
        }
        public bool isValidDate()
        {
            // TODO set date format via app configuration, now using OS default parsing
            DateTime result;
            bool b = DateTime.TryParse(QueryDate, out result);

            Debug.Print($"QueryDate:[{QueryDate}]:=[{QueryDate}], Could Parse := [{b}]");
            //Validator.isValidExpression(QueryDate, @"^[0-9]?[0-9][/][0-9]?[0-9][/][0-9][0-9][0-9][0-9]$")
            return b;
        }

        public bool isValidTime()
        {
            // TODO define if other formats allowed, for now hh:mm
            return Validator.isValidExpression(QueryTime, @"^[0-9]{1,2}[:][0-9][0-9]$");
        }

        public string QueryDate { get; }
        public string QueryTime { get; }
    }
}
