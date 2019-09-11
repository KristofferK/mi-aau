using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeBois
{
    public class ShortestPathFinder
    {
        public List<Coord> GetCoordinatesUsed(Dictionary<Tuple<int, int>, int> frontiterResult, MazeRepresentaion maze)
        {
            var coords = new List<Coord>();
            var start = maze.GetStart();
            coords.Add(GetLowest(frontiterResult, maze.GetEnd()));
            while (true)
            {
                var next = GetLowest(frontiterResult, coords.Last());
                if (next.X == start.X && next.Y == start.Y)
                {
                    break;
                }
                coords.Add(next);
            }
            return coords;
        }

        private Coord GetLowest(Dictionary<Tuple<int, int>, int> frontiterResult, Coord c)
        {
            return new Coord[] { c.Right(), c.Down(), c.Left(), c.Up() }
                .Select(e => new
                {
                    Coord = e,
                    Tuple = new Tuple<int, int>(e.X, e.Y)
                })
                .Where(e => frontiterResult.ContainsKey(e.Tuple))
                .OrderBy(e => frontiterResult[e.Tuple])
                .First()
                .Coord;
        }
    }
}