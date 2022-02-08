using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Snake
{
    /// <summary>
    /// Denna klass renderar konsolfönstret med en satt storlek
    /// i vilken spelvärlden sedan skapas
    /// </summary>
    class ConsoleRenderer
    {
        private GameWorld world;
        public ConsoleRenderer(GameWorld gameWorld)
        {
            // Renderar konsolen med satt storlek baserat på världen, +1 för att få plats med poäng-raden
            world = gameWorld;
            Console.SetWindowSize(world.Width, (world.Height+1)); 
        }
        /// <summary>
        /// Publik metod som renderar de olika spelobjekten
        /// </summary>
        public void Render()
        {            
            // Uppdaterar poängvärdet
            Console.SetCursorPosition(7, 0);
            Console.BackgroundColor = ConsoleColor.Blue;
            // Rensar poäng från föregående rendering
            Console.Write("    ");
            // Skriver ut aktuell poängställning
            Console.SetCursorPosition(7, 0);
            Console.Write(world.Score);
            Console.ResetColor();

            // Går igenom alla GameObjects
            foreach (var ob in world.GameObjects)
            {
                // Om objektet är spelaren ska mer än 1 position skrivas ut
                if (ob is Player)
                {                    
                    Player player = ob as Player;
                    // Gå igenom listan med alla ormens delar och skriv ut respektive position
                    foreach (var position in player.Body)
                    {
                        Console.SetCursorPosition(position.X, position.Y);                        
                        Console.Write(ob.Appearance);
                    }
                }   
                // Om objektet inte är spelaren ska endast en position skrivas ut
                else
                {
                    Console.SetCursorPosition(ob.Position.X, ob.Position.Y);
                    Console.Write(ob.Appearance);
                }             
            }
        }

        /// <summary>
        /// Tar bort föregående position genom att skriva ut blanksteg
        /// </summary>
        public void RenderBlank()
        {
            foreach (var ob in world.GameObjects)
            {
                // När ormen har växt till 3 delar i spelets start, så rensas den sista positionen
                if (ob is Player)
                {
                    Player player = ob as Player;
                    if (player.Body.Count >= 3)
                    {
                        Console.SetCursorPosition(player.Body[player.Body.Count - 1].X, player.Body[player.Body.Count - 1].Y);
                        Console.Write(" ");
                    }
                } 
                // För alla andra objekt rensas den senaste positionen
                else
                {
                    Console.SetCursorPosition(ob.Position.X, ob.Position.Y);
                    Console.Write(" ");
                }
            }          
        }
    }
}
