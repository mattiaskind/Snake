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
            World = world;
            // Ge objektet en slumpvald position
            Position = new Position(randomizeStartPosition());                                                           
        }

        public abstract void Update();

        private bool CheckIfPositionOccupied(int x, int y)
        {
            // Går igenom befintliga objekt och kontrollerar deras position
            foreach (var gameObject in World.GameObjects)
            {
                if (gameObject.Position.X == x && gameObject.Position.Y == y) return true;
            }
            return false;
        }

        public int[] randomizeStartPosition()
        {
            int width = World.Width;
            int height = World.Height;

            Random rnd = new Random();

            int x = rnd.Next(width);
            int y = rnd.Next(1, height+1);  

            foreach (var obj in World.GameObjects)
            {
                while(CheckIfPositionOccupied(x, y))
                {
                    x = rnd.Next(width);
                    y = rnd.Next(1, height+1);   
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
