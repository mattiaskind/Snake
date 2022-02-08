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
        /// Metoden Update() behövs iom arv, men själva funktionen för vad som sker
        /// när maten äts upp hanteras i GameWorld.cs
        /// </summary>
        public override void Update()
        {
            
        }
    }
}

