using System;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Snake
{
    /* Vi har byggt ett Snake-spel där ormen växer till tre tecken. Två matbitar
     * slumpas fram på spelplanen och när ormen äter upp en matbit ger det en poäng. 
     * En ny matbit slumpas också fram. Vi har även implementerat ett "spöke" som jagar ormens huvud,
     * men kan kollidera med hela ormens kropp.
     * Vid kollision med spöket minskar antalet poäng med 5 och spöket flyttas till en ny position. 
     */

    class Program
    {
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
            world.AddGameObject(new Enemy(world, player.Position));
            // Skapar två matbitar och lägger till världen            
            world.AddGameObject(new Food(world));
            world.AddGameObject(new Food(world));            

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
