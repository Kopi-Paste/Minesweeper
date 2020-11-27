using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Minesweeper
{
    class Game
    {
        private bool gameFinished;
        private int horizontalTiles;
        private int verticalTiles;
        private int horizontalPosition;
        private int verticalPosition;
        private int bombsAmount;
        private int coverColour;
        private int coverSecondaryColour;
        private int uncoverColour;
        private int uncoverSecondaryColour;
        private int flagColour;
        private int highlightColour;
        private int textColour;
        private int tilesWithoutMines;
        private int uncoveredTiles;
        private Tile[,] minefield;



        public bool GameFinished
        {
            get
            {
                return gameFinished;
            }
            private set
            {
                gameFinished = value;
            }
        }
        public int HorizontalTiles
        {
            get
            {
                return horizontalTiles;
            }
        }
        public int VerticalTiles
        {
            get
            {
                return verticalTiles;
            }

        }
        public int HorizontalPosition
        {
            get
            {
                return horizontalPosition;
            }
            private set
            {
                horizontalPosition += value;
            }
        }    
        public int VerticalPosition
        {
            get
            {
                return verticalPosition;
            }
            private set
            {
                verticalPosition += value;
            }
        }
        
        public int BombsAmount
        {
            get
            {
                return bombsAmount;
            }
        }
        public int CoverColour
        {
            get
            {
                return coverColour;
            }
        }
        public int CoverSecondaryColour
        {
            get
            {
                return coverSecondaryColour;
            }
        }
        public int UncoverColour
        {
            get
            {
                return uncoverColour;
            }
        }
        public int UncoverSecondaryColour
        {
            get
            {
                return uncoverSecondaryColour;
            }
        }
        public int FlagColour
        {
            get
            {
                return flagColour;
            }
        }
        public int HighlightColour
        {
            get
            {
                return highlightColour;
            }
        }
        public int TextColour
        {
            get
            {
                return textColour;
            }
        }
        public int TilesWithoutMines
        {
            get
            {
                return tilesWithoutMines;
            }
        }
        public int UncoveredTiles
        {
            get
            {
                return uncoveredTiles;
            }
            private set
            {
                uncoveredTiles = value;
            }
        }
        public Tile[,] Minefield
        {
            get
            {
                return minefield;
            }
            private set
            {
                minefield = value;
            }
        }

        public Game(int horizontal, int vertical, int bombs, int cover, int seccover, int uncover, int secuncover, int flag, int highlight, int text)
        {
            gameFinished = false;
            horizontalTiles = horizontal;
            verticalTiles = vertical;
            horizontalPosition = 0;
            verticalPosition = 0;
            bombsAmount = bombs;
            coverColour = cover;
            coverSecondaryColour = seccover;
            uncoverColour = uncover;
            uncoverSecondaryColour = secuncover;
            flagColour = flag;
            highlightColour = highlight;
            textColour = text;
            tilesWithoutMines = horizontal * vertical - bombs;
            minefield = new Tile[horizontal, vertical];
            int colour = cover;
            bool mine = false;
            int remainingBombs = bombs;
            int remainingTiles = horizontal * vertical;
            for (int x = 0; x < HorizontalTiles; x++)
            {
                if (x % 2 == 0)
                    colour = cover;
                else
                    colour = seccover;
                for (int y = 0; y < VerticalTiles; y++)
                {
                    Random rnd = new Random();
                    int mineDeterminator = rnd.Next(remainingTiles);
                    if (mineDeterminator < remainingBombs)
                    {
                        mine = true;
                        remainingBombs--;
                        remainingTiles--;
                        Console.WriteLine("Mine");
                    }
                    else
                    {
                        mine = false;
                        remainingTiles--;
                    }
                    Minefield[x, y] = new Tile(colour, mine);
                    if (colour == cover)
                        colour = seccover;
                    else
                        colour = cover;
                }
            }
        }
        public void PrintMinefield()
        {
            Console.ForegroundColor = (ConsoleColor)TextColour;
            for (int x = 0; x < HorizontalTiles; x++)
            {
                for (int y = 0; y < VerticalTiles; y++)
                {
                    Console.BackgroundColor = (ConsoleColor)Minefield[x, y].NormalColour;
                    Console.SetCursorPosition(2 * (x + 10), y + 20);
                    Console.Write(Minefield[x, y].Sign);
                }
                RecolourTile(HighlightColour, 0, 0, Minefield);
            }
            
        }
        public static void RecolourTile(int colourNum, int horizontalAxis, int verticalAxis, Tile[,] Minefield)
        {
            Console.BackgroundColor = (ConsoleColor)colourNum;
            Console.SetCursorPosition(2 * (horizontalAxis + 10), verticalAxis + 20);
            Console.Write(Minefield[horizontalAxis, verticalAxis].Sign);
        }
        public void GameAction(ConsoleKey keypressed)
        {
            RecolourTile(Minefield[HorizontalPosition, VerticalPosition].NormalColour, HorizontalPosition, VerticalPosition, Minefield);
            if (Minefield[HorizontalPosition, VerticalPosition].Flag == true)
                RecolourTile(FlagColour, HorizontalPosition, VerticalPosition, Minefield);
            switch (keypressed)
            {
                case ConsoleKey.UpArrow:
                    if (VerticalPosition != 0)
                        VerticalPosition = -1;
                    RecolourTile(HighlightColour, HorizontalPosition, VerticalPosition, Minefield);
                    break;
                case ConsoleKey.DownArrow:
                    if (VerticalPosition + 1 != VerticalTiles)
                        VerticalPosition = 1;
                    RecolourTile(HighlightColour, HorizontalPosition, VerticalPosition, Minefield);
                    break;
                case ConsoleKey.LeftArrow:
                    if (HorizontalPosition != 0)
                        HorizontalPosition = -1;
                    RecolourTile(HighlightColour, HorizontalPosition, VerticalPosition, Minefield);
                    break;
                case ConsoleKey.RightArrow:
                    if (HorizontalPosition + 1 != HorizontalTiles)
                        HorizontalPosition = 1;
                    RecolourTile(HighlightColour, HorizontalPosition, VerticalPosition, Minefield);
                    break;
                case ConsoleKey.Spacebar:
                    if (Minefield[HorizontalPosition, VerticalPosition].Flag == false)
                    {
                        Minefield[HorizontalPosition, VerticalPosition].FlagTile();
                        RecolourTile(FlagColour, HorizontalPosition, VerticalPosition, Minefield);
                    }
                    else
                    {
                        Minefield[HorizontalPosition, VerticalPosition].UnflagTile();
                        RecolourTile(HighlightColour, HorizontalPosition, VerticalPosition, Minefield);
                    }
                    break;
                case ConsoleKey.Enter:
                    Tile thisTile = Minefield[HorizontalPosition, VerticalPosition];
                    if (thisTile.Flag == true)
                    { }
                    else if (thisTile.Mine == true)
                    {
                        Console.WriteLine("You lost, gg");
                        GameFinished = true;
                    }
                    else
                    {
                        thisTile.UncoverTile(CoverColour, CoverSecondaryColour, UncoverColour, UncoverSecondaryColour, HorizontalPosition, VerticalPosition, Minefield);
                        Game.RecolourTile(HighlightColour, HorizontalPosition, VerticalPosition, Minefield);
                    }
                    break;
            }
            
            
        }

    }
        /*public void HighlightTile()
        {
            if (Minefield[HorizontalPosition, VerticalPosition].Flag == true)
            { }
            else
            {
                Console.SetCursorPosition(2 * (HorizontalPosition + 10), VerticalPosition + 20);
                Console.BackgroundColor = (ConsoleColor)HighlightColour;
                Console.Write(Minefield[HorizontalPosition, VerticalPosition].Sign);
            }
        }
        public void UnhighlightTile(ConsoleKey keypressed)
        {
            Tile previousHighlighted = null;
            if (keypressed == ConsoleKey.LeftArrow)
            {
                previousHighlighted = Minefield[HorizontalPosition + 1, VerticalPosition];
                Console.SetCursorPosition(2 * (HorizontalPosition + 11), VerticalPosition + 20);
            }
            else if (keypressed == ConsoleKey.RightArrow)
            {
                previousHighlighted = Minefield[HorizontalPosition - 1, VerticalPosition];
                Console.SetCursorPosition(2 * (HorizontalPosition + 9), VerticalPosition + 20);
            }
            else if (keypressed == ConsoleKey.UpArrow)
            {
                previousHighlighted = Minefield[HorizontalPosition, VerticalPosition + 1];
                Console.SetCursorPosition(2 * (HorizontalPosition + 10), VerticalPosition + 21);
            }
            else if (keypressed == ConsoleKey.DownArrow)
            {
                previousHighlighted = Minefield[HorizontalPosition, VerticalPosition - 1];
                Console.SetCursorPosition(2 * (HorizontalPosition + 10), VerticalPosition + 19);
            }
            else { }
            if (previousHighlighted.Flag == true) { }
            else
            {
                Console.BackgroundColor = (ConsoleColor)previousHighlighted.NormalColour;
                Console.Write(previousHighlighted.Sign);
            }

             
            
        }
        public void PrintMinefield()
        {
            Console.ForegroundColor = (ConsoleColor)TextColour;
            for (int x = 0; x < HorizontalTiles; x++)
            {
                for (int y = 0; y < VerticalTiles; y++)
                {
                    Console.BackgroundColor = (ConsoleColor)Minefield[x, y].NormalColour;
                    Console.SetCursorPosition(2 * (x + 10), y + 20);
                    Console.Write(Minefield[x, y].Sign);
                }
            }
            HighlightTile();
        }
        public void GameAction(ConsoleKey keypressed)
        {
            if (keypressed == ConsoleKey.UpArrow)
            {
                if (VerticalPosition == 0) { }
                else
                {
                    VerticalPosition = -1;
                    HighlightTile();
                    UnhighlightTile(keypressed);
                }
                
            }
            else if (keypressed == ConsoleKey.DownArrow)
            {
                if (VerticalPosition + 1 == VerticalTiles) { }
                else
                {
                    VerticalPosition = 1;
                    HighlightTile();
                    UnhighlightTile(keypressed);
                }
            }
            else if (keypressed == ConsoleKey.LeftArrow)
            {
                if (HorizontalPosition == 0) { }
                else
                {
                    HorizontalPosition = -1;
                    HighlightTile();
                    UnhighlightTile(keypressed);
                }
            }
            else if (keypressed == ConsoleKey.RightArrow)
            {
                if (HorizontalPosition + 1 == HorizontalTiles) { }
                else
                {
                    HorizontalPosition = 1;
                    HighlightTile();
                    UnhighlightTile(keypressed);
                }
            }
            else if (keypressed == ConsoleKey.Spacebar)
            {
                if (Minefield[HorizontalPosition, VerticalPosition].Flag == false)
                    Minefield[HorizontalPosition, VerticalPosition].FlagTile(2 * (HorizontalPosition + 10), VerticalPosition + 20, FlagColour);
                else
                    Minefield[HorizontalPosition, VerticalPosition].UnflagTile(2 * (HorizontalPosition + 10), VerticalPosition + 20);
            }
            else if (keypressed == ConsoleKey.Enter)
            {
                if (Minefield[HorizontalPosition, VerticalPosition].Mine == true)
                {
                    Console.WriteLine("You lost");
                    GameFinished = true;
                }
                else
                    Minefield[HorizontalPosition, VerticalPosition].UncoverTile(CoverColour, CoverSecondaryColour, UncoverColour, UncoverSecondaryColour, HorizontalPosition, VerticalPosition, Minefield);
            }*/
}

