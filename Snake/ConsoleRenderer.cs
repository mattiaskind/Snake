using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Snake
{
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

        public void Render()
        {
            // Renderar GameObjects
            foreach(var ob in world.GameObjects)
            {
                if (ob is Player)
                {
                    Player player = ob as Player;
                    /*for (int i = 0; i < 3; i++)
                    {
                        Console.SetCursorPosition(player.Body[i].X, player.Body[i].Y);
                        Console.Write(ob.Appearance);
                    } */

                    foreach (var position in player.Body)
                    {
                        Console.SetCursorPosition(position.X, position.Y);                        
                        Console.Write(ob.Appearance);
                        
                        // För testning
                        //Debug.WriteLine("Length: "+player.Body.Count+ " @ "+    position.X + ", " + +position.Y);
                    }
                }   
                else
                {
                    Console.SetCursorPosition(ob.Position.X, ob.Position.Y);
                    Console.Write(ob.Appearance);
                }             
            }
        }

        // Tar bort föregående position genom att skriva ut " " 
        public void RenderBlank()
        {
            foreach (var ob in world.GameObjects)
                if (ob is Player)
                {
                    // TODO Spelaren hoppar till vid start
                    Player player = ob as Player;
                    if (player.Body.Count < 3)
                    {
                        /*Debug.WriteLine("Removing at "+player.Body.Count+": " + player.Body[0].X + ", " + player.Body[0].Y);
                        Console.SetCursorPosition(player.Body[0].X, player.Body[0].Y);
                        Debug.WriteLine("Snake is smol");*/
                    }
                    else
                    {
                        Debug.WriteLine("Removing: "+ player.Body[player.Body.Count - 1].X +", "+ player.Body[player.Body.Count - 1].Y);
                        Console.SetCursorPosition(player.Body[player.Body.Count-1].X, player.Body[player.Body.Count-1].Y);
                        
                    }
                    
                    Console.Write(" ");
                } 
        }
    }
}
