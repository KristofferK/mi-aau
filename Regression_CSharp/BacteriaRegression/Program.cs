using BacteriaRegression.BusinessLogic;
using System;

namespace BacteriaRegression
{
    class Program
    {
        static void Main(string[] args)
        {
            var bacteria = BacteriaImporter.Import(5);
            foreach (var bacterium in bacteria)
            {
                Console.WriteLine(bacterium);
            }
        }
    }
}
