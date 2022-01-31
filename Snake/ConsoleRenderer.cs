using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class ConsoleRenderer
    {
        private GameWorld world;
        public ConsoleRenderer(GameWorld gameWorld)
        {
            // Renderar konsolen med satt storlek baserat på världen -- Lägg till extra rad för Score ?
            world = gameWorld;
            Console.SetWindowSize(world.Width, world.Height);
        }

        public void Render()
        {
            // TODO Poängräkningen

            // Renderar GameObjects -- saknar Score
            foreach(var ob in world.GameObjects)
            {
                Console.SetCursorPosition(ob.Position.X, ob.Position.Y);
                Console.Write(ob.Appearance);
            }
        }

        // Tar bort föregående position genom att skriva ut " " 
        public void RenderBlank()
        {

            foreach (var ob in world.GameObjects)
                if (ob is Player)
                {
                    Console.SetCursorPosition(ob.Position.X, ob.Position.Y);
                    Console.Write(" ");
                }
        }
    }
}
