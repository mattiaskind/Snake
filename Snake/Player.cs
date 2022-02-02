using Snake;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Snake
{
    internal class Player : GameObject
    {
        public Direction Direction;
        public List<Position> Body = new List<Position>();

        public Player(GameWorld world, Direction direction) : base(world)
        {
            Direction = direction;
            Appearance = 'O'; // Göra ormen lite längre?
            Body.Add(Position);            
              // Debug.WriteLine("Position: "+Body[0].X + ", "+ Body[0].Y);
        }

        public void UpdateBody()
        {
            if (Body.Count < 3)
            {
                Body.Add(new Position(new int[] {Position.X, Position.Y}));
                Debug.WriteLine("Adding position..." + Position.X + ", " + Position.Y);
            }
            else
            {
                Body[2].X = Body[1].X;
                Body[2].Y = Body[1].Y;

                Body[1].X = Body[0].X;
                Body[1].Y = Body[0].Y;

                /*Body[0].X = Position.X;
                Body[0].Y = Position.Y; */
            }
        }

        public void SetDirection(Direction direction)
        {
            Direction = direction;
        }

        public override void Update()
        {
            UpdateBody();

            // För testning
            Debug.WriteLine("Snake is moving...");
            // För testning
            foreach (Position p in Body)
            {
                Debug.WriteLine("X: " + p.X + ", Y: " + p.Y);
            }

            if (Direction == Direction.up)
            {
                Position.Y -= 1;
                CheckPosition();
            }
            else if(Direction == Direction.down)
            {
                Position.Y += 1;
                CheckPosition();
            }
            else if(Direction == Direction.left)
            {
                Position.X -= 1;
                CheckPosition();
            }
            else if(Direction == Direction.right)
            {
                Position.X += 1;
                CheckPosition();
            }
        }

    }
}

