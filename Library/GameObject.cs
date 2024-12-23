using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueSharpTutorial.Library
{
    public class GameObject
    {
        private ColoredGlyph _mapAppearance = new ColoredGlyph();

        public Point Position { get; private set; }

        public ColoredGlyph Appearance { get; set; }

        public GameObject(ColoredGlyph appearance, Point position, IScreenSurface hostingSurface)
        {
            Appearance = appearance;
            Position = position;

            //store the map cell
            hostingSurface.Surface[position].CopyAppearanceTo(_mapAppearance);

            DrawGameObject(hostingSurface);
        }

        public void Move(Point newPosition, IScreenSurface screenSurface)
        {
            //restore the old cell to the current position
            _mapAppearance.CopyAppearanceTo(screenSurface.Surface[Position]);
            
            //Store the map cell of the new position
            screenSurface.Surface[newPosition].CopyAppearanceTo(_mapAppearance);

            Position = newPosition; 
            DrawGameObject(screenSurface);
        }

        private void DrawGameObject(IScreenSurface screenSurface)
        {
            Appearance.CopyAppearanceTo(screenSurface.Surface[Position]);
            screenSurface.IsDirty = true;
        }

    }
}
