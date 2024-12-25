using SadConsole.Input;
using SadConsoleGame;

namespace RogueSharpTutorial.Library
{
    public class RootScreen : ScreenObject
    {
        private Map _map;

        public RootScreen()
        {
            _map = new Map(Game.Instance.ScreenCellsX, Game.Instance.ScreenCellsY - 5);
            
            Children.Add(_map.SurfaceObject);

        }

        public override bool ProcessKeyboard(Keyboard keyboard)
        {
            bool handled = false;

            if (keyboard.IsKeyPressed(Keys.Up))
            {
                if (_map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Up, _map.SurfaceObject))
                handled = true;
            }
            else if (keyboard.IsKeyPressed(Keys.Down))
            {
                if (_map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Down, _map.SurfaceObject))
                handled = true;
            }

            if (keyboard.IsKeyPressed(Keys.Left))
            {
                if(_map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Left, _map.SurfaceObject))
                handled = true;
            }
            else if (keyboard.IsKeyPressed(Keys.Right))
            {
                if(_map.UserControlledObject.Move(_map.UserControlledObject.Position + Direction.Right, _map.SurfaceObject))
                handled = true;
            }

            return handled;
        }
    }
}
