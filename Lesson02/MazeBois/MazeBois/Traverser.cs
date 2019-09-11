using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBois
{
    public class Traverser
    {
        public Dictionary<Tuple<int, int>, int> FrontierCounter(MazeRepresentaion maze)
        {
            var marked = new Dictionary<Tuple<int, int>, int>();
            var moves = 0;
            var queue = new Queue<Coord>();
            queue.Enqueue(GetStart(maze));
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (marked.Any(e => e.Key.Item1 == current.X && e.Key.Item2 == current.Y)) continue;
                marked[new Tuple<int, int>(current.X, current.Y)] = moves++;

                var right = current.Right();
                var down = current.Down();
                var left = current.Left();
                var up = current.Up();
                if (maze.Legal(right) && maze.AtPos(right) != '0') queue.Enqueue(right);
                if (maze.Legal(down) && maze.AtPos(down) != '0') queue.Enqueue(down);
                if (maze.Legal(left) && maze.AtPos(left) != '0') queue.Enqueue(left);
                if (maze.Legal(up) && maze.AtPos(up) != '0') queue.Enqueue(up);
            }

            return marked;
        }

        private Coord GetStart(MazeRepresentaion maze)
        {
            for (var i = 0; i < maze.Rows; i++)
            {
                for (var j = 0; j < maze.Cols; j++)
                {
                    if (maze.AtPos(i, j) == 's')
                    {
                        return new Coord(i, j);
                    }
                }
            }
            return null;
        }
    }
}
