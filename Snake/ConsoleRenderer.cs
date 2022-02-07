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
        //private Player player;
        public ConsoleRenderer(GameWorld gameWorld)
        {
            // Renderar konsolen med satt storlek baserat på världen
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

            foreach (var ob in world.GameObjects)
            {
                if (ob is Player)
                {
                    Player player = ob as Player;

                    foreach (var position in player.Body)
                    {
                        Console.SetCursorPosition(position.X, position.Y);                        
                        Console.Write(ob.Appearance);
                    }
                }   
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
                if (ob is Player)
                {
                    Player player = ob as Player;
                    if (player.Body.Count >= 3)
                    {
                        Console.SetCursorPosition(player.Body[player.Body.Count - 1].X, player.Body[player.Body.Count - 1].Y);
                        Console.Write(" ");
                    }
                } else
                {
                    Console.SetCursorPosition(ob.Position.X, ob.Position.Y);
                    Console.Write(" ");
                }
            }          
        }
    }
}
