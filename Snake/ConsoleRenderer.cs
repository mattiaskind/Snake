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
            // TODO Konfigurera Console-fönstret enligt världens storlek
            world = gameWorld;
            Console.SetWindowSize(world.Width, world.Height);
        }

        public void Render()
        {
            // TODO Rendera spelvärlden (och poängräkningen)
            // Använd Console.SetCursorPosition(int x, int y) and Console.Write(char)
            
            //Console.SetCursorPosition(world.GameObjects[0].Position.X, world.GameObjects[0].Position.Y);
            //Console.Write(world.GameObjects[0].Appearance);

            foreach(var ob in world.GameObjects)
            {
                Console.SetCursorPosition(ob.Position.X, ob.Position.Y);
                Console.Write(ob.Appearance);
            }
        }

        public void RenderBlank()
        {
            foreach(var ob in world.GameObjects)
            {
                Console.SetCursorPosition(ob.Position.X, ob.Position.Y);
                Console.Write(" ");
            }
        }
    }
}
