using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushBox.Stages
{
    internal class StageInfo
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int PlayerX { get; set; }
        public int PlayerY { get; set; }
        public int BoxCount { get; set; }
        public int[,] Elements { get; set; }
    }
}
