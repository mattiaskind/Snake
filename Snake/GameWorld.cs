using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

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
                        if (GameObjects[j] is Wall)
                        {
                            // Krock med vägg
                            if (GameObjects[i].Position.X == GameObjects[j].Position.X && GameObjects[i].Position.Y == GameObjects[j].Position.Y)
                            {
                                // Hantera ny position
                                Player player = GameObjects[i] as Player;
                                var positionDifference = player.Body[0] - player.Body[1];

                                if (positionDifference.X == 1) // om åt höger
                                {
                                    player.Body[0].X = player.Body[1].X;
                                    player.SetDirection(Direction.left);
                                }
                                else if (positionDifference.X == -1) // om åt vänster
                                {
                                    player.Body[0].X = player.Body[1].X;
                                    player.SetDirection(Direction.right);
                                }
                                else if (positionDifference.Y == 1) // om nedåt
                                {
                                    player.Body[0].Y = player.Body[1].Y;
                                    player.SetDirection(Direction.up);
                                }
                                else if (positionDifference.Y == -1) // om uppåt
                                {
                                    player.Body[0].Y = player.Body[1].Y;
                                    player.SetDirection(Direction.down);
                                }
                            }
                        }

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
                        if (GameObjects[j] is Wall)
                        {
                            // Krock med vägg
                            if (GameObjects[i].Position.X == GameObjects[j].Position.X && GameObjects[i].Position.Y == GameObjects[j].Position.Y)
                            {
                                // Hantera ny position
                                Enemy enemy = GameObjects[i] as Enemy;
                                var positionDifference = enemy.Position - enemy.PreviousPosition;

                                if (positionDifference.X == 1) // om åt höger
                                {
                                    enemy.Position.X = enemy.PreviousPosition.X;
                                }
                                else if (positionDifference.X == -1) // om åt vänster
                                {
                                    enemy.Position.X = enemy.PreviousPosition.X;
                                }
                                else if (positionDifference.Y == 1) // om nedåt
                                {
                                    enemy.Position.Y = enemy.PreviousPosition.Y;
                                }
                                else if (positionDifference.Y == -1) // om uppåt
                                {
                                    enemy.Position.Y = enemy.PreviousPosition.Y;
                                }
                            }
                        }

                        if (GameObjects[j] is Player)
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

        // Metod för att hantera vad som händer efter kollision med vägg
        /*
        public int[] randomizeNextPosition()
        {
            int width = Width;
            int height = Height;

            Random rnd = new Random();
            int x = rnd.Next(width); // räknar nästa rnd position från 0 till max bredd
            int y = rnd.Next(1, height + 1);  // räknar nästa rnd position från 1 till max höjd+1

            foreach (var obj in GameObjects)
            {
                while (CheckIfPositionOccupied(x, y))
                {
                    x = rnd.Next(width);
                    y = rnd.Next(1, height + 1);
                }
            }
            return new[] { x, y };
        }
        */
    }
}
