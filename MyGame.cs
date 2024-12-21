using SadConsole.Configuration;

namespace RogueSharpTutorial
{
    public class MyGame
    {

        public static void Main()
        {

        Settings.WindowTitle = "RogueSharp Tutorial - Level 1";

        Builder configuration = new Builder()
                .SetScreenSize(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT)
                .OnStart(Startup);

        Game.Create(configuration);
        Game.Instance.Run();
        Game.Instance.Dispose();
        }

        private static void Startup(object? sender, GameHost host)
        {
            //screen object is an empty container
            var container = new ScreenObject();

            Game.Instance.Screen = container;

            //Map Console
            Console mapConsole = new(GameSettings.MAP_WIDTH, GameSettings.MAP_HEIGHT);
            mapConsole.Position = (1, GameSettings.INVENTORY_HEIGHT + 1);
            mapConsole.Surface.DefaultBackground = Color.Black;
            mapConsole.Clear();
            mapConsole.Cursor.IsEnabled = true;
            mapConsole.Cursor.MouseClickReposition = true;
            mapConsole.MoveToFrontOnMouseClick = true;
            mapConsole.FocusOnMouseClick = true;
            mapConsole.Print(1, 1, "Map");

            container.Children.Add(mapConsole);

            // Message console
            int startingPosition = GameSettings.INVENTORY_HEIGHT + GameSettings.MAP_HEIGHT + 1;
            Console messageConsole = new Console(GameSettings.MESSAGE_WIDTH, GameSettings.MESSAGE_HEIGHT);
            messageConsole.Position = new Point(1, startingPosition);
            messageConsole.Surface.DefaultBackground = Color.Gray;
            messageConsole.Clear();
            messageConsole.Cursor.Position = new Point(1, 2);
            messageConsole.Cursor.IsEnabled = true;
            messageConsole.FocusOnMouseClick = true;
            messageConsole.MoveToFrontOnMouseClick = true;
            messageConsole.Print(1, 1, "Messages");

            container.Children.Add(messageConsole);
            container.Children.MoveToBottom(messageConsole);

            // Stat console
            Console statConsole = new Console(GameSettings.STAT_WIDTH, GameSettings.STAT_HEIGHT);
            startingPosition = GameSettings.INVENTORY_WIDTH+1;
            statConsole.Position = new Point(startingPosition, 1);
            statConsole.Surface.DefaultBackground = Color.SandyBrown;
            statConsole.Clear();
            statConsole.Cursor.Position = new Point(1, 2);
            statConsole.Cursor.IsEnabled = true;
            statConsole.FocusOnMouseClick = true;
            statConsole.MoveToFrontOnMouseClick = true;
            statConsole.Print(1, 1, "Stats");


            container.Children.Add(statConsole);
            container.Children.MoveToBottom(statConsole);

            // Inventory console
            Console inventoryConsole = new Console(GameSettings.INVENTORY_WIDTH, GameSettings.INVENTORY_HEIGHT);
            inventoryConsole.Position = new Point(1, 1);
            inventoryConsole.Surface.DefaultBackground = Color.DarkCyan;
            inventoryConsole.Clear();
            inventoryConsole.Cursor.Position = new Point(1, 2);
            inventoryConsole.Cursor.IsEnabled = true;
            inventoryConsole.FocusOnMouseClick = true;
            inventoryConsole.MoveToFrontOnMouseClick = true;
            inventoryConsole.Print(1, 1, "Inventory");


            container.Children.Add(inventoryConsole);
            container.Children.MoveToBottom(inventoryConsole);

        }

    }
}
