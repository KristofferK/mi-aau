using BacteriaRegression.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BacteriaRegression.BusinessLogic.Regression
{
    public class Regression
    {
        public IRegressionModel RegressionModel { get; set; }
        public int TrainSizePercentage { get; set; } = 80;

        public Regression(IRegressionModel regressionModel)
        {
            RegressionModel = regressionModel;
        }

        public RegressionResult PerformRegression(Bacterium bacterium)
        {
            var trainSize = (int)(bacterium.Measurements.Count() / 100.0 * TrainSizePercentage);
            var trainMeasurements = bacterium.Measurements.Take(trainSize).ToArray();
            var testMeasurements = bacterium.Measurements.Skip(trainSize).ToArray();

            var trainX = Enumerable.Range(0, trainSize).Select(e => (double)e).ToArray();
            var testX = Enumerable.Range(trainSize, testMeasurements.Length).Select(e => (double)e).ToArray();

            var result = RegressionModel.PerformRegression(trainX, trainMeasurements, testX, testMeasurements);

            result.TrainMeasurements = trainMeasurements;
            result.TrainTimestamp = trainX;
            result.TestMeasurements = testMeasurements;
            result.TestTimestamp = testX;

            return result;
        }
    }
}
