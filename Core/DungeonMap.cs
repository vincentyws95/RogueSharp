﻿using RogueSharp;

namespace RogueSharpTutorial.Core
{
    public class DungeonMap : Map
    {
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
            ComputeFov(player.X, player.Y, player.Awareness, true);

            //mark all cells in field of view as being explored
            foreach(Cell cell in GetAllCells())
            {
                if (IsInFov(cell.X, cell.Y))
                    SetCellProperties(cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true);
            }
        }
    }
}
