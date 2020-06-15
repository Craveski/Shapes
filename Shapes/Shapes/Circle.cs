using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Shapes
{
    //X and Y from the base represents the center point of the circle.
    public class Circle : Shape
    {
        public int Radius { get; set; }

        public void UpdateRadius(int units)
        {
            this.Radius += units;
        }

        //public override string ToString()
        //{
        //    //Return data in correct format
        //    return $"CIRC({PositionX} {PositionY}, {Radius})";
        //}
    }
}
