using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushBox.GameMaps
{
    internal class MapController
    {
        static private MapController instance = new MapController();
        public static MapController Instance()
        {
            return instance;
        }

        private MapController() { }

        public GameMap CurrentMap { get; set; }

        //侦测玩家移动是否成功
        public bool CheckMove(Input input, int x, int y)
        {
            var staticElements = CurrentMap.StaticElements;
            var boxElements = CurrentMap.BoxElements;

            //1 最新的xy位置上有没有MapBlock（围墙）
            if (staticElements[y, x] is MapBlock)
            {
                return false;
            }

            //2 最新的xy位置上有没有MapBox（箱子）
            for (int i = 0; i < boxElements.Length; i++)
            {
                //2.1 检查有没有箱子在xy位置上
                if (boxElements[i].PosX == x && boxElements[i].PosY == y)
                {
                    //2.2如果找了一个箱子，正好在xy位置上，判断本箱子是否可以被推动
                    MapElement box = boxElements[i];

                    //a.需要知道往哪个方向推动box
                    //b.推动箱子之后，获得箱子最新的位置
                    int oldx = box.PosX, oldy = box.PosY;
                    switch (input)
                    {
                        case Input.UP: box.PosY--; break;
                        case Input.DOWN: box.PosY++; break;
                        case Input.LEFT: box.PosX--; break;
                        case Input.RIGHT: box.PosX++; break;
                    }

                    //c.最新箱子的位置上，有没有MapBlock或者其他箱子
                    //检测box最新位置上有没有MapBlock
                    if (staticElements[box.PosY, box.PosX] is MapBlock)
                    {
                        //如果无法推动箱子，则回退到原来的位置
                        box.PosX = oldx;
                        box.PosY = oldy;
                        return false;
                    }
                    //检测box最新位置上有没有其他的box
                    foreach (MapElement m in boxElements)
                    {
                        //对象之间判断是否相等，如果二者指向同一个堆内存，则相等，否则不相等
                        if (m != box)
                        {
                            if (m.PosX == box.PosX && m.PosY == box.PosY)
                            {
                                box.PosX = oldx;
                                box.PosY = oldy;
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
}
