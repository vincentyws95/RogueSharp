using RogueSharpTutorial.Core;
using RogueSharpTutorial.Library;
using RogueSharpTutorial.System;
using SadConsole.Configuration;
using SadConsole.Input;

namespace RogueSharpTutorial
{
    public class MyGame
    {
        public static DungeonMap DungeonMap { get; private set; }
        public static Player Player { get; private set; }

        private static bool _renderRequired = false;
        public static CommandSystem CommandSystem { get; private set; }

        public static void Main()
        {
            Settings.WindowTitle = "RogueSharp Tutorial - Level 1";

            //Builder configuration = new Builder()
            //        .SetScreenSize(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT)
            //        .OnStart(Startup);
                Builder configuration = new Builder()
            .SetScreenSize(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT)
            .SetStartingScreen<RootScreen>()
            .IsStartingScreenFocused(true);


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
            Console mapConsole = CreateConsole(GameSettings.MAP_WIDTH, GameSettings.MAP_HEIGHT, Colors.FloorBackground, (1, GameSettings.INVENTORY_HEIGHT + 1));
            container.Children.Add(mapConsole);

            // Message console
            int startingPosition = GameSettings.INVENTORY_HEIGHT + GameSettings.MAP_HEIGHT + 1;
            Console messageConsole = CreateConsole(GameSettings.MESSAGE_WIDTH, GameSettings.MESSAGE_HEIGHT, Colors.MessagesBackground, (1, startingPosition));
            messageConsole.Print(1, 1, "Messages");

            container.Children.Add(messageConsole);

            // Stat console
            Console statConsole = CreateConsole(GameSettings.STAT_WIDTH, GameSettings.STAT_HEIGHT, Colors.StatsBackground, (GameSettings.INVENTORY_WIDTH + 1, 1));
            statConsole.Print(1, 1, "Stats");

            container.Children.Add(statConsole);

            // Inventory console
            Console inventoryConsole = CreateConsole(GameSettings.INVENTORY_WIDTH, GameSettings.INVENTORY_HEIGHT, Colors.InventoryBackground, (1, 1));
            inventoryConsole.Print(1, 1, "Inventory");

            container.Children.Add(inventoryConsole);

            LevelInitializing(mapConsole);
        }

        private static Console CreateConsole(int width, int height, Color backgroundColor, Point position)
        {
            Console console = new Console(width, height);
            console.Position = position;
            console.Surface.DefaultBackground = backgroundColor;
            console.Clear();
            console.Cursor.Position = new Point(1, 2);
            console.Cursor.IsEnabled = true;
            console.FocusOnMouseClick = true;
            console.MoveToFrontOnMouseClick = true;

            return console;
        }


        private static void LevelInitializing(Console mapConsole)
        {
            //Dungeon Map initialization
            MapGenerator mapGenerator = new MapGenerator(GameSettings.MAP_WIDTH, GameSettings.MAP_HEIGHT);
            DungeonMap = mapGenerator.CreateMap();

            //Player initialization
            Player = new Player();

            DungeonMap.UpdatePlayerFieldOfView();
            DungeonMap.Draw(mapConsole);
            Player.Draw(mapConsole, DungeonMap);

            //Command System
            CommandSystem = new CommandSystem();

        }

        
    }
}
