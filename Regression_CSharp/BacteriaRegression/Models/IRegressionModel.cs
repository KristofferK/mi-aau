using System;
using System.Collections.Generic;
using System.Text;

namespace BacteriaRegression.Models
{
    public interface IRegressionModel
    {
        RegressionResult PerformRegression(double[] trainX, double[] trainY, double[] testX, double[] testY);
    }
}
