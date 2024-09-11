using PushBox.GameMaps;
using PushBox.GamePlayer;
using PushBox.Stages;
using System.Runtime.CompilerServices;

namespace PushBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //读取配置文件
            StageController.Instance().ReadIni("stageInfos.json");
            StageController.Instance().ShowSelection();

            Renderer renderer = new Renderer();

            Console.CursorVisible = false;

            renderer.Render(MapController.Instance().CurrentMap, PlayerController.Instance().CurrentPlayer);
            while (true)
            {
                //1 获取用户输入
                Input input = InputTools.GetInput();

                //2 更新玩家位置
                PlayerController.Instance().Move(input);
                //player.Move(input, gameMap);

                //3 绘制
                renderer.Render(MapController.Instance().CurrentMap, PlayerController.Instance().CurrentPlayer);

                /*
                 * 某一次通关之后，GameMap对象当中的数据没有任何改变
                 * A1(OK) A2(OK) A3(OK) 
                 */
                if(StageController.Instance().CheckClear())
                {
                    Console.Clear();//1 清理当前屏幕 2 将cursor放在黑框开始的地方
                    Console.WriteLine("恭喜过关");

                    Console.ReadKey(true);//等待用户随便点击一个按键

                    StageController.Instance().ShowSelection();
                    renderer.Render(MapController.Instance().CurrentMap, PlayerController.Instance().CurrentPlayer);
                }
            }
        }
    }
}