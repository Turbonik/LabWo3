using LabWo3.WindowsFormsApp2;
using LabWo3;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using LabWo3;

[Serializable]
public class GameState
{
    public List<Cell> Board { get; set; }
    public List<Player> Players { get; set; }
    public int CurrentPlayerIndex { get; set; }

    public GameState() { }

    public GameState(List<Cell> c, List<Player> p, int i)
    {
        Board = c;
        Players = p;
        CurrentPlayerIndex = i;
    }
}