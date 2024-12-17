using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private GamePresenter _presenter;

        public event EventHandler<EventArgs> RollDiceButtonClick;
        public void Fill_label(string text1, string text2)
        {
            this.Action_Description.Text = text1;
            this.Action_Description2.Text = text2;
        }
        public Form1()
        {
            GameModel model;
            InitializeComponent();

            model = new GameModel();
            _presenter = new GamePresenter(this, model);

        }
        private void rollDiceButtonClick(object sender, EventArgs e)
        {
            _presenter.OnRollDiceButtonClick(sender, e);

        }

        public PictureBox Draw_Map(PictureBox _boardPictureBox, List<Cell> board, List<Player> players)
        {
            Bitmap bmp = new Bitmap(_boardPictureBox.Width, _boardPictureBox.Height);
            Graphics graphics = Graphics.FromImage(bmp);

            using (graphics)
            {


                foreach (Cell cell in board)
                {
                    graphics.FillRectangle(new SolidBrush(cell.Color), cell.Bounds);
                    graphics.DrawRectangle(Pens.Black, cell.Bounds);

                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        graphics.DrawString(cell.Name, Font, Brushes.Black, cell.Bounds, sf);
                    }

                }


                int dif = 0;
                foreach (var player in players)
                {

                    var cell = board[player.Position];

                    var playerBounds = new Rectangle(cell.Bounds.X + 5, cell.Bounds.Y + 5 + dif, 20, 20);
                    player.FigureBounds = playerBounds;
                    graphics.FillRectangle(new SolidBrush(player.Color), player.FigureBounds);

                    dif += 25;
                }


            }
            if (true)
            {
                _boardPictureBox.Image = bmp;
            }
            return _boardPictureBox;
        }




        public Image Draw_Players(List<Player> players, List<Cell> board, PictureBox _boardPictureBox)
        {
            Bitmap bmp = new Bitmap(_boardPictureBox.Width, _boardPictureBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {

                int dif = 0;
                foreach (var player in players)
                {

                    var cell = board[player.Position];

                    var playerBounds = new Rectangle(cell.Bounds.X + 5, cell.Bounds.Y + 5 + dif, 20, 20);
                    player.FigureBounds = playerBounds;
                    g.FillRectangle(new SolidBrush(player.Color), player.FigureBounds);
                    dif += 25;
                }
            }
            _boardPictureBox.Image = bmp;
            return _boardPictureBox.Image;
        }

        public void Annotate(string message)
        {
            MessageBox.Show(message);
        }
        public void Add_Players(PictureBox playerFigure)
        {
            Controls.Add(playerFigure);
        }

        public void Add_BoardPictureBox(PictureBox _boardPictureBox)
        {
            Controls.Add(_boardPictureBox);
        }

        public void EndGame()
        {
            FileManagement.Clear_File();
            this.Close();
        }
private void exitgame_Click(object sender, EventArgs e)
        {
            _presenter.SaveGame();
            this.Close();
        }
    }
}
