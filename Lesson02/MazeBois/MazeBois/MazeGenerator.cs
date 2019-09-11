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

        public MazeRepresentaion GenerateMaze2()
        {
            return new MazeRepresentaion(@"
111111111
111111101
1111s1111
100000101
101010100
000011100
110001000
00g111100
");
        }

        public MazeRepresentaion GenerateMaze3()
        {
            return new MazeRepresentaion(@"
s11111111111
000000000001
111110011g01
100010010001
101111010101
101000010101
101111111101
100000000001
111111111111
");
        }
    }
}
