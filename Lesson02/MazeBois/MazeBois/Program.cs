using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBois
{
    class Program
    {
        static void Main(string[] args)
        {
            var maze = new MazeGenerator().GenerateMaze();
            var frontiterResult = new Traverser().FrontierCounter(maze);
            new Printer().PrintTraversalResult(frontiterResult, maze);
            new ImageGenerator().GenerateImage(frontiterResult, maze);
        }
    }
}
