
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LabWo3
{
    public class GamePresenter
    {
        private Form1 _view;
        private GameModel _model;
    
        private List<PictureBox> _playerFigures = new List<PictureBox>();
        private Label _playerInfoLabel;
        public PictureBox _boardPictureBox;
        public Graphics graphics;
        public GamePresenter(Form1 view, GameModel model)
        {

            _view = view;
            _model = model;
            LoadFromFile();

 
            InitializeBoardPictureBox();
            InitializePlayerFigures();
            UpdatePlayerPositions();
        }

        public void OnRollDiceButtonClick(object sender, EventArgs e)
        {   
            int steps = _model.RollDice();
            _model.NextPlayer();
            Proccess_movement(steps);
            _view.Fill_label($"Ходит {_model.Players[(_model.CurrentPlayerIndex + 1) % _model.Players.Count].Name}", $"Выпало число: {steps}");

        }

        public void Proccess_movement(int steps)
        {
            _model.MovePlayer(_model.Players[_model.CurrentPlayerIndex], steps);
            UpdatePlayerPositions();
            var cell = _model.Board[_model.Players[_model.CurrentPlayerIndex].Position];
            HandleCellEvent(cell, _model.Players[_model.CurrentPlayerIndex]);


        }
     
        public void InitializePlayerFigures()
        {
            for (int i = 0; i < _model.Players.Count; i++)
            {
                PictureBox playerFigure = new PictureBox
                {
                    Size = new Size(30, 30),
                    BackColor = _model.Players[i].Color,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = _model.Players[i]
                };

                _playerFigures.Add(playerFigure);
                _view.Add_Players(playerFigure);
             
            }
        }
        public void InitializeBoardPictureBox()
        {
            _boardPictureBox = new PictureBox
            {
                Size = new Size(1920, 1400),
                Location = new Point(0, 0),
                BackColor = Color.LightBlue,
            };

            _view.Add_BoardPictureBox(_boardPictureBox);
       
            DrawBoard();
        }

        private void UpdatePlayerPositions()
        {
      
            DrawBoard(); 
            
        }

        private void DrawBoard()
        {

            _boardPictureBox  = _view.Draw_Map(_boardPictureBox, _model.Board, _model.Players);

        }



               

        public void HandleCellEvent(Cell cell, Player currentPlayer)
        {
            const int fail = -4;
            const int luck = 3;

         

            switch (cell.Type)
            {
                case CellType.Forward:
                    _view.Annotate($"Ура! вы проходите на 3 клетки вперед!");
                    Proccess_movement(luck);
                    break;
                case CellType.Backward:
                    _view.Annotate($"Ой! вы проходите на 4 клетки назад!");
                    Proccess_movement(fail);
                    break;
                case CellType.Finish:
                    _view.Annotate($"Победил {currentPlayer.Name} !!!!");
                    _view.EndGame();
                    break;
               
            }
        }

        public void SaveGame()
        {
            GameState gameState = new GameState(_model.Board, _model.Players, _model.CurrentPlayerIndex);

            string exception = FileManagement.Save_to_file(gameState);
            if(exception.Length > 0)
            {
                _view.Annotate(exception);
            }
        }


        public void LoadFromFile()
        {
            GameState gameState;
            try
            {
                gameState = FileManagement.Get_from_file();
                _model.Board = gameState.Board;
                _model.Players = gameState.Players;
                _model.CurrentPlayerIndex = gameState.CurrentPlayerIndex;
            }
            catch (NullReferenceException)
            {
                _view.Annotate($"Создаем новую игру");
            }
        }








    }
}
