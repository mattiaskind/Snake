using Snake;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Snake
{
    internal class Player : GameObject
    {
        int i = 0;
        public Direction Direction;
        public List<Position> Body = new List<Position>();

        public Player(GameWorld world, Direction direction) : base(world)
        {
            Direction = direction;
            Appearance = 'O';
            Body.Add(Position);            
              // Debug.WriteLine("Position: "+Body[0].X + ", "+ Body[0].Y);
        }

        public void UpdateBody()
        {
            /*if (Body.Count < 3)
            {                
                Body.Add(new Position(new int[] { Position.X, Position.Y }));
                Debug.WriteLine("Adding position..." + Position.X + ", " + Position.Y);
            } */

            if (Body.Count == 1)
            {
                Body.Add(new Position(new int[] { Body[0].X, Body[0].Y }));
                Debug.WriteLine("BodyCount: " + Body.Count);
            }

            else if (Body.Count == 2)
            {
                Body.Add(new Position(new int[] { Body[1].X, Body[1].Y }));

                Body[1].X = Body[0].X;
                Body[1].Y = Body[0].Y;
                Debug.WriteLine("BodyCount: " + Body.Count);
            }
            else if (Body.Count == 3)  
            {
                Debug.WriteLine("Moving indexes...");
                Body[2].X = Body[1].X;
                Body[2].Y = Body[1].Y;

                Body[1].X = Body[0].X;
                Body[1].Y = Body[0].Y; 

            }
        }

        public void SetDirection(Direction direction)
        {
            Direction = direction;
        }

        public override void Update()
        {
            UpdateBody();

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

            // För testning
            foreach (Position p in Body)
            {
                Debug.WriteLine("X: " + p.X + ", Y: " + p.Y+ ", @ count: "+Body.Count);
            }
        }

    }
}

