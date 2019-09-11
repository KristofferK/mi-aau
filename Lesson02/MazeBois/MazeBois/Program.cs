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
            RunMaze(new MazeGenerator().GenerateMaze(), "maze01.jpg");
            //RunMaze(new MazeGenerator().GenerateMaze2(), "maze02.jpg");
            //RunMaze(new MazeGenerator().GenerateMaze3(), "maze03.jpg");
        }

        private static void RunMaze(MazeRepresentaion maze, string imageTitle)
        {
            var frontiterResult = new Traverser().FrontierCounter(maze);
            var path = new ShortestPathFinder().GetCoordinatesUsed(frontiterResult, maze);
            new Printer().PrintTraversalResult(frontiterResult, path, maze);
            new ImageGenerator().GenerateImage(frontiterResult, path, maze, imageTitle);
            Console.WriteLine();
        }
    }
}
