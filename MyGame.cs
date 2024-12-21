namespace RogueSharpTutorial
{
    public class MyGame
    {

        public static void Main()
        {

        Settings.WindowTitle = "RogueSharp Tutorial - Level 1";
    
        Game.Create(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT, Startup);
        Game.Instance.Run();
        Game.Instance.Dispose();
        }

        private static void Startup(object? sender, GameHost host)
        {
            Console startingConsole = Game.Instance.StartingConsole!;

            startingConsole.Print(5, 5, "Welcome to RogueSharp using SadConsole !", Color.White);
        }

    }
}
