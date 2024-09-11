using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushBox.GameMaps
{
    //地图上的围墙元素
    internal class MapBlock : MapElement
    {
        public MapBlock(int x, int y, char avatar) : base(x, y, avatar)
        { }
    }
}
