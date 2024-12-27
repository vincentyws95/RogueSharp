using System.Diagnostics.CodeAnalysis;
using RogueSharp;
using RogueSharpTutorial.Library;
using Point = SadRogue.Primitives.Point;

namespace RogueSharpTutorial.Core
{
    public class DungeonMap : Map
    {
        private ScreenSurface _mapSurface;
        private IList<GameObject> _mapObjects;

        public IReadOnlyList<GameObject> MapObjects => _mapObjects.AsReadOnly();

        public ScreenSurface SurfaceObject => _mapSurface;

        public DungeonMap(int width, int height, Color backgroundColor, Point position)
        {
            _mapObjects = new List<GameObject>();
            _mapSurface = new ScreenSurface(width, height);
            _mapSurface.UseMouse = false;
            _mapSurface.Surface.DefaultBackground = backgroundColor;


        }

        public bool TryGetMapObject(Point position, [NotNullWhen(true)] out GameObject? gameObject)
        {
            // Try to find a map object at that position
            foreach (var otherGameObject in _mapObjects)
            {
                if (otherGameObject.Position == position)
                {
                    gameObject = otherGameObject;
                    return true;
                }
            }

            gameObject = null;
            return false;
        }

        public void Draw(Console mapConsole)
        {
            mapConsole.Clear();
            foreach(Cell cell in GetAllCells())
            {
                SetConsoleSymbolForCell(mapConsole, cell);
            }
        }

        private void SetConsoleSymbolForCell(Console console, Cell cell)
        {
            // When we haven't explored a cell yet, we don't want to draw anything
            if (!cell.IsExplored)
            {
                return;
            }

            // When a cell is currently in the field-of-view it should be drawn with ligher colors
            if (IsInFov(cell.X, cell.Y))
            {
                // Choose the symbol to draw based on if the cell is walkable or not
                // '.' for floor and '#' for walls
                if (cell.IsWalkable)
                {
                    console.Fill(cell.X, cell.Y, 1, Colors.FloorFov, Colors.FloorBackgroundFov, '.');
                }
                else
                {
                    console.Fill(cell.X, cell.Y, 1, Colors.WallFov, Colors.WallBackgroundFov, '#');
                }
            }
            // When a cell is outside of the field of view draw it with darker colors
            else
            {
                if (cell.IsWalkable)
                {
                    console.Fill(cell.X, cell.Y,1, Colors.Floor, Colors.FloorBackground, '.');
                }
                else
                {
                    console.Fill(cell.X, cell.Y,1, Colors.Wall, Colors.WallBackground, '#');
                }
            }
        }

        public void UpdatePlayerFieldOfView()
        {
            Player player = MyGame.Player;
            //Compute the field-of-view based on player's position and awareness
            ComputeFov(player.Position.X, player.Position.Y, player.Awareness, true);

            //mark all cells in field of view as being explored
            foreach(Cell cell in GetAllCells())
            {
                if (IsInFov(cell.X, cell.Y))
                    SetCellProperties(cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true);
            }
        }
 
        // Returns true when able to place the Actor on the cell or false otherwise
        public bool SetActorPosition(Actor actor, int x, int y)
        {
            // Only allow actor placement if the cell is walkable
            if (GetCell(x, y).IsWalkable)
            {
                // The cell the actor was previously on is now walkable
                SetIsWalkable(actor.X, actor.Y, true);
                // Update the actor's position
                actor.X = x;
                actor.Y = y;
                // The new cell the actor is on is now not walkable
                SetIsWalkable(actor.X, actor.Y, false);
                // Don't forget to update the field of view if we just repositioned the player
                if (actor is Player)
                {
                    UpdatePlayerFieldOfView();
                }
                return true;
            }
            return false;
        }

        // A helper method for setting the IsWalkable property on a Cell
        public void SetIsWalkable(int x, int y, bool isWalkable)
        {
            ICell cell = GetCell(x, y);
            SetCellProperties(cell.X, cell.Y, cell.IsTransparent, isWalkable, cell.IsExplored);
        }
    }
}
