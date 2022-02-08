using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    internal class Position
    {
        public int X;
        public int Y;

        // Konstruktorn skapar ett positions-objekt med X- och Y-positioner
        public Position(int[] position)
        {
            X = position[0];
            Y = position[1];
        }
        
    }
}
