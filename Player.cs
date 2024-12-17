using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWo3
{
    public class Player
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public Rectangle FigureBounds { get; set; }
        public Color Color { get; set; }
        public Player(string name, Color color)
        {
            Name = name;
            Position = 0;
            Color = color;
        }
    }
}
