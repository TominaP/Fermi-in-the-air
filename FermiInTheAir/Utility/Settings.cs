using System;

public class Settings
{
    public Settings()
    {        
        Width = 80;
        Height = 40;
        Speed = 1;
        Score = 0;
        GameOver = false;
        Console.SetWindowSize(Width, Height);
        Console.SetBufferSize(Width, Height);
        Console.CursorVisible = false;
    }
    public static void WriteLines(int times)
    {
        for (int i = 0; i < times; i++)
        {
            Console.WriteLine();
        }
    }
    public static void PrintGameOver() //Method under construction, change the GameOver bool property to true to see run the method
    {
        WriteLines(5);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine( "      ________                          ________                      ._.");
        Console.WriteLine(@"     /  _____/_____    _____   ____     \_____  \___  __ ____________ | |");
        Console.WriteLine(@"     /   \  ___\__  \  /     \_/ __ \     /   |   \  \/ // __ \_  __ \  |");
        Console.WriteLine(@"     \    \_\  \/ __ \|  Y Y  \  ___/    /    |    \   /\  ___/|  | \/ \|");
        Console.WriteLine(@"      \______  (____  /__|_|  /\___  >   \_______  /\_/  \___  >__|     ");
        Console.WriteLine(@"             \/     \/      \/     \/            \/          \/        \/");
        WriteLines(5);
        Console.WriteLine("\t\t\t\t\t\t\tTotal score: " + 0); //TODO: property for calculating the score
        WriteLines(5);
        Console.WriteLine(new string('-',33) + "NEW GAME(Y/N)" + new string('-',34));
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo newGame = Console.ReadKey();
            if (newGame.Key == ConsoleKey.Y || newGame.Key == ConsoleKey.Enter)
            {
                //start new game
                //TODO: create method for restarting the game
            }
            else if (newGame.Key == ConsoleKey.N)
            {
                //exit application
            }
        }
    }

    public int Width { get; set; }

    public int Height { get; set; }

    public int Speed { get; set; }

    public int Score { get; set; }
    
    public bool GameOver { get; set; } 
}
