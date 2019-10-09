﻿using Accord.Statistics.Kernels;
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
            PredictableBacteriaDetector.Detect(500, 99);
            Console.ReadLine();

            var bacteria = BacteriaImporter.Import(5);

            //foreach (var bacterium in bacteria)
            //{
            //    Console.WriteLine(bacterium);
            //}

            Regression reg = new Regression()
            {
                TrainSizePercentage = 85
            };

            //reg.RegressionModel = new LinearRegression();
            //PrintResult("Linear", reg.PerformRegression(bacteria.ElementAt(1)));
            //Console.ReadLine();

            var bacterium = bacteria.ElementAt(0);
            for (var i = 1; i < 15; i++)
            {
                reg.RegressionModel = new PolynomialRegression(i);
                PrintResult($"Poly{i}", bacterium, reg.PerformRegression(bacterium));
                Console.ReadLine();
            }
        }

        static void PrintResult(string title, Bacterium bacterium, RegressionResult result)
        {
            double matchSum = 0;
            Console.WriteLine("\n");
            Console.WriteLine($"{title} on {bacterium.ASV}. Used {result.FormulaUsed}");
            for (var i = 0; i < result.TestTimestamp.Length; i++)
            {
                var match = GetMatch(result.TestMeasurements[i], result.PredictionOnTestSet[i]);
                Console.WriteLine(String.Format("Timestamp {0} is {1:0.00} and predicted {2:0.00}. Prediction is {3:0.0000}% of actual value",
                    result.TestTimestamp[i],
                    result.TestMeasurements[i],
                    result.PredictionOnTestSet[i],
                    match
                ));
                matchSum += match;
            }
            var matchAverage = matchSum / result.TestTimestamp.Length;
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
