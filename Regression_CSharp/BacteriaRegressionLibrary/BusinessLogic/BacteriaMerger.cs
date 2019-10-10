using BacteriaRegressionLibrary.Models;
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

            return merged;
        }
    }
}
