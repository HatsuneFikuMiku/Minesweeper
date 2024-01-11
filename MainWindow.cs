using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaperV2
{
    public partial class MainWindow : Form
    {
        Board board;
        public CounterButton counterButton;
        int difficulty = -1;
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            counterButton = new CounterButton(this, 0);
            board = new Board(this, GamePanel, counterButton);
        }

        private void EasyDifficulty(object sender, EventArgs e)
        {
            difficulty= 0;
            board.StartGame(difficulty);
        }

        private void NormalDifficulty(object sender, EventArgs e)
        {
            difficulty= 1;
            board.StartGame(difficulty);
        }

        private void HardDifficulty(object sender, EventArgs e)
        {
            difficulty= 2;
            board.StartGame(difficulty);
        }

        private void Reset(object sender, EventArgs e)
        {
            if(difficulty!=-1)
                board.StartGame(difficulty);
        }

        private void WindowSizeChanged(object sender, EventArgs e)
        {
            if (difficulty!=-1)
                board.ChangeTileSizes();
        }
    }
}
