using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushBox.GameMaps
{
    internal class GameMap
    {
        public GameMap()
        {
            InitMap();
        }

        public void InitMap()//initialize
        {
            Width = 9;
            Height = 9;

            int[,] mapInfoArr =
            {
                 { 1, 1, 1, 1, 1, 0, 0, 0, 0 },
                 { 1, 0, 0, 0, 1, 0, 0, 0, 0 },
                 { 1, 0, 2, 2, 1, 0, 1, 1, 1 },
                 { 1, 0, 2, 0, 1, 0, 1, 3, 1 },
                 { 1, 1, 1, 0, 1, 1, 1, 3, 1 },
                 { 0, 1, 1, 0, 0, 0, 0, 3, 1 },
                 { 0, 1, 0, 0, 0, 1, 0, 0, 1 },
                 { 0, 1, 0, 0, 0, 1, 1, 1, 1 },
                 { 0, 1, 1, 1, 1, 1, 0, 0, 0 },
            };

            //new出对应的存储数组
            StaticElements = new MapElement[9, 9];
            BoxElements = new MapElement[3];
            TargetElements = new MapElement[3];

            int boxCount = 0;//记录生成过多少个box了
            int targetCount = 0;//记录生成过多少个target了
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    switch (mapInfoArr[y, x])
                    {
                        case 0: StaticElements[y, x] = new MapEmpty(x, y, ' '); break;
                        case 1: StaticElements[y, x] = new MapBlock(x, y, '#'); break;
                        case 2:
                            {
                                //生成一个MapBox，放到BoxElements数组里面
                                BoxElements[boxCount] = new MapBox(x, y, '@');
                                boxCount++;
                                StaticElements[y, x] = new MapEmpty(x, y, ' ');
                                break;
                            }
                        case 3:
                            {
                                TargetElements[targetCount] = new MapTarget(x, y, 'A');
                                targetCount++;
                                StaticElements[y, x] = new MapEmpty(x, y, ' ');
                                break;
                            }
                    }
                }
            }
        }

        public void CreateMapElements(int[,] mapInfos, int width, int height)
        {
            int boxCount = 0;//记录生成过多少个box了
            int targetCount = 0;//记录生成过多少个target了
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    switch (mapInfos[y, x])
                    {
                        case 0: StaticElements[y, x] = new MapEmpty(x, y, ' '); break;
                        case 1: StaticElements[y, x] = new MapBlock(x, y, '#'); break;
                        case 2:
                            {
                                //生成一个MapBox，放到BoxElements数组里面
                                BoxElements[boxCount] = new MapBox(x, y, '@');
                                boxCount++;
                                StaticElements[y, x] = new MapEmpty(x, y, ' ');
                                break;
                            }
                        case 3:
                            {
                                TargetElements[targetCount] = new MapTarget(x, y, 'A');
                                targetCount++;
                                StaticElements[y, x] = new MapEmpty(x, y, ' ');
                                break;
                            }
                    }
                }
            }
        }

        //长度/宽度
        public int Width { get; set; }
        public int Height { get; set; }

        //1 静态地图元素（围墙、空白元素）
        public MapElement[,] StaticElements { get; set; }

        //2 箱子元素构成数组
        public MapElement[] BoxElements { get; set; }

        //3 目标元素构成数组
        public MapElement[] TargetElements { get; set; }
    }
}
