using RogueSharpTutorial.Interfaces;
using RogueSharpTutorial.Library;

namespace RogueSharpTutorial.Core
{
    public class Player : GameObject, IActor
    {
        public string Name { get; set; }
        public int Awareness { get; set; }

        public Player(ColoredGlyph appearance, Point position, IScreenSurface hostingSurface) : base(appearance, position, hostingSurface)
        {
            Awareness = 5;
            Name = "Rogue";
        }
        
    }
}
