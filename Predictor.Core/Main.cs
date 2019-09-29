using Predictor.Core.Interfaces;
using Predictor.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Predictor.Core
{
    public class Main : IHeartbeat
    {
        public bool IsAlive()
        {
            return true;
        }

        public DrivingQueryResult CanDrive(DrivingQueryInfo info, IRestrictionScheduler restrictionScheduler)
        {
            List<Restriction> restrictions = restrictionScheduler.GetRestrictions();

            Debug.Print(info.LicensePlateIdentifier);
            Debug.Print(info.QueryDate);
            Debug.Print(info.QueryTime);

            var date = DateTime.Parse(info.QueryDate).Date;
            var time = DateTime.Parse(info.QueryTime).TimeOfDay;
            string caseID = restrictionScheduler.GetLicensePlateRule().GetCase(info.LicensePlateIdentifier);

            Debug.Print(date.DayOfWeek.ToString());

            bool canDrive = true;
            foreach (var r in restrictions)
            {
                if (date.DayOfWeek == r.DayOfWeek && r.Cases.Contains(caseID))
                {
                    if (time <= r.HourRange.EndTime && time >= r.HourRange.StartTime)
                    {
                        canDrive = false;
                        return new DrivingQueryResult(canDrive);
                    }
                }
            }

            return new DrivingQueryResult(canDrive);
        }
    }
}
