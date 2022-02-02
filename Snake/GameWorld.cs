using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class GameWorld
    {
        public int Width;
        public int Height;
        public int Score;
        public List<GameObject> GameObjects;

        public GameWorld()
        {
            Width = 50; // 50
            Height = 20; // 20
            Score = 0;
            GameObjects = new List<GameObject>();
        }
        public void Update()
        {
            // Uppdatera varje objekt
            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObjects[i].Update();
                if (GameObjects[i] is Player)
                {
                    for(int j = 0; j < GameObjects.Count; j++)
                    {
                        if(GameObjects[j] is Food)
                        {
                            // När mat äts upp, generera ny mat och öka poängmängden
                            if(GameObjects[i].Position.X == GameObjects[j].Position.X && GameObjects[i].Position.Y == GameObjects[j].Position.Y)
                            {
                                Score++;
                                GameObjects.Remove(GameObjects[j]);
                                AddGameObject(new Food(this));                                
                            }
                        }
                    }                    
                }                              
            }
        }

        // Skapar nytt GameObject genom att lägga till i listan
        public void AddGameObject(GameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }
    }
}
