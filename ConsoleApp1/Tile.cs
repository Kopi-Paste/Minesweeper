using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Tile
    {
        private int horizontalPos;
        private int verticalPos;
        private bool uncovered;
        private bool mine;
        private bool flag;
        private string sign;
        private int normalColour;
        private int minesAround;
        private List<Tile> tilesAround;

        public int HorizontalPos
        {
            get
            {
                return horizontalPos;
            }
            private set
            {
                horizontalPos = value;
            }
        }
        public int VerticalPos
        {
            get
            {
                return verticalPos;
            }
            private set
            {
                verticalPos = value;
            }
        }
        public bool Uncovered
        {
            get
            {
                return uncovered;
            }
            private set
            {
                uncovered = value;
            }
        }
        public bool Mine
        {
            get
            {
                return mine;
            }
            private set
            {
                mine = value;
            }
        }
        public bool Flag
        {
            get
            {
                return flag;
            }
            private set
            {
                flag = value;
            }
        }
        public string Sign
        {
            get
            {
                return sign;
            }
            private set
            {
                sign = value;
            }
        }
        
        public int NormalColour
        {
            get
            {
                return normalColour;
            }
            private set
            {
                normalColour = value;
            }
        }
        public int MinesAround
        {
            get
            {
                return minesAround;
            }
            private set
            {
                minesAround = value;
            }
        }
        public List<Tile> TilesAround
        {
            get
            {
                return tilesAround;
            }
            private set
            {
                tilesAround = value;
            }
        }
            
        public Tile(int horizontal, int vertical, int colour, bool bomb)
        {
            HorizontalPos = horizontal;
            VerticalPos = vertical;
            Sign = "  ";
            Uncovered = false;
            Mine = bomb;
            Flag = false;
            normalColour = colour;
            MinesAround = 0;
            TilesAround = new List<Tile>();
        }
        public void MinesAndTilesAroundCalculator(int x, int y, Tile[,] minefield)
        {
            int bombsAround = 0;
            try
            {
                if (minefield[x - 1, y - 1] != null)
                    TilesAround.Add(minefield[x - 1, y - 1]);
                if (minefield[x - 1, y - 1].Mine == true)
                    bombsAround++;
            }
            catch (IndexOutOfRangeException)
            { };
            try
            {
                if (minefield[x - 1, y] != null)
                    TilesAround.Add(minefield[x - 1, y]);
                if (minefield[x - 1, y].Mine == true)
                    bombsAround++;
            }
            catch (IndexOutOfRangeException)
            { };
            try
            {
                if (minefield[x - 1, y + 1] != null)
                    TilesAround.Add(minefield[x - 1, y + 1]);
                if (minefield[x - 1, y + 1].Mine == true)
                    bombsAround++;
            }
            catch (IndexOutOfRangeException)
            { };
            try
            {
                if (minefield[x, y - 1] != null)
                    TilesAround.Add(minefield[x, y - 1]);
                if (minefield[x, y - 1].Mine == true)
                    bombsAround++;

                else { };
            }
            catch (IndexOutOfRangeException)
            { };
            try
            {
                if (minefield[x, y + 1] != null)
                    TilesAround.Add(minefield[x, y + 1]);
                if (minefield[x, y + 1].Mine == true)
                    bombsAround++;
            }
            catch (IndexOutOfRangeException)
            { };
            try
            {
                if (minefield[x + 1, y - 1] != null)
                    TilesAround.Add(minefield[x + 1, y - 1]);
                if (minefield[x + 1, y - 1].Mine == true)
                    bombsAround++;
            }
            catch (IndexOutOfRangeException)
            { };
            try
            {
                if (minefield[x + 1, y] != null)
                    TilesAround.Add(minefield[x + 1, y]);
                if (minefield[x + 1, y].Mine == true)
                    bombsAround++;
            }
            catch (IndexOutOfRangeException)
            { };
            try
            {
                if (minefield[x + 1, y + 1] != null)
                    TilesAround.Add(minefield[x + 1, y + 1]);
                if (minefield[x + 1, y + 1].Mine == true)
                    bombsAround++;
            }
            catch (IndexOutOfRangeException)
            { };
            minefield[x, y].MinesAround = bombsAround;
        }
        
        public void FlagTile()
        {
            Flag = true;
        }
        public void UnflagTile()
        {
            Flag = false;
        }
        public void UncoverTile(int Cover1, int Cover2, int Uncover1, int Uncover2, int Horizontal, int Vertical, Tile[,] Minefield, Game game)
        {
            game.UncoveredTilesCounter();
            Uncovered = true;
            Flag = false;
            if (NormalColour == Cover1)
                NormalColour = Uncover1;
            else if (NormalColour == Cover2)
                NormalColour = Uncover2;
            else
            { }
            
            if (MinesAround == 0)
            {
                foreach (Tile tile in TilesAround)
                {
                    
                    if (tile.Uncovered == false)
                    {
                        tile.UncoverTile(Cover1, Cover2, Uncover1, Uncover2, tile.HorizontalPos, tile.VerticalPos, Minefield, game);
                    }
                        
                }
            }
            else
                Sign = (MinesAround.ToString() + " ");
            Game.RecolourTile(NormalColour, Horizontal, Vertical, Minefield);

        }
    }
}
