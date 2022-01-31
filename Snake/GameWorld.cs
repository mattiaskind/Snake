using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class GameWorld
    {
        public int Width;
        public int Height;
        int Score;
        public List<GameObject> GameObjects;

        public GameWorld()
        {
            // Måsta kunna dela Width / Height till GameObject / Player
            Width = 50;
            Height = 20;
            Score = 0;
            GameObjects = new List<GameObject>();
        }
        public void Update()
        {
            // Uppdatera varje objekt
            foreach (var ob in GameObjects)
            {
                ob.Update();
                if (ob is Player)
                {
                    foreach(var ob2 in GameObjects)
                    {
                        if(ob2 is Food)
                        {
                            if(ob.Position.X == ob2.Position.X && ob.Position.Y == ob2.Position.Y)
                            {
                                Console.WriteLine("MAT");
                            }
                        }
                    }                    
                }
                //ob.CheckDuplicatePosition();
                              
            }
        }

        // Skapar nytt GameObject genom att lägga till i listan
        public void AddGameObject(GameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }
    }
}
