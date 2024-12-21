using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueSharpTutorial.Core
{
    internal class Colors
    {
        public static Color FloorBackground = Color.Black;
        public static Color Floor = new Color(71, 62, 45);
        public static Color FloorBackgroundFov = new Color(71, 62, 45);
        public static Color FloorFov = new Color(129, 121, 107);

        public static Color WallBackground = new Color(31, 38, 47);
        public static Color Wall = new Color(72, 77, 85);
        public static Color WallBackgroundFov = new Color(51, 56, 64);
        public static Color WallFov = new Color(93, 97, 105);

        public static Color TextHeading = new Color(222, 238, 214);
        public static Color StatsBackground = new Color(78, 74, 78);
        public static Color MessagesBackground = new Color(48, 52, 109);
        public static Color InventoryBackground = new Color(133, 76, 48);
    }
}
