using Accord.Math;
using BacteriaRegressionLibrary.Models;
using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BacteriaRegressionLibrary.BusinessLogic
{
    public static class BacteriaMerger
    {
        public static MergedBacteria MergeBacteria(Bacterium b1, Bacterium b2)
        {
            var merged = new MergedBacteria()
            {
                Bacterium1 = b1,
                Bacterium2 = b2
            };

            merged.Points = new List<Tuple<double, double>>();
            for (var i = 0; i < b1.Measurements.Count; i++)
            {
                merged.Points.Add(new Tuple<double, double>(b1.Measurements[i], b2.Measurements[i]));
            }

            merged.CosineDistance = 1 - Distance.Cosine(b1.Measurements.ToArray(), b2.Measurements.ToArray());
            merged.SpearmanCorrelation = Correlation.Spearman(b1.Measurements, b2.Measurements);
            merged.PearsonCorrelation = Correlation.Pearson(b1.Measurements, b2.Measurements);

            return merged;
        }
    }
}
