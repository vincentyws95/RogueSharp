using RogueSharp;
using RogueSharpTutorial.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueSharpTutorial.Core
{
    public class Actor : IActor, IDrawable
    {
        public string Name { get; set; } = "";
        public int Awareness { get; set; }
        public Color Color { get; set; }
        public char Symbol { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Draw(Console console, IMap map)
        {
            // Don't draw actors in cells that haven't been explored
            if (!map.GetCell(X, Y).IsExplored)
            {
                return;
            }

            // Only draw the actor with the color and symbol when they are in field-of-view
            if (map.IsInFov(X, Y))
            {
                console.Fill(X, Y, 1, Color, Colors.FloorBackgroundFov, Symbol);
            }
            else
            {
                // When not in field-of-view just draw a normal floor
                console.Fill(X, Y, 1, Colors.Floor, Colors.FloorBackground, '.');
            }
        }
    }
}
