using PushBox.GameMaps;
using PushBox.GamePlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushBox
{
    internal class Renderer
    {
        public Renderer() { }

        public void Render(GameMap gameMap, Player player)
        {
            int width = gameMap.Width;
            int height = gameMap.Height;

            MapElement[,] staticElements = gameMap.StaticElements;
            MapElement[] boxElements = gameMap.BoxElements;
            MapElement[] targetElements = gameMap.TargetElements;

            //1 绘制静态地图元素
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    APITools.Draw(staticElements[y, x].PosX, staticElements[y, x].PosY, staticElements[y, x].Avatar);
                    //staticElements[y, x].Draw();
                }
            }

            //2 目标地图元素
            for (int i = 0; i < targetElements.Length; i++)
            {
                APITools.Draw(targetElements[i].PosX, targetElements[i].PosY, targetElements[i].Avatar);
            }

            //3 箱子地图元素
            for (int i = 0; i < boxElements.Length; i++)
            {
                APITools.Draw(boxElements[i].PosX, boxElements[i].PosY, boxElements[i].Avatar);
            }

            //4 绘制玩家
            APITools.Draw(player.PosX, player.PosY, player.Avatar);
            //player.Draw();
        }
    }
}
