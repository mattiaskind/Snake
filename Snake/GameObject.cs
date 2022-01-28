using Snake;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public enum Direction
    {
        up,
        down,
        left,
        right,
    }

    abstract class GameObject
    {
        // TODO
        public Position Position;
        public char Appearance = '#';
        public GameWorld World;

        // Hämta storlek på spelplan från GameWorld 
        // Skapa lista för samtliga GameObject med positioner
        // Skapa GameObject med slumpad startposition
        // Lägg till GameObject i lista allt eftersom att de skapas -- OM positionen redan är tagen, ge ny position
        

        /*public GameObject(int x, int y, GameWorld world)
        {
            // Slumpa position, utgå från bredd och höjd på spelplanen samt andra objekt, se ovan
            Position = new Position(x, y);
            World = world;
        } */

        public GameObject(int x, int y, GameWorld world)
        {
            // Slumpa position, utgå från bredd och höjd på spelplanen samt andra objekt, se ovan
            Position = new Position(x, y);
            World = world;
        }

        public abstract void Update();

        // Metod för att hantera ormen och spelplanens gränser
        public void CheckPosition()
        {
            if (Position.X > World.Width-1)
            {
                Position.X = 0;
            }
            else if (Position.Y > World.Height-1)
            {
                Position.Y = 0;
            }
            else if (Position.X < 0)
            {
                Position.X = World.Width - 1;
            }
            else if (Position.Y < 0)
            {
                Position.Y = World.Height - 1;
            }
        }

    }
}
