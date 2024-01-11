using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaperV2
{
    internal class Board : IGameEventListener
    {
        //events
        public event EventHandler OnFirstTurn;
        public event EventHandler OnGameWon;

        private Control ParentControl;
        private Panel GamePanel;
        public CounterButton ParentCounterButton;

        public int bombs;
        public int board_row_count;
        public int board_column_count;
        public int tiles_required_for_victory;
        public bool first_turn;

        public List<List<Tile>> tiles = new List<List<Tile>>();

        public Board(Control parentControl, Panel gamePanel, CounterButton counterButton)
        {
            this.ParentControl = parentControl;
            this.GamePanel = gamePanel;
            this.ParentCounterButton = counterButton;
        }
        public void FirstTurn()
        {
            OnFirstTurn?.Invoke(this, EventArgs.Empty);
        }

        public void IsGameWon()
        {   
            if(tiles_required_for_victory == 0)
                OnGameWon?.Invoke(this, EventArgs.Empty);
        }

        public void StartGame(int difficulty)
        {
            ParentCounterButton.Text = "-";
            first_turn = true;
            DeleteBoard();
            LevelOfDifficulty(difficulty);     
            GenerateBoard();
            ParentCounterButton.UpdateCounter();
            if (OnFirstTurn == null)
                OnFirstTurn += GameLogic.OnFirstTurnHandler;

            if (OnGameWon == null)
                OnGameWon += GameLogic.OnGameHasBeenWonHandler;
        }
        private void LevelOfDifficulty(int difficulty)
        {
            switch(difficulty)
            {
                case 0:
                    bombs = 10;
                    board_row_count = 10;
                    board_column_count = 10;
                    break;
                case 1:
                    bombs = 40;
                    board_row_count = 16;
                    board_column_count = 16;
                    break; 
                case 2:
                    bombs = 99;
                    board_row_count = 16;
                    board_column_count = 30;
                    break;
            }

            tiles_required_for_victory = board_row_count * board_column_count - bombs;
            ParentCounterButton.bomb_counter = bombs;
        }
        private void GenerateBoard()
        {
            int tile_size = CalculateTileSize();
            CalculateTileOffset(tile_size, out int offset_x, out int offset_y);

            int location_y = offset_y;
            for (int x=0; x < board_row_count; x++)
            {
                int location_x = offset_x;
                List<Tile> tile_row = new List<Tile>();             
                for(int y=0; y<board_column_count; y++)
                {
                    Tile tile = new Tile(x, y, this);
                    tile_row.Add(tile);
                    tile.SetTileSize(tile_size);
                    tile.SetTileLocation(location_x, location_y);

                    location_x += tile_size;

                    ParentControl.Controls.Add(tile);
                    GamePanel.Controls.Add(tile);
                }
                location_y += tile_size;
                tiles.Add(tile_row);
            }
            //ChangeTileSizes();
        }
        public void ChangeTileSizes()
        {
            int tile_size = CalculateTileSize();
            CalculateTileOffset(tile_size,out int offset_x,out int offset_y);

            int location_y = offset_y;
            foreach (var tile_row in tiles)
            {
                int location_x = offset_x;
                foreach (var tile in tile_row)
                {
                    tile.SetTileSize(tile_size);
                    tile.SetTileLocation(location_x, location_y);
                    location_x += tile_size;
                }
                location_y += tile_size;
            }
        }
        private void DeleteBoard()
        {
            foreach (var tile_row in tiles)
            {
                foreach (var tile in tile_row)
                {
                    tile.Dispose();
                }
            }

            tiles.Clear();
        }
        private int CalculateTileSize()
        {
            return Math.Min(GamePanel.Width/board_column_count, GamePanel.Height/board_row_count);
        }
        private void CalculateTileOffset(int tile_size,out int offset_x, out int offset_y) 
        { 
            offset_x = (GamePanel.Width - (tile_size * board_column_count))/2;
            offset_y = (GamePanel.Height - (tile_size * board_row_count))/2;             
            //generalnie offset = panel.Wymiar - tile_size*liczba wierszy lub kolumn
            //jest tak dlatego, że gdy okno jest asymetryczne,
            //np. width jest większy niż height, to musi wiedziec w którym miejscu
            //rozpocząć rozmieszczanie Tile, potem po prostu dodaje size
        }
    }
}
