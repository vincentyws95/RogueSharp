using RogueSharpTutorial.Core;
using System.ComponentModel;
using SadConsole.Input;
using SadConsoleGame;
using Direction = SadRogue.Primitives.Direction;

namespace RogueSharpTutorial.Library
{
    public class RootScreen : ScreenObject
    {
        private DungeonMap _dungeonMap;
        private Console _messageConsole;
        private Console _statConsole;
        private Console _inventoryConsole;

        public RootScreen()
        {
            //_map = new Map(Game.Instance.ScreenCellsX, Game.Instance.ScreenCellsY - 5);

            //Map Console
            _dungeonMap = new DungeonMap(GameSettings.MAP_WIDTH, GameSettings.MAP_HEIGHT, Colors.FloorBackground, (1, GameSettings.INVENTORY_HEIGHT + 1));
            Children.Add(_dungeonMap.SurfaceObject);


            // Message console
            int startingPosition = GameSettings.INVENTORY_HEIGHT + GameSettings.MAP_HEIGHT + 1;
            _messageConsole = CreateConsole(GameSettings.MESSAGE_WIDTH, GameSettings.MESSAGE_HEIGHT, Colors.MessagesBackground, (1, startingPosition));
            _messageConsole.Print(1, 1, "Messages");

            Children.Add(_messageConsole);

            // Stat console
            _statConsole = CreateConsole(GameSettings.STAT_WIDTH, GameSettings.STAT_HEIGHT, Colors.StatsBackground, (GameSettings.INVENTORY_WIDTH + 1, 1));
            _statConsole.Print(1, 1, "Stats");

            Children.Add(_statConsole);

            // Inventory console
            _inventoryConsole = CreateConsole(GameSettings.INVENTORY_WIDTH, GameSettings.INVENTORY_HEIGHT, Colors.InventoryBackground, (1, 1));
            _inventoryConsole.Print(1, 1, "Inventory");

            Children.Add(_inventoryConsole);

        }

        public override bool ProcessKeyboard(Keyboard keyboard)
        {
            bool handled = false;
            Player player = MyGame.Player;

            if (keyboard.IsKeyPressed(Keys.Up))
            {
                if (player.Move(player.Position + Direction.Up, _dungeonMap))
                handled = true;
            }
            else if (keyboard.IsKeyPressed(Keys.Down))
            {
                if (player.Move(player.Position + Direction.Down, _dungeonMap))
                handled = true;
            }

            if (keyboard.IsKeyPressed(Keys.Left))
            {
                if(player.Move(player.Position + Direction.Left, _dungeonMap))
                handled = true;
            }
            else if (keyboard.IsKeyPressed(Keys.Right))
            {
                if(player.Move(player.Position + Direction.Right, _dungeonMap))
                handled = true;
            }

            return handled;
        }

        private static Console CreateConsole(int width, int height, Color backgroundColor, Point position)
        {
            Console console = new Console(width, height);
            console.Position = position;
            console.Surface.DefaultBackground = backgroundColor;
            console.Clear();
            console.UseMouse = false;
            //console.Cursor.Position = new Point(1, 2);
            //console.Cursor.IsEnabled = true;
            //console.FocusOnMouseClick = true;
            //console.MoveToFrontOnMouseClick = true;

            return console;
        }
    }
}
