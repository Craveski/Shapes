using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Shapes
{
    //X and Y from the base represents the top point of the triangle.
    public class Triangle : Shape
    {
        public int PositionX2 { get; set; }
        public int PositionY2 { get; set; }
        public int PositionX3 { get; set; }
        public int PositionY3 { get; set; }
    }
}
