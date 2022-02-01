using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    internal class Food : GameObject
    {        
        public Food(GameWorld world) : base(world)
        {
            
            // Ge maten funktion för att ätas upp
            Appearance = 'a';

        }

        public void setPosition(int x, int y)
        {
            Position.X = x;
            Position.Y = y;
            /* int[] positions = randomizeStartPosition();
            Position.X = positions[0];
            Position.Y = positions[1]; */
        }      


        public override void Update()
        {
            
        }
    }
}

