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
        }
        


        public override void Update()
        {
            
        }
    }
}


// Lägger till en kommentar här för att testa GIT
// En ny kommentar som jag försöker pusha upp till GIT
