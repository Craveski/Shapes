using Shapes.IO;
using Shapes.Shapes;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace Shapes
{
    public class Program
    {
        IFileSystemIO FileSystemIO;
        static void Main(string[] args)
        {
            Program program = new Program();

            program.RunProgram();
        }

        public void RunProgram()
        {
            this.FileSystemIO = new TextFileIO();

            var shapes = FileSystemIO.ReadFromFile(@"C:\Users\Crave-Laptop\Documents\Shapes.txt");

            var rectangles = shapes.OfType<Rectangle>().ToList();

            int count = 0;

            foreach (var shape in shapes)
            {
                //1. Move all squares 5 units to the right
                if (shape.GetType() == typeof(Rectangle))
                {
                    shape.MoveX(5);
                }
                //2. Increase the diameter of all circles by 2 units
                if (shape.GetType() == typeof(Circle))
                {
                    ((Circle)shape).UpdateRadius(2);
                }
                //3. Move all shapes 2 units up, and 2 units to the left
                shape.MoveX(-2);
                shape.MoveY(-2);

                //4. Rotate the triangle 45° clockwise around its centre
                //Not sure

                if (count == 0)
                {
                    //5. Double the width of the left-most square, turning it into a rectangle
                    var leftSquare = rectangles.OrderBy(shape => shape.PositionX).FirstOrDefault();
                    leftSquare.Width *= 2;

                    count++;
                }
            }
            //6. Write to file
            FileSystemIO.WriteToFile(@"C:\Users\Crave-Laptop\Pictures\Shapes.txt", shapes);
        }
    }
}
