using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    internal class Position
    {
        public int X;
        public int Y;

        public Position(int[] position)
        {
            X = position[0];
            Y = position[1];
        }
        
    }
}
