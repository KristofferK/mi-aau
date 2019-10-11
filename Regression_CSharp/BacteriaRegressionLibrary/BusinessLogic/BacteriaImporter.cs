using BacteriaRegressionLibrary.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace BacteriaRegressionLibrary.BusinessLogic
{
    public static class BacteriaImporter
    {
        private const string PATH = "Data\\damhusaen_normalized.csv";

        public static List<Bacterium> Import(int bacteriaCount)
        {
            return File.ReadAllLines(PATH)
                .Skip(1)
                .Take(bacteriaCount)
                .Select(row => row.Split(','))
                .Select(columns => new Bacterium
                {
                    ASV = columns[0],
                    Genus = columns[1].Split('_').Last(),
                    Class = columns[2].Split('_').Last(),
                    Measurements = columns.Skip(3).Select(measurement => double.Parse(measurement, new NumberFormatInfo
                    {
                        NumberDecimalSeparator = "."
                    })).ToList()
                })
                .ToList();
        }
    }
}
