using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class GameMenu
    {
        private int porposedHorizontalTiles;
        private int porposedVerticalTiles;
        private int porposedBombAmount;
        private int porposedCoverColour;
        private int porposedCoverSecondaryColour;
        private int porposedUncoverColour;
        private int porposedUncoverSecondaryColour;
        private int porposedFlagColour;
        private int porposedHighlightColour;
        private int porposedTextColour;
        private int chosenLine;
        public int PorposedHorizontalTiles
        {
            get
            {
                return porposedHorizontalTiles;
            }
            private set
            {
                if ((porposedHorizontalTiles + value) == 0 || (porposedHorizontalTiles + value == 101))
                {
                }
                else
                {
                    porposedHorizontalTiles += value;
                }
            }
        }
        public int PorposedVerticalTiles
        {
            get
            {
                return porposedVerticalTiles;
            }
            private set
            {
                if ((porposedVerticalTiles + value) == 0 || (porposedVerticalTiles + value == 101))
                {
                }
                else
                {
                    porposedVerticalTiles += value;
                }
            }
        }
        public int PorposedBombAmount
        {
            get
            {
                return porposedBombAmount;
            }
            private set
            {
                if ((porposedBombAmount + value) == 0)
                {
                }
                else
                {
                    porposedBombAmount += value;
                }
            }
        }
        public int PorposedCoverColour
        {
            get
            {
                return porposedCoverColour;
            }
            private set
            {
                if (porposedCoverColour + value == 0)
                {
                    porposedCoverColour = 14;
                }
                else if (porposedCoverColour + value == 15)
                {
                    porposedCoverColour = 1;
                }
                else
                {
                    porposedCoverColour += value;
                }
            }
        }
        public int PorposedCoverSecondaryColour
        {
            get
            {
                return porposedCoverSecondaryColour;
            }
            private set
            {
                if (porposedCoverSecondaryColour + value == 0)
                {
                    porposedCoverSecondaryColour = 14;
                }
                else if (porposedCoverSecondaryColour + value == 15)
                {
                    porposedCoverSecondaryColour = 1;
                }
                else
                {
                    porposedCoverSecondaryColour += value;
                }
            }
        }
        public int PorposedUncoverColour
        {
            get
            {
                return porposedUncoverColour;
            }
            private set
            {
                if (porposedUncoverColour + value == 0)
                {
                    porposedUncoverColour = 14;
                }
                else if (porposedUncoverColour + value == 15)
                {
                    porposedUncoverColour = 1;
                }
                else
                {
                    porposedUncoverColour += value;
                }
            }
        }
        public int PorposedUncoverSecondaryColour
        {
            get
            {
                return porposedUncoverSecondaryColour;
            }
            private set
            {
                if (porposedUncoverSecondaryColour + value == 0)
                {
                    porposedUncoverSecondaryColour = 14;
                }
                else if (porposedUncoverSecondaryColour + value == 15)
                {
                    porposedUncoverSecondaryColour = 1;
                }
                else
                {
                    porposedUncoverSecondaryColour += value;
                }
            }
        }
        public int PorposedFlagColour
        {
            get
            {
                return porposedFlagColour;
            }
            private set
            {
                if (porposedFlagColour + value == 0)
                {
                    porposedFlagColour = 14;
                }
                else if (porposedFlagColour + value == 15)
                {
                    porposedFlagColour = 1;
                }
                else
                {
                    porposedFlagColour += value;
                }
            }
        }
        public int PorposedHighlightColour
        {
            get
            {
                return porposedHighlightColour;
            }
            private set
            {
                if (porposedHighlightColour + value == 0)
                {
                    porposedHighlightColour = 14;
                }
                else if (porposedHighlightColour + value == 15)
                {
                    porposedHighlightColour = 1;
                }
                else
                {
                    porposedHighlightColour += value;
                }
            }
        }
        public int PorposedTextColour
        {
            get
            {
                return porposedTextColour;
            }
            private set
            {
                if (porposedTextColour + value == 0)
                {
                    porposedTextColour = 14;
                }
                else if (porposedTextColour + value == 15)
                {
                    porposedTextColour = 1;
                }
                else
                {
                    porposedTextColour += value;
                }
            }
        }
        public int ChosenLine
        {
            get
            {
                return chosenLine;
            }
            private set
            {
                if (chosenLine + value < 7) {}
                else if (chosenLine + value > 25) {}
                else
                {
                    chosenLine += value;
                }
            }
        }
        public GameMenu()
        {
            porposedHorizontalTiles = 20;
            porposedVerticalTiles = 20;
            porposedBombAmount = 50;
            porposedCoverColour = 8;
            porposedCoverSecondaryColour = 1;
            porposedUncoverColour = 2;
            porposedUncoverSecondaryColour = 3;
            porposedFlagColour = 4;
            porposedHighlightColour = 5;
            porposedTextColour = 6;
            chosenLine = 7;
        }
        public void PrintMenu()
        {
            Console.ForegroundColor = (ConsoleColor)PorposedTextColour;
            Console.SetCursorPosition(50, 2);
            Console.Write("Game settings");
            Console.SetCursorPosition(47, 4);
            Console.Write("Use arrow keys to operate and enter to confirm.");
            Console.SetCursorPosition(20, 7);
            Console.Write("Number of horizontal tiles: " + PorposedHorizontalTiles);
            Console.SetCursorPosition(20, 9);
            Console.Write("Number of vertical tiles: " + PorposedVerticalTiles);
            Console.SetCursorPosition(20, 11);
            Console.Write("Number of mines: " + PorposedBombAmount);
            Console.SetCursorPosition(20, 13);
            Console.BackgroundColor = (ConsoleColor)PorposedCoverColour;
            Console.Write("Covered tiles colour: " + ((ConsoleColor)PorposedCoverColour));
            Console.SetCursorPosition(20, 15);
            Console.BackgroundColor = (ConsoleColor)PorposedCoverSecondaryColour;
            Console.Write("Covered tiles secondary colour: " + ((ConsoleColor)PorposedCoverSecondaryColour));
            Console.SetCursorPosition(20, 17);
            Console.BackgroundColor = (ConsoleColor)PorposedUncoverColour;
            Console.Write("Uncovered tiles colour: " + ((ConsoleColor)PorposedUncoverColour));
            Console.SetCursorPosition(20, 19);
            Console.BackgroundColor = (ConsoleColor)PorposedUncoverSecondaryColour;
            Console.Write("Uncovered tiles secondary colour: " + ((ConsoleColor)PorposedUncoverSecondaryColour));
            Console.SetCursorPosition(20, 21);
            Console.BackgroundColor = (ConsoleColor)PorposedFlagColour;
            Console.Write("Colour of flag: " + ((ConsoleColor)PorposedFlagColour));
            Console.SetCursorPosition(20, 23);
            Console.BackgroundColor = (ConsoleColor)PorposedHighlightColour;
            Console.Write("Color of highlighted tile: " + ((ConsoleColor)PorposedHighlightColour));
            Console.SetCursorPosition(20, 25);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Color of text: " + ((ConsoleColor)PorposedTextColour));
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(20, ChosenLine);
            switch (ChosenLine)
            {
                case 7:
                    Console.Write("Number of horizontal tiles: " + PorposedHorizontalTiles);
                    break;
                case 9:
                    Console.Write("Number of vertical tiles: " + PorposedVerticalTiles);
                    break;
                case 11:
                    Console.Write("Number of mines: " + PorposedBombAmount);
                    break;
                case 13:
                    Console.BackgroundColor = (ConsoleColor)PorposedCoverColour;
                    Console.Write("Covered tiles colour: " + ((ConsoleColor)PorposedCoverColour));
                    break;
                case 15:
                    Console.BackgroundColor = (ConsoleColor)PorposedCoverSecondaryColour;
                    Console.Write("Covered tiles secondary colour: " + ((ConsoleColor)PorposedCoverSecondaryColour));
                    break;
                case 17:
                    Console.BackgroundColor = (ConsoleColor)PorposedUncoverColour;
                    Console.Write("Uncovered tiles colour: " + ((ConsoleColor)PorposedUncoverColour));
                    break;
                case 19:
                    Console.BackgroundColor = (ConsoleColor)PorposedUncoverSecondaryColour;
                    Console.Write("Uncovered tiles secondary colour: " + ((ConsoleColor)PorposedUncoverSecondaryColour));
                    break;
                case 21:
                    Console.BackgroundColor = (ConsoleColor)PorposedFlagColour;
                    Console.Write("Colour of flag: " + ((ConsoleColor)PorposedFlagColour));
                    break;
                case 23:
                    Console.BackgroundColor = (ConsoleColor)PorposedHighlightColour;
                    Console.Write("Color of highlighted tile: " + ((ConsoleColor)PorposedHighlightColour));
                    break;
                case 25:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("Color of text: " + ((ConsoleColor)PorposedTextColour));
                    break;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("      ");
        }
        public void SettingAction(ConsoleKey keypressed)
        {
            if (keypressed == ConsoleKey.UpArrow)
            {
                ChosenLine = -2;
            }
            else if (keypressed == ConsoleKey.DownArrow)
            {
                ChosenLine = 2;
            }
            else if (keypressed == ConsoleKey.LeftArrow || keypressed == ConsoleKey.RightArrow)
            {
                int change = 0;
                if (keypressed == ConsoleKey.LeftArrow)
                {
                    change = -1;
                }
                else if (keypressed == ConsoleKey.RightArrow)
                {
                    change = 1;
                }
                else { }
                switch (ChosenLine)
                {
                    case 7:
                        PorposedHorizontalTiles = change;
                        break;
                    case 9:
                        PorposedVerticalTiles = change;
                        break;
                    case 11:
                        PorposedBombAmount = change;
                        break;
                    case 13:
                        PorposedCoverColour = change;
                        break;
                    case 15:
                        PorposedCoverSecondaryColour = change;
                        break;
                    case 17:
                        PorposedUncoverColour = change;
                        break;
                    case 19:
                        PorposedUncoverSecondaryColour = change;
                        break;
                    case 21:
                        PorposedFlagColour = change;
                        break;
                    case 23:
                        PorposedHighlightColour = change;
                        break;
                    case 25:
                        PorposedTextColour = change;
                        break;
                }
            }
            else { };
            PrintMenu();
        }
    }
}
