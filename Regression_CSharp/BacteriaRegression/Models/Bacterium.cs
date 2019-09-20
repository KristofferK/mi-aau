using System;
using System.Collections.Generic;
using System.Text;

namespace BacteriaRegression.Models
{
    public class Bacterium
    {
        public string ASV { get; set; }
        public string Genus { get; set; }
        public string Class { get; set; }
        public List<double> Measurements { get; set; }

        public override string ToString()
        {
            return $"{ASV} ({Genus} of class {Class})";
        }
    }
}
