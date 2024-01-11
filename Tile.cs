using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SaperV2
{ 
    internal class Tile : Button
    {   
        //This class is used for the visual and initial setup of a tile
        //Events and tile logic are written in GameLogic static class

        public int x;
        public int y;
        private int size;
        public int value;
        public bool is_enabled = true;
        public Board parent_board;

        public Tile(int x, int y, Board board)
        {
            this.x = x;
            this.y = y;
            this.parent_board = board;
            this.Name = x.ToString() + ":" + y.ToString();
            this.Text = "";
            this.Font = new Font(this.Font.FontFamily, 12f);
            value = 0;

            this.MouseUp += GameLogic.TileClicked;
        }
        public void SetTileLocation(int x, int y)
        {
            this.Location = new Point(x, y);
        }

        public void SetTileSize(int tile_size)
        {
            this.Size = new Size(tile_size, tile_size);
        }

        public void ChangeTileColor()
        {
            switch (value)
            {
                case 0:
                    this.ForeColor = Color.Black;
                    break;
                case 1:
                    this.ForeColor = Color.Blue;
                    break;
                case 2:
                    this.ForeColor = Color.Green;
                    break;
                case 3:
                    this.ForeColor = Color.Red;
                    break;
                case 4:
                    this.ForeColor = Color.Purple;
                    break;
                case 5:
                    this.ForeColor = Color.Orange;
                    break;
                case 6:
                    this.ForeColor = Color.Brown;
                    break;
                case 7:
                    this.ForeColor = Color.DarkCyan;
                    break;
                case 8:
                    this.ForeColor = Color.DarkGray;
                    break;
            }
        }

    }
}
