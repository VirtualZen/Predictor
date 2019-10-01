using Predictor.Core;
using Predictor.Core.Scheduler;
using Predictor.Entities;
using System;
using System.Diagnostics;

namespace PredictorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Print($"Arguments: {args.Length}");
            if (args.Length != 3)
            {
                Console.WriteLine("Please enter license plate, date and time!");
                Console.WriteLine("Usage example: PredictorConsole PCR-4834 9/29/2019 9:00");
                Exit(-1);
            }
            var licensePlate = args[0];
            var date = args[1];
            var time = args[2];

            var query = new DrivingQueryInfo(licensePlate, date, time);
            var validResult = query.IsValidEntity();
            if (!validResult.valid)
            {
                foreach (var fieldResult in validResult.fieldResults)
                {
                    Console.WriteLine($"{fieldResult}");
                }
                Exit(-2);
            }

            var result = new Main().CanDrive(query, new Scheduler().GetScheduler(date));

            if (result.CanDrive)
            {
                Console.WriteLine($"You can Drive!");
            }
            else
            {
                Console.WriteLine($"You can't Drive!");
            }
            Exit(0);
        }

        private static void Exit(int exitCode)
        {
            Console.WriteLine($"Press<ENTER> to exit");
            Console.ReadLine();
            System.Environment.Exit(exitCode);
        }
    }
}
