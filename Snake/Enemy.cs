using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    internal class Enemy : GameObject
    {
        public Enemy(GameWorld world) : base(world)
        {
            Appearance = 'A';
        }

        public void setPosition(int x, int y)
        {
            Position.X = x;
            Position.Y = y;
        }

        public override void Update()
        {

        }
    }
}
