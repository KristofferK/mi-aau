using System;
using System.Collections.Generic;
using System.Text;

namespace BacteriaRegressionLibrary.Models
{
    public class RegressionResult
    {
        public string FormulaUsed { get; set; }
        public double[] TrainX { get; set; }
        public double[] TestX { get; set; }
        public double[] TrainY { get; set; }
        public double[] TestY { get; set; }
        public double[] PredictionOnTestSet { get; set; }
        public double Error { get; set; }
        public double[] PredictionOnTrainingSet { get; internal set; }
    }
}
