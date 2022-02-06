using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    /// <summary>
    /// Klassen food är ett Gameobject som skapas.
    /// </summary>
    internal class Food : GameObject
    {        
        public Food(GameWorld world) : base(world)
        {
            Appearance = 'ó';
        }
        /// <summary>
        /// Metoden setPosition bestämmer matens position genom x och y värde
        /// </summary>
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

