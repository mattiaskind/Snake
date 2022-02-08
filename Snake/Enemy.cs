using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Snake
{
    /// <summary>
    /// Klassen Enemy ärver från GameObject och förhåller sig till spelarens position
    /// Enemy jagar ständigt ormens huvud
    /// </summary>
    internal class Enemy : GameObject
    {
        private Position PlayerPosition;

        public Enemy(GameWorld world, Position playerPosition) : base(world)
        {
            // Fienden får ett "spöklikt" utseende i formen av ett 'A'
            Appearance = 'A';
            PlayerPosition = playerPosition;
        }
        /// <summary>
        /// Bestämmer position genom x och y värde
        /// </summary>        
        public void setPosition(int x, int y)
        {
            Position.X = x;
            Position.Y = y;
        }
        /// <summary>
        /// Kontrollerar var fienden är i förhållande till spelarens huvud
        /// </summary>
        public override void Update()
        {
            // Räknar ut skillanden i x- och y-led till spelaren
            int X = PlayerPosition.X - Position.X;
            int Y = PlayerPosition.Y - Position.Y;

            // Använder System.Math.Abs för att jämföra siffervärdet, oavsett om det är +/-
            // Uppdaterar sedan positionen baserat på olika utfall
            if(System.Math.Abs(X) > System.Math.Abs(Y))
            {
                if (X > 0) Position.X++; // HÖGER
                else if (X < 0) Position.X--; // VÄNSTER
            }
            else if (System.Math.Abs(Y) > System.Math.Abs(X))
            {
                if (Y > 0) Position.Y++; // NER 
                else if (Y < 0) Position.Y--; // UPP
            }
            else if (System.Math.Abs(Y) == System.Math.Abs(X))
            {
                // Slumpar fram random nummer för att slumpa riktning om det är lika avstånd i olika led
                Random random = new Random();
                int randomNumber = random.Next(1);
                if (randomNumber == 0)
                {
                    // Rör längs med X
                    if (X > 0) Position.X++; // HÖGER
                    else if (X < 0) Position.X--; // VÄNSTER
                }
                else
                {
                    // Rör längs med Y
                    if (Y > 0) Position.Y++; // NER 
                    else if (Y < 0) Position.Y--; // UPP
                }
            }
        }
    }
}
