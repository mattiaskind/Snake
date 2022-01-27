using Snake;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    internal class Player : GameObject
    {
        Direction Direction;


        /*public Player(int x, int y, GameWorld world, Direction direction) : base(x, y, world)
        {
            Direction = direction;
        }*/

        public Player(int x, int y, Direction direction) : base(x, y)
        {
            Direction = direction;
        }

        public override void Update()
        {            

            if (Direction == Direction.up)
            {
                Position.Y -= 1;
                //CheckPosition(Position.X, Position.Y);
            }
            else if(Direction == Direction.down)
            {
                Position.Y += 1;
                //CheckPosition(Position.X, Position.Y);
            }
            else if(Direction == Direction.left)
            {
                Position.X -= 1;
                //CheckPosition(Position.X, Position.Y);
            } 
            else if(Direction == Direction.right)
            {
                Position.X += 1;
                //CheckPosition(Position.X, Position.Y);
            }
        }

        // Metod för att hantera ormen och spelplanens gränser
        void CheckPosition(int x, int y)
        {
            

            if (x > World.Width)
            {
                Position.X = 0;
            }
            else if (y > World.Height)
            {
                Position.Y = 0;
            }
            else if (x < 0)
            {
                Position.X = World.Width-1;
            }
            else if (y < 0)
            {
                Position.Y = World.Height-1;
            }
        }
    }
}

