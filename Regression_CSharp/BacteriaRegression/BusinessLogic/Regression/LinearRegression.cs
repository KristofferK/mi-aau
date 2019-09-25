using Accord.Statistics.Models.Regression.Linear;
using BacteriaRegression.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BacteriaRegression.BusinessLogic.Regression
{
    public class LinearRegression : IRegressionModel
    {
        public RegressionResult PerformRegression(double[] trainX, double[] trainY, double[] testX, double[] testY)
        {
            OrdinaryLeastSquares ols = new OrdinaryLeastSquares();
            SimpleLinearRegression regression = ols.Learn(trainX, trainY);

            return new RegressionResult
            {
                FormulaUsed = regression.ToString(),
                PredictionOnTestSet = testX.Select(regression.Transform).ToArray(),
                PredictionOnTrainingSet = trainX.Select(regression.Transform).ToArray()
            };
        }
    }
}
