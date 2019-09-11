using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBois
{
    public class MazeGenerator
    {
        public MazeRepresentaion GenerateMaze()
        {
            return new MazeRepresentaion(@"
111111111
111111101
1111s1111
100000101
10101010g
101010101
111111111
111111111
");
        }
    }
}
