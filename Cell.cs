using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;


    namespace LabWo3
    {
        public enum CellType
        {
            Start, Simple, Forward, Backward, Finish
        }

        public class Cell
        {
            public string Name { get; set; }
            public CellType Type { get; set; }
            public Rectangle Bounds { get; set; }
            public Color Color { get; set; }
            public Cell(string name, CellType type, Rectangle bounds, Color color)
            {
                Name = name;
                Type = type;
                Bounds = bounds;
                Color = color;
            }


        }
    }
