using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushBox
{
    static class APITools
    {
        public static void Draw(int x, int y, char avatar)
        {
            Console.CursorLeft= x;
            Console.CursorTop= y;
            Console.Write(avatar);
        }
    }
}
