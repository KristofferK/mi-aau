using System;
using System.Collections.Generic;
using System.Text;

namespace BacteriaRegressionLibrary.Models
{
    public class RegressionResult
    {
        public string FormulaUsed { get; set; }
        public double[] TrainMeasurements { get; set; }
        public double[] TestMeasurements { get; set; }
        public double[] TrainTimestamp { get; set; }
        public double[] TestTimestamp { get; set; }
        public double[] PredictionOnTestSet { get; set; }
        public double Error { get; set; }
        public double[] PredictionOnTrainingSet { get; internal set; }
    }
}
