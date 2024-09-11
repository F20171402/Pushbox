using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushBox.GameMaps
{
    //地图上的空元素
    internal class MapEmpty:MapElement
    {
        public MapEmpty(int x, int y, char avatar):base(x, y, avatar)
        {

        }
    }
}
