using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms.VisualStyles;

namespace LabWo3
{
    public class GameModel
    {
        public List<Cell> Board { get; set; } = new List<Cell>();
        public List<Player> Players { get; set; } = new List<Player>();
        public int CurrentPlayerIndex { get; set; } = -1;
        public Random Dice { get; set; } = new Random();
        public int[] MoveSequence;


        public GameModel()
        {
            InitializeBoard();
            InitializePlayers();
            InitializeMoveSequence();

        }


        private Color GetCellColor(CellType type)
        {
            switch (type)
            {
                case CellType.Start:
                    return Color.Green;
                case CellType.Forward:
                    return Color.LightGreen;
                case CellType.Backward:
                    return Color.Red;
                case CellType.Simple:
                    return Color.LightGray;
                case CellType.Finish:
                    return Color.Green;
                default: return Color.LightGray;
            }
        }

        public CellType GetRandomCellType(int r)
        {
            if (r >= 1 & r <= 80)
                return CellType.Simple;
            else if (r > 80 & r <= 90)
                return CellType.Forward;
            else if (r > 90 & r <= 100)
                return CellType.Backward;
            return CellType.Backward;
        }


        private void InitializeBoard()
        {
            int cellWidth = 80;
            int cellHeight = 80;
            CellType cellType;

            var random = new Random();

            Board.Add(new Cell("Старт", CellType.Start, new Rectangle(0, 0, cellWidth, cellHeight), GetCellColor(CellType.Start)));
            Board.Add(new Cell("", CellType.Simple, new Rectangle(0, cellHeight, cellWidth, cellHeight), GetCellColor(CellType.Simple)));
            Board.Add(new Cell("", CellType.Simple, new Rectangle(cellWidth, cellHeight, cellWidth, cellHeight), GetCellColor(CellType.Simple)));
            Board.Add(new Cell("", CellType.Simple, new Rectangle(cellWidth * 2, cellHeight, cellWidth, cellHeight), GetCellColor(CellType.Simple)));
            Board.Add(new Cell("", CellType.Simple, new Rectangle(cellWidth * 3, cellHeight, cellWidth, cellHeight), GetCellColor(CellType.Simple)));
            for (int i = 4; i < 10; i++)
            {
                cellType = GetRandomCellType(random.Next(1, 101));
                Board.Add(new Cell($"", cellType, new Rectangle(cellWidth * i, cellHeight, cellWidth, cellHeight), GetCellColor(cellType)));
            }
            for (int i = 1; i < 5; i++)
            {
                cellType = GetRandomCellType(random.Next(1, 101));
                Board.Add(new Cell($"", cellType, new Rectangle(cellWidth * 10, cellHeight * i, cellWidth, cellHeight), GetCellColor(cellType)));
            }
            for (int i = 1; i < 5; i++)
            {
                cellType = GetRandomCellType(random.Next(1, 101));
                Board.Add(new Cell($"", cellType, new Rectangle(cellWidth * (i + 10), cellHeight * 4, cellWidth, cellHeight), GetCellColor(cellType)));
            }
            for (int i = 1; i < 5; i++)
            {
                cellType = GetRandomCellType(random.Next(1, 101));
                Board.Add(new Cell($"", cellType, new Rectangle(cellWidth * 14, cellHeight * (i + 4), cellWidth, cellHeight), GetCellColor(cellType)));
            }
            for (int i = 1; i < 9; i++)
            {
                cellType = GetRandomCellType(random.Next(1, 101));
                Board.Add(new Cell($"", cellType, new Rectangle(cellWidth * (14 - i), cellHeight * 8, cellWidth, cellHeight), GetCellColor(cellType)));
            }
            for (int i = 1; i < 5; i++)
            {
                cellType = GetRandomCellType(random.Next(1, 101));
                Board.Add(new Cell($"", cellType, new Rectangle(cellWidth * 6, cellHeight * (8 - i), cellWidth, cellHeight), GetCellColor(cellType)));
            }
            for (int i = 1; i < 5; ++i)
            {
                cellType = GetRandomCellType();
            }

            Board.Add(new Cell($"Финиш", CellType.Finish, new Rectangle(cellWidth * 6, cellHeight * 3, cellWidth, cellHeight), GetCellColor(CellType.Finish)));



        }
        private void InitializePlayers()
        {
            Players.Add(new Player("Игрок 1", Color.White));
            Players.Add(new Player("Игрок 2", Color.Blue));
            Players.Add(new Player("Игрок 3", Color.Black));
        }


        public void NextPlayer()
        {
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % (Players.Count);
        }

        private void InitializeMoveSequence()
        {
            MoveSequence = new int[Board.Count];

            for (int i = 0; i < Board.Count; i++)
            {

                MoveSequence[i] = (i + 1);
            }

        }
        public int RollDice()
        {
            return Dice.Next(1, 7);
        }
        public void MovePlayer(Player player, int steps)
        {
            if (player.Position + steps >= MoveSequence.Count())
            {
                player.Position = MoveSequence.Count() - 1;
            }
            else if (steps >= 0)
            {
                for (int i = 0; i < steps; i++)
                {

                    player.Position = MoveSequence[player.Position];
                }
            }
            else
            {
                for (int i = 0; i < Math.Abs(steps); i++)
                {

                    player.Position = MoveSequence[player.Position - 1] - 1;
                }
            }
        }





    }
}
