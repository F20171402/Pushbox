using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushBox.GameMaps
{
    abstract class MapElement
    {
        public MapElement(int x, int y, char avatar)
        {
            PosX = x;
            PosY = y;
            Avatar = avatar;
        }

        //x y 位置
        public int PosX { get; set; }
        public int PosY { get; set; }

        //avatar
        public char Avatar { get; set; }
    }
}
