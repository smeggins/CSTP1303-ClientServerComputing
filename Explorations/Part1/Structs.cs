using System;
using System.Collections.Generic;
using System.Text;

namespace Explorations.Part1
{
    class Structs
    {
        public struct Point
        {
            int x;
            int y;

            public Point (int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            void makePoint()
            {
                Point p1 = new Point(1, 12);
            }
        }
    }
}
