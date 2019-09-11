namespace MazeBois
{
    public class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Coord (int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coord Left()
        {
            return new Coord(X, Y - 1);
        }
        public Coord Right()
        {
            return new Coord(X, Y + 1);
        }
        public Coord Up()
        {
            return new Coord(X - 1, Y);
        }
        public Coord Down()
        {
            return new Coord(X + 1, Y);
        }
    }
}
