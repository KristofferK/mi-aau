using BacteriaRegression.BusinessLogic;
using BacteriaRegression.BusinessLogic.Regression;
using System;
using System.Linq;

namespace BacteriaRegression
{
    class Program
    {
        static void Main(string[] args)
        {
            var bacteria = BacteriaImporter.Import(5);
            foreach (var bacterium in bacteria)
            {
                Console.WriteLine(bacterium);
            }

            Regression regression = new Regression(null);
            var regressionResult = regression.PerformRegression(bacteria.ElementAt(0));
            Console.WriteLine("Used " + regressionResult.FormulaUsed);
            for (var i = 0; i < regressionResult.TestTimestamp.Length; i++)
            {
                Console.WriteLine($"Timestamp {regressionResult.TestTimestamp[i]} is {regressionResult.TestMeasurements[i]} and predicted {regressionResult.PredictedMeasurements[i]}");
            }
        }
    }
}
