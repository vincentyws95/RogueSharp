namespace RogueSharpTutorial.System
{
    public class CommandSystem
    {
        //Return value is true if the player was able to move
        //false when the player couldnt move, such as trying to move into a wall
        public bool MovePlayer(Direction.Types direction)
        {
            int x = MyGame.Player.X;
            int y = MyGame.Player.Y;

            switch (direction)
            {
                case Direction.Types.Up:
                    {
                        y = MyGame.Player.Y - 1;
                        break;
                    }
                case Direction.Types.Down:
                    {
                        y = MyGame.Player.Y + 1;
                        break;
                    }
                case Direction.Types.Left:
                    {
                        x = MyGame.Player.X - 1;
                        break;
                    }
                case Direction.Types.Right:
                    {
                        x = MyGame.Player.X + 1;
                        break;
                    }
                default:
                    {
                        return false;
                    }
            }

            if (MyGame.DungeonMap.SetActorPosition(MyGame.Player, x, y))
            {
                return true;
            }

            return false;
        }
    }
}
