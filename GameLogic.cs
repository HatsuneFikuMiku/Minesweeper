using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaperV2
{
    internal static class GameLogic
    {
        //event handlers
        public static void OnFirstTurnHandler(object sender, EventArgs e)
        {
            BombAndTileValuesAssignment(((Board)sender).tiles, ((Board)sender).bombs, ((Board)sender).board_row_count, ((Board)sender).board_column_count);
        }
        public static void OnGameHasBeenWonHandler(object sender, EventArgs e)
        {
            GameHasBeenWon((Board)sender);
        }

        //board setup

        private static void BombAndTileValuesAssignment(List<List<Tile>> tiles, int bomb_count, int rows, int columns)
        {
            PlaceBombs(tiles, bomb_count, rows, columns);
            
            for(int x=0; x<rows; x++)
            {
                for(int y=0; y<columns; y++)
                {
                    if (tiles[x][y].value != -1)
                    {
                        tiles[x][y].value = CountSurroundingBombs(tiles,x, y, rows, columns);
                        tiles[x][y].ChangeTileColor();
                        //tiles[x][y].Text = tiles[x][y].value.ToString();
                    }
                }
            }
        }
        private static void PlaceBombs(List<List<Tile>> tiles, int bomb_count, int rows, int columns)
        {
            Random random= new Random();

            while(bomb_count > 0)
            {
                int x = random.Next(0, rows);
                int y = random.Next(0, columns);

                if (tiles[x][y].value != -1 && tiles[x][y].value != 1000)
                {
                    tiles[x][y].value = -1;
                    //tiles[x][y].Text = "*";
                    bomb_count--;
                }

            }
        }
        private static int CountSurroundingBombs(List<List<Tile>> tiles, int x, int y, int rows, int columns)
        {
            int value = 0;
            int start_x = Math.Max(0, x - 1);
            int end_x = Math.Min(rows - 1, x + 1);
            int start_y = Math.Max(0, y - 1);
            int end_y = Math.Min(columns - 1, y + 1);

            for (int i = start_x; i <= end_x; i++)
            {
                for (int j = start_y; j <= end_y; j++)
                {
                    if (tiles[i][j].value == -1)
                        value++;
                }
            }

            return value;
        }

        //****************************************************************************************************
        //Tile interactions management

        public static void TileClicked(object sender, MouseEventArgs e)
        {
            Tile tile = sender as Tile;
            Board board = tile.parent_board;

            if (!board.first_turn)
            {
                if (e.Button == MouseButtons.Left)
                {
                    TileLeftClicked(tile);
                    board.IsGameWon();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    TileRightClicked(tile);
                }
            }
            else if(e.Button == MouseButtons.Left)
            {
                int startX = Math.Max(0, tile.x - 1);
                int endX = Math.Min(board.board_row_count - 1, tile.x + 1);
                int startY = Math.Max(0, tile.y - 1);
                int endY = Math.Min(board.board_column_count - 1, tile.y + 1);

                for (int i = startX; i <= endX; i++)
                {
                    for (int j = startY; j <= endY; j++)
                    {
                        board.tiles[i][j].value = 1000;         //these tiles will be skiped when spawning bombs, so that every round begins with an empty tile
                    }
                }
                board.FirstTurn();
                board.first_turn = false;

                TileLeftClicked(tile);
                board.IsGameWon();
            }



        }
        private static void TileLeftClicked(Tile tile)
        {
            if (tile.is_enabled)
            {
                UncoverTile(tile);
            }
        }
        private static void TileRightClicked(Tile tile)
        {
            Board board = tile.parent_board;

            if (tile.is_enabled == true && board.ParentCounterButton.bomb_counter > 0)
            {
                tile.is_enabled = false;
                tile.ForeColor = Color.Red;
                tile.Text = "P";
                board.ParentCounterButton.bomb_counter--;
            }
            else if(tile.Text == "P")
            {
                tile.Text = "";
                tile.ChangeTileColor();
                tile.is_enabled = true;
                board.ParentCounterButton.bomb_counter++;
            }

            board.ParentCounterButton.UpdateCounter();
        }
        private static void UncoverTile(Tile tile)
        {
            if (tile.value == -1)
            {
                BombDetonated(tile.parent_board);
            }
            else if (tile.value == 0)
            {
                EmptyTileClicked(tile.parent_board, tile.x, tile.y);
            }
            else
            {
                tile.parent_board.tiles_required_for_victory--;
                tile.Text = tile.value.ToString();
                tile.BackColor = Color.LightGray;
                tile.is_enabled = false;
            }
        }
        private static void EmptyTileClicked(Board board, int x, int y)
        {
            int startX = Math.Max(0, x - 1);
            int endX = Math.Min(board.board_row_count - 1, x + 1);
            int startY = Math.Max(0, y - 1);
            int endY = Math.Min(board.board_column_count - 1, y + 1);

            for (int i = startX; i <= endX; i++)
            {
                for (int j = startY; j <= endY; j++)
                {
                    Tile tile = board.tiles[i][j];
                    CheckNeighbourTileValues(tile);
                }
            }
        }
        private static void CheckNeighbourTileValues(Tile tile)
        {
            Board board = tile.parent_board;

            if (tile.value != -1 && tile.Text == "P")
            {
                tile.is_enabled = true;
                tile.Text = "";
                tile.ChangeTileColor();
                board.ParentCounterButton.bomb_counter++;
                board.ParentCounterButton.UpdateCounter();
            }

            if (tile.is_enabled)
            {
                if(tile.value > 0)
                {
                    board.tiles_required_for_victory--;
                    tile.is_enabled = false;
                    tile.BackColor = Color.LightGray;
                    tile.Text = tile.value.ToString();
                }
                else if (tile.value == 0)
                {
                    board.tiles_required_for_victory--;
                    tile.is_enabled = false;
                    tile.BackColor = Color.LightGray;
                    EmptyTileClicked(board, tile.x, tile.y);
                }
            }
        }
        private static void BombDetonated(Board board)
        {
            foreach (var tile_row in board.tiles)
            {
                foreach (var tile in tile_row)
                {
                    if( tile.value == -1 && tile.Text == "P")
                    {
                        tile.BackColor = Color.LightSeaGreen;
                        tile.ForeColor = Color.Green;
                    }
                    else if(tile.value == -1)
                    {
                        tile.BackColor = Color.PaleVioletRed;
                        tile.Text = "*";
                    }
                    tile.MouseUp -= TileClicked;
                }
            }

            MessageBox.Show("You Lost!\nTiles for win left:" + board.tiles_required_for_victory);
        }
        private static void GameHasBeenWon(Board board)
        {
            foreach (var tile_row in board.tiles)
            {
                foreach (var tile in tile_row)
                {
                    if (tile.value == -1 && tile.Text == "P")
                    {
                        tile.BackColor = Color.LightSeaGreen;
                        tile.ForeColor = Color.Green;
                    }
                    else if (tile.value == -1)
                    {
                        tile.BackColor = Color.LightSeaGreen;
                        tile.ForeColor = Color.Green;
                        tile.Text = "*";
                    }

                    tile.is_enabled = false;
                }
            }

            MessageBox.Show("You Won!");
        }

    }
}
