using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Shapes
{
    public abstract class Shape
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public void MoveX(int units)
        {
            PositionX += units;
        }

        public void MoveY(int units)
        {
            PositionY += units;
        }
    }
}
