using Accord.Statistics.Models.Regression.Linear;
using BacteriaRegressionLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BacteriaRegressionLibrary.BusinessLogic.Regression
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
                FormulaUsed = regression.ToString().Replace("y(x)", "y").Replace("x", " * x"),
                PredictionOnTestSet = testX.Select(regression.Transform).ToArray(),
                PredictionOnTrainingSet = trainX.Select(regression.Transform).ToArray()
            };
        }
    }
}
