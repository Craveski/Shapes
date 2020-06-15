using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Shapes
{
    //X and Y from the base represents the top left point of the rectangle.
    public class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
