using Shapes.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.IO
{
    interface IFileSystemIO
    {
        public List<Shape> ReadFromFile(string filePath);
        public void WriteToFile(string filePath, List<Shape> shapes);
    }
}
