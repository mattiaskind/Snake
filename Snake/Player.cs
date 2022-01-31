using Snake;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    internal class Player : GameObject
    {
        public Direction Direction;

        public Player(GameWorld world, Direction direction) : base(world)
        {
            Direction = direction;
            Appearance = 'O';
        }

        public void SetDirection(Direction direction)
        {
            Direction = direction;
        }

        public override void Update()
        {            
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

