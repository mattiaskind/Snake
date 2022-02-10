using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Wall : GameObject
    {
        public Wall(GameWorld world) : base(world)
        {
            Appearance = '#';
        }

        public void setPosition(int x, int y)
        {
            Position.X = x;
            Position.Y = y;
        }

        public override void Update()
        {
            // get map from Maps.cs
            // Rita ut map
        }
    }
}
