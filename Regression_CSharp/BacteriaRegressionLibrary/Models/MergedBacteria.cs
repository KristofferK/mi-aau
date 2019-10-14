using System;
using System.Collections.Generic;
using System.Text;

namespace BacteriaRegressionLibrary.Models
{
    public class MergedBacteria
    {
        public Bacterium Bacterium1 { get; set; }
        public Bacterium Bacterium2 { get; set; }
        public List<Tuple<double, double>> Points { get; set; }
        public double CosineDistance { get; set; }
        public double SpearmanCorrelation { get; set; }
        public double PearsonCorrelation { get; set; }

        public override string ToString()
        {
            return $"{Bacterium1.ASV} vs {Bacterium2.ASV}";
        }
    }
}
