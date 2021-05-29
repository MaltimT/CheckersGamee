using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckersGame
{
    public partial class Form1 : Form
    {
        const int sizeOfMap = 8;
        const int sizeOfCell = 50;
        int currentPlayer;
        Button previousMemorization;
        bool isMoving;
        int[,] map = new int[sizeOfMap, sizeOfMap];
        Button[,] btn = new Button[sizeOfMap, sizeOfMap];
        Image wchecker;
        Image bchecker;
        public Form1()
        {
            InitializeComponent();
            wchecker = new Bitmap(new Bitmap(@"C:\Users\Комп\Desktop\Tvorchestvo\MyProjects(Kit)\CheckersGame\CheckersGame\bin\Debug\Materials\white.png"), new Size(sizeOfCell - 10, sizeOfCell - 10));
            bchecker = new Bitmap(new Bitmap(@"C:\Users\Комп\Desktop\Tvorchestvo\MyProjects(Kit)\CheckersGame\CheckersGame\bin\Debug\Materials\black.png"), new Size(sizeOfCell - 10, sizeOfCell - 10));
            this.Text = "Checkers";
            Initialization();
        }

        public void Initialization()
        {

            currentPlayer = 1;
            isMoving = false;
            previousMemorization = null;
            map = new int[sizeOfMap, sizeOfMap]{
                {4,1,4,1,4,1,4,1 },
                {1,4,1,4,1,4,1,4 },
                {4,1,4,1,4,1,4,1 },
                {3,4,3,4,3,4,3,4 },
                {4,3,4,3,4,3,4,3 },
                {2,4,2,4,2,4,2,4 },
                {4,2,4,2,4,2,4,2 },
                {2,4,2,4,2,4,2,4 },
            };
            MapCreation();
        }

        public void MapCreation()
        {
            this.Width = (sizeOfMap + 1) * sizeOfCell;
            this.Height = (sizeOfMap + 1) * sizeOfCell;

            for (int i = 0; i < sizeOfMap; i++)
            {
                for (int j = 0; j < sizeOfMap; j++)
                {
                    Button Cell = new Button();
                    Cell.Location = new Point(j * sizeOfCell, i * sizeOfCell);
                    Cell.Size = new Size(sizeOfCell, sizeOfCell);
                    Cell.Click += new EventHandler(WhenCellPress);
                    if (map[i, j] == 1)
                    {
                        Cell.Image = wchecker;
                    }
                    else if (map[i, j] == 2)
                    {
                        Cell.Image = bchecker;
                    }
                    Cell.BackColor = GetColour(Cell);
                    this.Controls.Add(Cell);
                }
            }
        }
        public void SwitchPlayer()
        {
            currentPlayer = currentPlayer == 1 ? 2 : 1;
        }

        public Color GetColour(Button previousMemorization)
        {
            if ((previousMemorization.Location.Y / sizeOfCell % 2) != 0)
            {
                if ((previousMemorization.Location.X / sizeOfCell % 2) == 0)
                {
                    return Color.Black;
                }
            }
            if ((previousMemorization.Location.Y / sizeOfCell % 2) == 0)
            {
                if ((previousMemorization.Location.X / sizeOfCell % 2) != 0)
                {
                    return Color.Black;
                }
            }
            return Color.White;
        }

        public void WhenCellPress(object sender, EventArgs e)
        {
            if (previousMemorization != null)
            {
                previousMemorization.BackColor = GetColour(previousMemorization);
            }
            Button pressedButton = sender as Button;
            if (map[pressedButton.Location.Y / sizeOfCell, pressedButton.Location.X / sizeOfCell] != 0 && map[pressedButton.Location.Y / sizeOfCell, pressedButton.Location.X / sizeOfCell] == currentPlayer)
            {
                pressedButton.BackColor = Color.Yellow;
                isMoving = true;
            }
            else
            {
                if (isMoving)
                {
                    //if(map[pressedButton.Location.Y / sizeOfCell, pressedButton.Location.X / sizeOfCell] != 2 
                    //    && map[pressedButton.Location.Y / sizeOfCell, pressedButton.Location.X / sizeOfCell] != 1
                    //    && map[pressedButton.Location.Y / sizeOfCell, pressedButton.Location.X / sizeOfCell] != 4)
                    {

                            pressedButton.Image = previousMemorization.Image;
                            previousMemorization.Image = null;
                            isMoving = false;
                            SwitchPlayer();
                         //int temp = map[pressedButton.Location.Y / sizeOfCell, pressedButton.Location.X / sizeOfCell];
                        ////map[pressedButton.Location.Y / sizeOfCell, pressedButton.Location.X / sizeOfCell] = map[previousMemorization.Location.Y / sizeOfCell, previousMemorization.Location.X / sizeOfCell];
                        //map[pressedButton.Location.Y / sizeOfCell, pressedButton.Location.X / sizeOfCell] = temp;
                    }
                                   
                }
            }
            previousMemorization = pressedButton;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            btnRules.Visible = false;
            pnlBack.Visible = false;
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Доска 8х8, шашки занимают первые три ряда с каждой стороны; бить можно произвольное количество шашек в любых направлениях; простая ходит только вперед, но может бить назад, дамка может ходить на любое число полей; цель игры - съесть или запереть все шашки противника.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
