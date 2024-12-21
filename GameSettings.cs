using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueSharpTutorial
{
    static class GameSettings
    {
        private const int BASE_UNIT = 15;

        public const int GAME_WIDTH = BASE_UNIT * 11;
        public const int GAME_HEIGHT = BASE_UNIT * 5;

        public const int INVENTORY_WIDTH = BASE_UNIT * 9;
        public const int INVENTORY_HEIGHT = BASE_UNIT ;

        public const int MAP_WIDTH = BASE_UNIT * 9;
        public const int MAP_HEIGHT = BASE_UNIT * 3; 
        
        public const int MESSAGE_WIDTH = BASE_UNIT * 9;
        public const int MESSAGE_HEIGHT = BASE_UNIT;

        public const int STAT_WIDTH = BASE_UNIT * 2;
        public const int STAT_HEIGHT = BASE_UNIT * 7;

    }
}
