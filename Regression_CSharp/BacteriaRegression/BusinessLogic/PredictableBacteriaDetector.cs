using BacteriaRegression.BusinessLogic.Regression;
using BacteriaRegression.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BacteriaRegression.BusinessLogic
{
    public class PredictableBacteriaDetector
    {
        public static void Detect(int importSize, double trainSizePercentage)
        {
            Console.WriteLine($"Running PredictableBacteriaDetector on importSize={importSize} and trainSizePercentage={trainSizePercentage}.");
            var bacteria = BacteriaImporter.Import(importSize);

            var reg = new Regression.Regression()
            {
                TrainSizePercentage = trainSizePercentage
            };

            foreach (var bacterium in bacteria)
            {
                for (var i = 1; i < 15; i++)
                {
                    reg.RegressionModel = new PolynomialRegression(i);
                    PrintResultIfGood($"Poly{i}", bacterium, reg.PerformRegression(bacterium));
                }
            }
        }

        private static void PrintResultIfGood(string title, Bacterium bacterium, RegressionResult result)
        {
            double matchSum = 0;
            for (var i = 0; i < result.TestTimestamp.Length; i++)
            {
                matchSum += GetMatch(result.TestMeasurements[i], result.PredictionOnTestSet[i]);
            }
            var matchAverage = matchSum / result.TestTimestamp.Length;
            if (matchAverage > 98.5 && matchAverage < 101.5)
            {
                Console.WriteLine($"Good match found on {bacterium.ASV} with the {title} model. Used {result.FormulaUsed}");
                Console.WriteLine($"Average match on test set (closer to 100 is better): {Math.Round(matchAverage, 4)}");
                Console.WriteLine("\n");
            }
        }

        static double GetMatch(double actualValue, double predictedValue)
        {
            return (predictedValue / actualValue) * 100;
        }
    }
}
