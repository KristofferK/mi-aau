using BacteriaRegressionLibrary.BusinessLogic;
using BacteriaRegressionLibrary.BusinessLogic.Regression;
using BacteriaRegressionLibrary.Models;
using System;
using System.Linq;

namespace BacteriaRegressionLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var bacteria = BacteriaImporter.Import(25);

            /*for (var i = 0; i < bacteria.Count; i++)
            {
                var cosineDistance = 1 - Distance.Cosine(bacteria[0].Measurements.ToArray(), bacteria[i].Measurements.ToArray());
                if (cosineDistance > 0.9) Console.ForegroundColor = ConsoleColor.Green;
                else if (cosineDistance < 0.8) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(string.Format("{0,6} ift {1,6}: {2:0.00000}", bacteria[0].ASV, bacteria[i].ASV, cosineDistance));
            }*/

            foreach (var bacterium in bacteria)
            {
                Console.WriteLine("Found " + bacterium.ASV);
            }
        }

        static void PrintResult(string title, Bacterium bacterium, RegressionResult result)
        {
            double matchSum = 0;
            Console.WriteLine("\n");
            Console.WriteLine($"{title} on {bacterium.ASV}. Used {result.FormulaUsed}");
            for (var i = 0; i < result.TestY.Length; i++)
            {
                var match = GetMatch(result.TestX[i], result.PredictionOnTestSet[i]);
                Console.WriteLine(String.Format("Timestamp {0} is {1:0.00} and predicted {2:0.00}. Prediction is {3:0.0000}% of actual value",
                    result.TestY[i],
                    result.TestX[i],
                    result.PredictionOnTestSet[i],
                    match
                ));
                matchSum += match;
            }
            var matchAverage = matchSum / result.TestY.Length;
            Console.WriteLine($"Error on training set: {result.Error}");
            Console.WriteLine($"Average match on test set (closer to 100 is better): {Math.Round(matchAverage, 4)}");
        }

        static double GetMatch(double actualValue, double predictedValue)
        {
            return (predictedValue / actualValue) * 100;
        }

        static double GetDeviation(double actualValue, double predictedValue)
        {
            var val = (predictedValue - actualValue) / actualValue * 100;
            if (double.IsInfinity(val))
            {
                return 0;
            }
            return val;
        }
    }
}
