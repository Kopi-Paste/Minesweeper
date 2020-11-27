using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;
            GameMenu defaultSettings = new GameMenu();
            defaultSettings.PrintMenu();
            ConsoleKey keypressed;
            do
            {
                keypressed = Console.ReadKey(true).Key;
                defaultSettings.SettingAction(keypressed);
            } while (keypressed != ConsoleKey.Enter);
            Game newGame = new Game(defaultSettings.PorposedHorizontalTiles, defaultSettings.PorposedVerticalTiles, defaultSettings.PorposedBombAmount, defaultSettings.PorposedCoverColour,
                defaultSettings.PorposedCoverSecondaryColour, defaultSettings.PorposedUncoverColour, defaultSettings.PorposedUncoverSecondaryColour, defaultSettings.PorposedFlagColour,
                defaultSettings.PorposedHighlightColour, defaultSettings.PorposedTextColour);
            for (int x = 0; x < newGame.HorizontalTiles; x++)
            {
                for (int y = 0; y < newGame.VerticalTiles; y++)
                {
                    newGame.Minefield[x, y].MinesAroundCalculator(x, y, newGame.Minefield);
                }
            }
            Console.Clear();
            newGame.PrintMinefield();
            do
            {
                keypressed = Console.ReadKey(true).Key;
                newGame.GameAction(keypressed);                
            } while (newGame.GameFinished == false);
        }
    }
}

