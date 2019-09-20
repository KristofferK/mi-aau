using System;
using System.Collections.Generic;
using System.Text;

namespace BacteriaRegression.Models
{
    public class RegressionResult
    {
        public string FormulaUsed { get; set; }
        public double[] TrainMeasurements { get; set; }
        public double[] TestMeasurements { get; set; }
        public double[] TrainTimestamp { get; internal set; }
        public double[] TestTimestamp { get; internal set; }
        public double[] PredictedMeasurements { get; set; }
    }
}
