using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueSharp;
using RogueSharpTutorial.Core;
using SadConsoleGame;
using Map = SadConsoleGame.Map;
using Point = SadRogue.Primitives.Point;

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

        public bool Move(Point newPosition, DungeonMap map)
        {
            // Check new position is valid
            if (!map.SurfaceObject.IsValidCell(newPosition.X, newPosition.Y)) return false;

            // Check if other object is there
            if (map.TryGetMapObject(newPosition, out GameObject? foundObject))
            {
                // We touched the other object, but they won't allow us to move into the space
                if (!foundObject.Touched(this, map))
                    return false;
            }

            // Restore the old cell
            _mapAppearance.CopyAppearanceTo(map.SurfaceObject.Surface[Position]);

            // Store the map cell of the new position
            map.SurfaceObject.Surface[newPosition].CopyAppearanceTo(_mapAppearance);

            Position = newPosition;
            DrawGameObject(map.SurfaceObject);

            return true;
        }

        public virtual bool Touched(GameObject source, DungeonMap map)
        {
            return false;
        }

        public void RestoreMap(DungeonMap map)
        {
            _mapAppearance.CopyAppearanceTo(map.SurfaceObject.Surface[Position]);
        }

        private void DrawGameObject(IScreenSurface screenSurface)
        {
            Appearance.CopyAppearanceTo(screenSurface.Surface[Position]);
            screenSurface.IsDirty = true;
        }

    }
}
