using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushBox.GameMaps
{
    //当作箱子的地图元素
    internal class MapBox:MapElement
    {
        public MapBox(int x, int y, char avatar):base(x, y, avatar) { }
    }
}
