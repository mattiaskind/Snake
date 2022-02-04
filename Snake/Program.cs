using System;
using System.Text;
using System.Threading;
using System.Diagnostics;

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
            world.AddGameObject(player);

            // Skapar en fiende och lägger till till världen
            Enemy enemy = new Enemy(world, player.Position);
            world.AddGameObject(enemy);

            // Skapar två matbitar och lägger till världen
            Food food1 = new Food(world);
            world.AddGameObject(food1);

            Food food2 = new Food(world);
            world.AddGameObject(food2);          
            
            /*
            // Fyller kartan med mat i testsyfte
            Debug.WriteLine("####### TEST ######");
            for (int i = 0; i<1000; i++)
            {
                Debug.WriteLine("Skapar Food nr "+i);
                world.AddGameObject(new Food(world));
            }
                
            // Debugger stuff för testning
            foreach (var obj in world.GameObjects)
            {
                Debug.WriteLine(obj.Position.X+ ", "+obj.Position.Y);
            }
            Debug.WriteLine("####### TEST ######"); 
            */

            // Skriver ut rad med poäng i blå färg
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(("POÄNG: "+ world.Score).PadRight(Console.WindowWidth));
            Console.ResetColor();

            // Huvudloopen
            bool running = true;
            while (running)
            {
                // Kom ihåg vad klockan var i början
                DateTime before = DateTime.Now;

                // Uppdaterar poängvärdet
                Console.SetCursorPosition(7, 0);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(world.Score);
                Console.ResetColor();
                
                //Hantera knapptryckningar från användaren
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
