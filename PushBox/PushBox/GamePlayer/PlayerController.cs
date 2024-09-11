using PushBox.GameMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushBox.GamePlayer
{
    //单例类
    internal class PlayerController
    {
        static private PlayerController instance = new PlayerController();
        public static PlayerController Instance()
        {
            return instance;
        }
        private PlayerController() { }

        public Player CurrentPlayer { get; set; }

        //move：根据键盘输入来决定移动玩家的位置
        public void Move(Input input)
        {
            //记录旧的玩家位置
            int oldx = CurrentPlayer.PosX, oldy = CurrentPlayer.PosY;

            switch (input)
            {
                case Input.UP:      CurrentPlayer.PosY--; break;
                case Input.DOWN:    CurrentPlayer.PosY++; break;
                case Input.LEFT:    CurrentPlayer.PosX--; break;
                case Input.RIGHT:   CurrentPlayer.PosX++; break;
                default: break;
            }

            //检查玩家是否可以移动到对应位置
            if (!MapController.Instance().CheckMove(input, CurrentPlayer.PosX, CurrentPlayer.PosY))
            {
                //如果玩家无法移动到最新的xy位置，将玩家回退到之前的位置
                CurrentPlayer.PosX = oldx;
                CurrentPlayer.PosY = oldy;
            }
        }
    }
}
