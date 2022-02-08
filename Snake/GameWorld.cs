using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    /// <summary>
    /// I den här class har vi variabler width, height, score och list från class Gameobject som skulle visa appearence och 
    /// positionen och kontrollera de. 
    /// </summary>
    class GameWorld
    {
        public int Width;
        public int Height;
        public int Score;
        public List<GameObject> GameObjects;

        public GameWorld()
        {
            // Width och Height bestämmer spelplanens storlek
            Width = 50;
            Height = 20;
            Score = 0;
            GameObjects = new List<GameObject>();
        }
        /// <summary>
        /// i den här funktion, när player och food möter i samma punkt antal poäng ökar en, och den tar bort det objekt food 
        ///  och skapa nytt objekt istället i ny slumpmässig punkt och lägger den i listan
        /// </summary>
        public void Update()
        {
            for (int i = 0; i < GameObjects.Count; i++)
            {
                GameObjects[i].Update();
                // Om GameObject är spelare, kontrollera om spelaren kolliderat med en matbit 
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
                // Om GameObject är av typen Enemy, kontrollera om objektet kolliderat med spelaren
                if (GameObjects[i] is Enemy)
                {
                    for(int j = 0; j < GameObjects.Count;j++)
                    {
                        if(GameObjects[j] is Player)
                        {
                            Player player = GameObjects[j] as Player;                         
                            // Gå igenom alla delar av ormen och kontrollera om objektet har kolliderat med någon del
                            foreach(var position in player.Body)
                            {
                                // När fienden träffar ormen, minska poängen, ta bort och lägg till ny fiende
                                if (GameObjects[i].Position.X == position.X && GameObjects[i].Position.Y == position.Y)
                                {
                                    Score = Score - 5; // Minska poängantalet med 5 vid kollision
                                    GameObjects.Remove(GameObjects[i]);
                                    AddGameObject(new Enemy(this, GameObjects[j].Position));
                                }
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
