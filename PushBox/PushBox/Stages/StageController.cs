using PushBox.GameMaps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PushBox.GamePlayer;

namespace PushBox.Stages
{
    internal class StageController
    {
        private static StageController instance = new StageController();
        public static StageController Instance()
        {
            return instance;
        }
        private StageController() { }

        //读取关卡配置文件后，生成的关卡信息数组
        private StageInfo[] stageInfos = null;

        //读取配置文件并且将读取的配置文件，反序列化为stageInfos数组
        public void ReadIni(string path)
        {
            string jsonStr = File.ReadAllText(path);
            stageInfos = JsonConvert.DeserializeObject<StageInfo[]>(jsonStr);
        }

        //用来开启第id个关卡,如果数组当中存在第id个关卡，则正常开启，返回true
        //如果数组当中不存在第id个关卡，则返回false
        public bool StartStage(int id)
        {
            if (id >= stageInfos.Length)
            {
                return false;
            }

            //1 根据id,取出对应关卡的信息
            StageInfo stageInfo = stageInfos[id];

            //2 初始化玩家信息
            Player player = new Player(stageInfo.PlayerX, stageInfo.PlayerY, '&');
            PlayerController.Instance().CurrentPlayer = player;

            //3 初始化地图信息
            int[,] mapInfos = stageInfo.Elements;
            int width = stageInfo.Width;
            int height = stageInfo.Height;
            int boxCount = stageInfo.BoxCount;

            GameMap map = new GameMap();
            MapController.Instance().CurrentMap = map;
            map.Width = width;
            map.Height = height;

            //3.1 初始化地图中各类存储数组的空间
            map.StaticElements = new MapElement[height, width];
            map.BoxElements = new MapElement[boxCount];
            map.TargetElements = new MapElement[boxCount];

            //3.2 根据 mapinfos 记录的地图数据（0123），生成对应的mapElement对象
            map.CreateMapElements(mapInfos, width, height);

            return true;
        }

        public void ShowSelection()
        {
            //1 清理屏幕，显示光标
            Console.Clear();
            Console.CursorVisible = true;

            //2 打印关卡名字 +  欢迎信息
            Console.WriteLine("*****************欢迎来到推箱子的世界*****************");
            for (int i = 0; i < stageInfos.Length; i++)
            {
                Console.WriteLine($"{i + 1}" + stageInfos[i].Name);
            }

            //3 准备变量
            int selection = 0;//记录用户具体选择了哪个关卡
            bool selectionOver = false;//记录用户是否按下了enter键

            //4 光标归为，移动到第一个关卡的id号上
            Console.CursorTop = 1;

            //5 循环获取用户输入，直到用户点击了enter键（回车）为止
            while (true)
            {
                Input input = InputTools.GetInput();
                switch (input)
                {
                    case Input.UP:
                        {
                            if (selection > 0)
                            {
                                selection--;
                                Console.CursorTop--;
                            }
                        }
                        break;
                    case Input.DOWN:
                        {
                            //如果有5个关卡 Length = 5
                            //4
                            //01234
                            if (selection < stageInfos.Length - 1)
                            {
                                selection++;
                                Console.CursorTop++;
                            }
                        }
                        break;

                    case Input.ENTER:
                        {
                            selectionOver = true;
                        }
                        break;
                }

                if (selectionOver)
                {
                    break;
                }
            }
            //循环结束之后，selection变量当中存储着用户当前选择的关卡id（0 - length-1）

            //6 清理屏幕，隐藏光标
            Console.Clear();
            Console.CursorVisible = false;

            //7 开启关卡
            StartStage(selection);
        }

        //游戏通关规则：每一个目标上面，都覆盖了一个箱子
        public bool CheckClear()
        {
            //1 从当前地图对象当中，取出来目标数组/箱子数组
            GameMap map = MapController.Instance().CurrentMap;
            MapElement[] targetElements = map.TargetElements;
            MapElement[] boxElements = map.BoxElements;

            //2 遍历目标数组，查看每个目标上是否都覆盖了一个箱子
            bool flag = false;

            //A1(OK) A2 A3
            foreach (MapElement target in targetElements)
            {
                flag = false;

                //遍历每一个boxElements里面的元素，查看有没有覆盖在target上面的box
                foreach (MapElement box in boxElements)
                {
                    if (box.PosX == target.PosX && box.PosY == target.PosY)
                    {
                        flag = true;
                        break;
                    }
                }

                //检查flag，看下有没有某个box覆盖了当前的target
                if (!flag)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
