using PushBox.GameMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushBox.GamePlayer
{
    internal class Player
    {
        //构造方法（如果不强制player生成的时候传入初始位置，那么x y会默认为0）
        public Player(int x, int y, char avatar)
        {
            PosX = x;
            PosY = y;
            Avatar = avatar;
        }

        //x y 位置(习惯性使用属性的方式)
        public int PosX
        {
            get; set;
        }

        public int PosY
        {
            get; set;
        }

        //avatar玩家的形象
        public char Avatar
        {
            get; set;
        }
    }
}
