using Accord.Math.Optimization.Losses;
using BacteriaRegressionLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BacteriaRegressionLibrary.BusinessLogic.Regression
{
    public class Regression
    {
        public IRegressionModel RegressionModel { get; set; }
        public double TrainSizePercentage { get; set; } = 80;

        public Regression()
        {

        }

        public Regression(IRegressionModel regressionModel)
        {
            RegressionModel = regressionModel;
        }

        public RegressionResult PerformRegression(MergedBacteria bacteria)
        {
            var trainSize = (int)(bacteria.Bacterium1.Measurements.Count() / 100.0 * TrainSizePercentage);
            var trainX = bacteria.Bacterium1.Measurements.Take(trainSize).ToArray();
            var testX = bacteria.Bacterium1.Measurements.Skip(trainSize).ToArray();

            var trainY = bacteria.Bacterium2.Measurements.Take(trainSize).ToArray();
            var testY = bacteria.Bacterium2.Measurements.Skip(trainSize).ToArray();

            var result = RegressionModel.PerformRegression(trainX, trainY, testX, testY);

            result.TrainX = trainX;
            result.TrainY = trainY;
            result.TestX = testX;
            result.TestY = testY;
            result.Error = new SquareLoss(trainX).Loss(result.PredictionOnTrainingSet);
            return result;
        }
    }
}
