using Snake;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Snake
{
    //den här variable håller reda på spelarens riktning
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
            // här vi skapar en könstrktör som har en objekt world från klass GameWorld
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
        // i den här function väljer vi slumpmässig start punkt enligt width och hight.
  
        public int[] randomizeStartPosition()
        {
            int width = World.Width;
            int height = World.Height;

            Random rnd = new Random();

            int x = rnd.Next(width); // räknar nästa rnd position från 0 till max bredd
            int y = rnd.Next(1, height+1);  // räknar nästa rnd position från 1 till max höjd+1

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


        // Metod för att hantera ormen och spelplanens gränser, om ormen inträffar gärnsen från ena sidan, förtsätter den på sidan mitt emot med samma riktning
        public void CheckPosition()
        {
            if (Position.X > World.Width-1) 
            {
                Position.X = 0;
            }
            else if (Position.Y > World.Height)
            {
                Position.Y = 1; // ormen börjam från position y = 1 eftersom position 0 är poäng rad
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
