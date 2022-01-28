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
        public Position Position;
        public char Appearance = '#';
        public GameWorld World;
 
        public GameObject(GameWorld world)
        {
            // Slumpa position, utgå från bredd och höjd på spelplanen samt andra objekt, se ovan            
            World = world;
            // Ge objektet en slumpvald position
            Position = new Position(randomizeStartPosition(World.Width), randomizeStartPosition(World.Height)); // Lägg till hantering av redan upptagna positioner
            
        }

        public abstract void Update();

        // Slumpar fram ett tal mellan 0 och max+1, används för att bestämma positionen när nya objekt skapas
        public int randomizeStartPosition(int max)
        {
            Random rnd = new Random();         
            return rnd.Next(max+1);
        }

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
