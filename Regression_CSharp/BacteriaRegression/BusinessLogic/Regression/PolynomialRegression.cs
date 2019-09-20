using Accord.Statistics.Models.Regression.Linear;
using BacteriaRegression.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BacteriaRegression.BusinessLogic.Regression
{
    class PolynomialRegression : IRegressionModel
    {
        public int Degree { get; set; }

        public PolynomialRegression(int degree)
        {
            Degree = degree;
        }

        public RegressionResult PerformRegression(double[] trainX, double[] trainY, double[] testX, double[] testY)
        {
            var ls = new PolynomialLeastSquares()
            {
                Degree = Degree
            };
            Accord.Statistics.Models.Regression.Linear.PolynomialRegression regression = ls.Learn(trainX, trainY);

            return new RegressionResult
            {
                FormulaUsed = regression.ToString("N1"),
                PredictionOnTestSet = testX.Select(regression.Transform).ToArray(),
                PredictionOnTrainingSet = trainX.Select(regression.Transform).ToArray()
            };
        }
    }
}
