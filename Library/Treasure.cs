using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueSharpTutorial.Core;
using SadConsoleGame;

namespace RogueSharpTutorial.Library
{
    internal class Treasure : GameObject
    {
        public Treasure(Point position, IScreenSurface hostingSurface) : base(new ColoredGlyph(Color.Yellow, Color.Black, 'v'), position, hostingSurface)
        {
        }

        public override bool Touched(GameObject source, DungeonMap map)
        {
            return base.Touched(source, map);
        }
    }
}
