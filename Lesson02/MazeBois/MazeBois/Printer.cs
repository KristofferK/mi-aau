using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBois
{
    public class Printer
    {
        public void PrintTraversalResult(Dictionary<Tuple<int, int>, int> result, List<Coord> path, MazeRepresentaion maze)
        {
            for (var i = 0; i < maze.Rows; i++)
            {
                for (var j = 0; j < maze.Cols; j++)
                {
                    Console.ForegroundColor = GetColor(maze, path, i, j);
                    Console.Write($"     {maze.AtPos(i, j)}     ");
                }
                Console.WriteLine();
                for (var j = 0; j < maze.Cols; j++)
                {
                    Console.ForegroundColor = GetColor(maze, path, i, j);
                    var tuple = new Tuple<int, int>(i, j);
                    if (result.ContainsKey(tuple))
                    {
                        Console.Write($"   ({result[tuple].ToString("D2")})    ");
                    }
                    else
                    {
                        Console.Write($"   (xx)    ");
                    }
                }
                Console.WriteLine("\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private ConsoleColor GetColor(MazeRepresentaion maze, List<Coord> path, int i, int j)
        {
            if (path.Any(e => e.X == i && e.Y == j)) return ConsoleColor.Magenta;
            var c = maze.AtPos(i, j);
            if (c == 's') return ConsoleColor.Cyan;
            else if (c == 'g') return ConsoleColor.Cyan;
            else if (c == '1') return ConsoleColor.Green;
            else if (c == '0') return ConsoleColor.Red;
            return ConsoleColor.White;
        }
    }
}
