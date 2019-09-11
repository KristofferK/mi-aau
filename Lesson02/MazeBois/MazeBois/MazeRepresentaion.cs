using System.Linq;

namespace MazeBois
{
    public class MazeRepresentaion
    {
        private string maze;
        public string Maze
        {
            get { return maze; }
            set
            {
                maze = value.Trim();
                RowsCache = maze.Split('\n').Select(e => e.Trim()).ToArray();
                Cols = RowsCache.First().Length;
            }
        }

        public int Rows => RowsCache.Length;
        public int Cols { get; private set; }

         private string[] RowsCache { get; set; }

        public MazeRepresentaion(string maze)
        {
            Maze = maze;
        }

        public char AtPos(int row, int col)
        {
            return RowsCache[row][col];
        }

        public char AtPos(Coord c)
        {
            return AtPos(c.X, c.Y);
        }

        public bool Legal(int row, int col)
        {
            return row >= 0 && row < Rows && col >= 0 && col < Cols;
        }

        public bool Legal(Coord c)
        {
            return Legal(c.X, c.Y);
        }
    }
}
