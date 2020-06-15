using Shapes.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Shapes.IO
{
    public class TextFileIO : IFileSystemIO
    {
        public List<Shape> ReadFromFile(string filePath)
        {
            string[] fileContents = ReadFile(filePath);
            var shapes = ParseShapes(fileContents);

            return shapes;
        }

        public void WriteToFile(string filePath, List<Shape> shapes)
        {
            using (StreamWriter s = new StreamWriter(filePath, false))
            {
                foreach (var shape in shapes)
                {
                    if (shape.GetType() == typeof(Circle))
                    {
                        s.WriteLine($"CIRC({shape.PositionX} {shape.PositionY}, {((Circle)shape).Radius})");
                    }
                    else if (shape.GetType() == typeof(Rectangle))
                    {
                        s.WriteLine($"RECT({shape.PositionX} {shape.PositionY}, {((Rectangle)shape).Width} {((Rectangle)shape).Height})");
                    }
                    else
                    {
                        s.WriteLine($"TRIA({shape.PositionX} {shape.PositionY}, {((Triangle)shape).PositionX2} {((Triangle)shape).PositionY2}, {((Triangle)shape).PositionX3} {((Triangle)shape).PositionY3})");
                    }
                }
            }
        }

        private string[] ReadFile(string filePath)
        {
            string[] fileInfo = File.ReadAllLines(filePath);
            return fileInfo;
        }

        private List<Shape> ParseShapes(string[] fileData)
        {
            List<Shape> shapes = new List<Shape>();

            foreach (var item in fileData)
            {
                if (item.Contains("RECT"))
                {
                    string x = "Incorrect Format";
                    char[] delimeters = { '(', ' ', ',', ' ', ' ', ')' };
                    string[] stringChunks = item.Split(delimeters);
                    var rectangle = new Rectangle()
                    {
                        PositionX = Int32.Parse(stringChunks[1]),
                        PositionY = Int32.Parse(stringChunks[2]),
                        Width = Int32.Parse(stringChunks[4]),
                        Height = Int32.Parse(stringChunks[5]),
                    };

                    shapes.Add(rectangle);
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

                    shapes.Add(circle);
                }
                else if (item.Contains("TRIA"))
                {
                    char[] delimeters = { '(', ' ', ',', ' ', ',', ' ', ' ', ')' };
                    string[] stringChunks = item.Split(delimeters);
                    var triangle = new Triangle()
                    {
                        PositionX = Int32.Parse(stringChunks[1]),
                        PositionY = Int32.Parse(stringChunks[2]),
                        PositionX2 = Int32.Parse(stringChunks[4]),
                        PositionY2 = Int32.Parse(stringChunks[5]),
                        PositionX3 = Int32.Parse(stringChunks[7]),
                        PositionY3 = Int32.Parse(stringChunks[8]),
                    };

                    shapes.Add(triangle);
                }
                else
                {
                    Console.WriteLine("Unsupported Shape");
                }
            }
            return shapes;
        }
    }
}
