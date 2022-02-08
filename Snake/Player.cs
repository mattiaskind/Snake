using Snake;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Snake
{
    /// <summary>
    /// Klassen Player är ett Spelobjekt, tillika ormen i spelet.
    /// Player innehåller spelarens kropp och riktning och som 
    /// dessutom läggs till i en lista vid namn Body.
    internal class Player : GameObject
    {
        //int i = 0;
        public Direction Direction;
        public List<Position> Body = new List<Position>();

        public Player(GameWorld world, Direction direction) : base(world)
        {
            Direction = direction;
            Appearance = '0'; 
            Body.Add(Position);            
        }
        /// <summary>
        /// Uppdaterar och adderar ormens kropp till ett maximalt värde av 3,
        /// samt dess position genom x och y värden
        /// </summary>
        public void UpdateBody() 
        {
            if (Body.Count == 1)
            {
                Body.Add(new Position(new int[] { Body[0].X, Body[0].Y }));
            }
            else if (Body.Count == 2)
            {
                Body.Add(new Position(new int[] { Body[1].X, Body[1].Y }));
                Body[1].X = Body[0].X; 
                Body[1].Y = Body[0].Y; 
            }
            else if (Body.Count == 3)  
            {
                Body[2].X = Body[1].X;
                Body[2].Y = Body[1].Y;
                Body[1].X = Body[0].X;
                Body[1].Y = Body[0].Y; 
            }
        }
        /// <summary>
        /// Sätter vilken riktning ormen har
        /// </summary>
        public void SetDirection(Direction direction)
        {
            Direction = direction;
        }

        /// <summary>
        /// Uppdaterar ormens kropp samt uppdaterar vilken position den
        /// har genom x och y värden
        /// </summary>
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
        }
    }
}

