using BacteriaRegression.BusinessLogic;
using BacteriaRegression.BusinessLogic.Regression;
using BacteriaRegression.Models;
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

            Regression reg;

            reg = new Regression(new LinearRegression());
            PrintResult("Linear", reg.PerformRegression(bacteria.ElementAt(1)));

            for (var i = 2; i < 15; i++)
            {
                reg = new Regression(new PolynomialRegression(i));
                PrintResult($"Poly{i}", reg.PerformRegression(bacteria.ElementAt(1)));
                Console.ReadLine();
            }
        }

        static void PrintResult(string title, RegressionResult result)
        {
            Console.WriteLine("\n");
            Console.WriteLine(title + ". Used " + result.FormulaUsed);
            for (var i = 0; i < result.TestTimestamp.Length; i++)
            {
                Console.WriteLine($"Timestamp {result.TestTimestamp[i]} is {result.TestMeasurements[i]} and predicted {result.PredictedMeasurements[i]}");
            }
        }
    }
}
