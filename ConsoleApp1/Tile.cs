using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Tile
    {
        private bool uncovered;
        private bool mine;
        private bool flag;
        private string sign;
        private int normalColour;
        private int minesAround;

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
        public Tile(int colour, bool bomb)
        {
            Sign = "  ";
            Uncovered = false;
            Mine = bomb;
            Flag = false;
            normalColour = colour;
            MinesAround = 0;
        }
        public void MinesAroundCalculator(int x, int y, Tile[,] minefield)
        {
            int bombsAround = 0;
            try
            {
                if (minefield[x - 1, y - 1].Mine == true)
                    bombsAround++;

                else { };
            }
            catch (IndexOutOfRangeException)
            { };
            try
            {
                if (minefield[x - 1, y].Mine == true)
                    bombsAround++;

                else { };
            }
            catch (IndexOutOfRangeException)
            { };
            try
            {
                if (minefield[x - 1, y + 1].Mine == true)
                    bombsAround++;

                else { };
            }
            catch (IndexOutOfRangeException)
            { };
            try
            {
                if (minefield[x, y - 1].Mine == true)
                    bombsAround++;

                else { };
            }
            catch (IndexOutOfRangeException)
            { };
            try
            {
                if (minefield[x, y + 1].Mine == true)
                    bombsAround++;

                else { };
            }
            catch (IndexOutOfRangeException)
            { };
            try
            {
                if (minefield[x + 1, y - 1].Mine == true)
                    bombsAround++;

                else { };
            }
            catch (IndexOutOfRangeException)
            { };
            try
            {
                if (minefield[x + 1, y].Mine == true)
                    bombsAround++;

                else { };
            }
            catch (IndexOutOfRangeException)
            { };
            try
            {
                if (minefield[x + 1, y + 1].Mine == true)
                    bombsAround++;

                else { };
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
        public void UncoverTile(int Cover1, int Cover2, int Uncover1, int Uncover2, int Horizontal, int Vertical, Tile[,] Minefield)
        {
            Uncovered = true;
            Flag = false;
            if (NormalColour == Cover1)
                NormalColour = Uncover1;
            else if (NormalColour == Cover2)
                NormalColour = Uncover2;
            else
            { }
            if (MinesAround != 0)
                Sign = MinesAround.ToString() + " ";
            Game.RecolourTile(NormalColour, Horizontal, Vertical, Minefield);
            if (MinesAround == 0)
            {
                try
                {
                    if (Minefield[Horizontal - 1, Vertical - 1].Uncovered == false)
                        Minefield[Horizontal - 1, Vertical - 1].UncoverTile(Cover1, Cover2, Uncover1, Uncover2, Horizontal - 1, Vertical - 1, Minefield);
                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    if (Minefield[Horizontal - 1, Vertical].Uncovered == false)
                        Minefield[Horizontal - 1, Vertical].UncoverTile(Cover1, Cover2, Uncover1, Uncover2, Horizontal - 1, Vertical, Minefield);
                }
                catch (IndexOutOfRangeException)
                { }
                { }
                try
                {
                    if (Minefield[Horizontal - 1, Vertical + 1].Uncovered == false)
                         Minefield[Horizontal - 1, Vertical + 1].UncoverTile(Cover1, Cover2, Uncover1, Uncover2, Horizontal - 1, Vertical + 1, Minefield);
                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    if (Minefield[Horizontal, Vertical - 1].Uncovered == false)
                         Minefield[Horizontal, Vertical - 1].UncoverTile(Cover1, Cover2, Uncover1, Uncover2, Horizontal, Vertical - 1, Minefield);
                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    if (Minefield[Horizontal, Vertical + 1].Uncovered == false)
                        Minefield[Horizontal, Vertical + 1].UncoverTile(Cover1, Cover2, Uncover1, Uncover2, Horizontal, Vertical + 1, Minefield);

                }
                catch (IndexOutOfRangeException)
                { }
                
                try
                {
                    if (Minefield[Horizontal + 1, Vertical - 1].Uncovered == false)
                        Minefield[Horizontal + 1, Vertical - 1].UncoverTile(Cover1, Cover2, Uncover1, Uncover2, Horizontal + 1, Vertical - 1, Minefield);
                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    if (Minefield[Horizontal + 1, Vertical].Uncovered == false)
                         Minefield[Horizontal + 1, Vertical].UncoverTile(Cover1, Cover2, Uncover1, Uncover2, Horizontal + 1, Vertical, Minefield);
                }
                catch (IndexOutOfRangeException)
                { }
                try
                {
                    if (Minefield[Horizontal + 1, Vertical + 1].Uncovered == false)
                        Minefield[Horizontal + 1, Vertical + 1].UncoverTile(Cover1, Cover2, Uncover1, Uncover2, Horizontal + 1, Vertical + 1, Minefield);
                }
                catch (IndexOutOfRangeException)
                { }
            }
            
        }
    }
}
