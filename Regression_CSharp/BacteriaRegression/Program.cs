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

            Regression reg = new Regression()
            {
                TrainSizePercentage = 85
            };

            reg.RegressionModel = new LinearRegression();
            PrintResult("Linear", reg.PerformRegression(bacteria.ElementAt(1)));
            Console.ReadLine();

            for (var i = 2; i < 15; i++)
            {
                reg.RegressionModel = new PolynomialRegression(i);
                PrintResult($"Poly{i}", reg.PerformRegression(bacteria.ElementAt(1)));
                Console.ReadLine();
            }
        }

        static void PrintResult(string title, RegressionResult result)
        {
            Console.WriteLine("\n");
            Console.WriteLine($"{title}. Used {result.FormulaUsed}");
            for (var i = 0; i < result.TestTimestamp.Length; i++)
            {
                var off = GetDeviation(result.TestMeasurements[i], result.PredictionOnTestSet[i]);
                Console.WriteLine($"Timestamp {result.TestTimestamp[i]} is {result.TestMeasurements[i]} "
                    + $"and predicted {result.PredictionOnTestSet[i]}. That is {off}% off.");
            }
            Console.WriteLine($"Error on training set: {result.Error}");
        }

        static double GetDeviation(double actualValue, double predictedValue)
        {
            return (predictedValue - actualValue) / actualValue * 100;
        }
    }
}
