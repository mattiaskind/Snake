using System;
using System.Text;
using System.Threading;

namespace Snake
{
    class Program
    {
        /// <summary>
        /// Checks Console to see if a keyboard key has been pressed, if so returns it, otherwise NoName.
        /// </summary>
        static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;       

        static void Loop()
        {
            // Initialisera spelet
            const int frameRate = 5;
            GameWorld world = new GameWorld();
            ConsoleRenderer renderer = new ConsoleRenderer(world);

            // Skapar spelaren och lägger till till världen                    
            Player player = new Player(world, Direction.right);
            Food food = new Food(world);

            food.setPosition(0, 0); // för testning
            
            world.AddGameObject(player);
            world.AddGameObject(food);

            // Huvudloopen
            bool running = true;
            while (running)
            {
                // Kom ihåg vad klockan var i början
                DateTime before = DateTime.Now;

                // Hantera knapptryckningar från användaren
                ConsoleKey key = ReadKeyIfExists();
                switch (key)
                {
                    case ConsoleKey.Q:
                        running = false;
                        break;

                    case ConsoleKey.LeftArrow:
                        player.SetDirection(Direction.left);
                        break;

                    case ConsoleKey.RightArrow:
                        player.SetDirection(Direction.right);
                        break;

                    case ConsoleKey.UpArrow:
                        player.SetDirection(Direction.up);
                        break;

                    case ConsoleKey.DownArrow:
                        player.SetDirection(Direction.down);
                        break;
                }

                // Uppdatera världen och rendera om
                renderer.RenderBlank();
                world.Update();
                renderer.Render();

                // Mät hur lång tid det tog
                double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
                if (frameTime > 0)
                {
                    // Vänta rätt antal millisekunder innan loopens nästa varv
                    Thread.Sleep((int)frameTime);
                }
            }
        }

        static void Main(string[] args)
        {
            // Gömmer markören
            Console.CursorVisible = false;
            // Vi kan ev. ha någon meny här, men annars börjar vi bara spelet direkt
            Loop();
        }
    }
}
