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

        public static Position operator +(Position a, Position b) => new Position(new int[] { a.X + b.X, a.Y + b.Y });
        public static Position operator -(Position a, Position b) => new Position(new int[] { a.X - b.X, a.Y - b.Y });

    }
}


