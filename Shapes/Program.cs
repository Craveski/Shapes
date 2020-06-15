using Shapes.Shapes;
using System;
using System.IO;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read in file data
            var fileData = ReadTextFile();
            //Identify shape
            GetShapeAttributes(fileData);
            //Output file to directory
            OutputFile(fileData);
        }

        private static string[] ReadTextFile()
        {
            string[] fileInfo = File.ReadAllLines(@"C:\Users\Crave-Laptop\Documents\Shapes.txt");
            return fileInfo;
        }

        private static void GetShapeAttributes(string[] fileData)
        {
            int squareCount = 0;

            foreach (var item in fileData)
            {
                if (item.Contains("RECT"))
                {
                    char[] delimeters = { '(', ' ', ',', ' ', ' ', ')' };
                    string[] stringChunks = item.Split(delimeters);
                    var rectangle = new Rectangle()
                    {
                        PositionX = Int32.Parse(stringChunks[1]),
                        PositionY = Int32.Parse(stringChunks[2]),
                        Width = Int32.Parse(stringChunks[4]),
                        Height = Int32.Parse(stringChunks[5]),
                    };

                    //Squares right
                    rectangle.PositionX = SquaresRight(rectangle.PositionX);

                    //All Up
                    rectangle.PositionY = Up2(rectangle.PositionY);

                    //All left
                    rectangle.PositionX = Left2(rectangle.PositionX);

                    if (squareCount == 0)
                    {
                        rectangle.Width = ConvertToRectangle(rectangle.Width);
                        squareCount++;
                    }
                }
                else if (item.Contains("CIRC"))
                {
                    char[] delimeters = { '(', ' ', ',', ' ', ')' };
                    string[] stringChunks = item.Split(delimeters);
                    var circle = new Circle()
                    {
                        PositionX = Int32.Parse(stringChunks[1]),
                        PositionY = Int32.Parse(stringChunks[2]),
                        Radius = Int32.Parse(stringChunks[4]),
                    };

                    //Increase Diameter
                    circle.Radius = IncreaseCircleDiameter(circle.Radius);

                    //All Up
                    circle.PositionY = Up2(circle.PositionY);

                    //All left
                    circle.PositionX = Left2(circle.PositionX);
                }
                else
                {
                    char[] delimeters = { '(', ' ', ',', ' ', ',', ' ', ' ', ')' };
                    string[] stringChunks = item.Split(delimeters);
                    var triangle = new Triangle()
                    {
                        TopXPosition = Int32.Parse(stringChunks[1]),
                        TopYPosition = Int32.Parse(stringChunks[2]),
                        RightXPosition = Int32.Parse(stringChunks[4]),
                        RightYPosition = Int32.Parse(stringChunks[5]),
                        LeftXPosition = Int32.Parse(stringChunks[7]),
                        LeftYPosition = Int32.Parse(stringChunks[8]),
                    };
                }
            }
        }

        private static void OutputFile(string[] fileData)
        {
            File.WriteAllLines(@"C:\Users\Crave-Laptop\Pictures\Shapes.txt", fileData);
        }

        //public double AreaCalculation(object shape)
        //{
        //    switch (shape)
        //    {
        //        case Rectangle r:
        //            return r.Height * r.Width;
        //        case Circle c:
        //            return c.Radius * c.Radius * Math.PI;
        //        //case Triangle t:
        //        //    return t.
        //        default:
        //            throw new ArgumentException("Shape does not fit any template");
        //    }
        //}

        private static int SquaresRight(int positionX)
        {
            return positionX + 5;
        }

        private static int IncreaseCircleDiameter(int radius)
        {
            return radius * 2;
        }

        private static int Up2(int positionY)
        {
            return positionY + 2;
        }

        private static int Left2(int positionX)
        {
            return positionX + 2;
        }

        private static void RotateTriangle()
        {

        }

        private static int ConvertToRectangle(int width)
        {
            return width * 2;
        }

    }
}
