using Snake;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

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
        public char Appearance; 
        public GameWorld World;
 
        public GameObject(GameWorld world)
        {
            // Slumpa position, utgå från bredd och höjd på spelplanen samt andra objekt, se ovan            
            World = world;
            // Ge objektet en slumpvald position
            //Position = new Position(randomizeStartPosition(World.Width, false), randomizeStartPosition(World.Height, true)); // Lägg till hantering av redan upptagna positioner

            Position = new Position(randomizeStartPosition());                                                           
        }

        public abstract void Update();

        public int[] randomizeStartPosition()
        {
            int width = World.Width;
            int height = World.Height;

            Random rnd = new Random();

            int x = rnd.Next(width);
            int y = rnd.Next(1, height);  

            foreach (var obj in World.GameObjects)
            {
                //Debug.WriteLine("Foreachar: " + obj + " "+ obj.Position.X + ", " + obj.Position.Y);
                while (obj.Position.X == x && obj.Position.Y == y)
                {
                    //Debug.WriteLine("I while-loopen: "+ obj+" " +obj.Position.X + ", " + obj.Position.Y);
                    x = rnd.Next(width);
                    y = rnd.Next(1, height);   
                }
            }
            return new [] { x, y };
        }

        // Metod för att hantera ormen och spelplanens gränser
        public void CheckPosition()
        {
            if (Position.X > World.Width-1)
            {
                Position.X = 0;
            }
            else if (Position.Y > World.Height)
            {
                Position.Y = 1;
            }
            else if (Position.X < 0)
            {
                Position.X = World.Width - 1;
            }
            else if (Position.Y < 1)
            {
                Position.Y = World.Height;
            }
        }

    }
}
