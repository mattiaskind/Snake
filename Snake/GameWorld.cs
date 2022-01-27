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
            }
        }
    }
}
