using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    internal class Food : GameObject
    {        
        public Food(GameWorld world) : base(world)
        {
            Appearance = 'ó';
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

