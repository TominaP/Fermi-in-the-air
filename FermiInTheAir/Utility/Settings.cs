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
        this.Pause = false;
        Console.SetWindowSize(Width, Height);
        Console.SetBufferSize(Width, Height);
        Console.CursorVisible = false;

        PlayerName = "N/A";
    }

    public int Width { get; set; }

    public int Height { get; set; }

    public int Speed { get; set; }

    public int Score { get; set; }

    public bool GameOver { get; set; }

    public bool Pause { get; set; }

    public string PlayerName { get; set; }

    public static void WriteLines(int times)
    {
        for (int i = 0; i < times; i++)
        {
            Console.WriteLine();
        }
    }
    public static void PrintGameOver(int finalScore)
    {

        Console.Clear();
        WriteLines(5);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("      ________                          ________                      ._.");
        Console.WriteLine(@"     /  _____/_____    _____   ____     \_____  \___  __ ____________ | |");
        Console.WriteLine(@"     /   \  ___\__  \  /     \_/ __ \     /   |   \  \/ // __ \_  __ \  |");
        Console.WriteLine(@"     \    \_\  \/ __ \|  Y Y  \  ___/    /    |    \   /\  ___/|  | \/ \|");
        Console.WriteLine(@"      \______  (____  /__|_|  /\___  >   \_______  /\_/  \___  >__|     ");
        Console.WriteLine(@"             \/     \/      \/     \/            \/          \/        \/");
        WriteLines(9);

        Settings player = new Settings();
        StatusLine finalStatus = new StatusLine();

        Console.WriteLine("\t\t\t\t\t\t\tTotal score: " + finalScore);
        WriteLines(9);
        Console.Write("\t\t\tPlease enter your name: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        try
        {
            player.PlayerName = Console.ReadLine(true);
        }
        catch (Exception)
        {
            player.PlayerName = "N/A";

        }
        try
        {
            FermiInTheAir.Utility.Leaderboard.WriteScores(finalScore, player.PlayerName, DateTime.Now);
        }
        catch (Exception)
        {
            Console.ResetColor();
            Console.Clear();
            FermiInTheAir.Utility.OpeningPage.OpenPage();
        }
        //go to leaderboard
        Console.ResetColor();
        Console.Clear();
        FermiInTheAir.Utility.Leaderboard.ViewScores();

        // WriteLines(7);
        // Console.ResetColor();
        // Console.WriteLine(new string(' ', (80 - "<< Press <L> to see Fermi in the air's Leaderboard >>".Length - 1) / 2)
        //         + "<< Press <L> to see Fermi in the air's Leaderboard >>");
        // WriteLines(2);
        // Console.WriteLine(new string(' ', (80 - "<< Press <m> to go to main menu >>".Length - 1) / 2)
        //         + "<< Press <m> to go to main menu >>");
        // WriteLines(2);
        // Console.WriteLine(new string(' ', (80 - "<< Press <Enter> to start a new game >>".Length - 1) / 2)
        //         + "<< Press <Enter> to start a new game >>");
        // WriteLines(2);




        // if (Console.KeyAvailable)
        // {
        //     ConsoleKeyInfo action = Console.ReadKey();
        //     if (action.Key == ConsoleKey.Enter)
        //     {
        //         Console.Clear();
        //         Engine eng = new Engine();
        //         eng.Run();
        //     }
        //     else if (action.Key == ConsoleKey.L)
        //     {
        //         FermiInTheAir.Utility.Leaderboard.ViewScores();
        //     }
        //     else if (action.Key == ConsoleKey.Y || action.Key == ConsoleKey.Enter)
        //     {
        //         Engine eng = new Engine();
        //         eng.Run();
        //     }
        //     else if (action.Key == ConsoleKey.M)
        //     {
        //         Console.Clear();
        //         FermiInTheAir.Utility.OpeningPage.OpenPage();
        //     }
        //     else if (action.Key == ConsoleKey.N)
        //     {
        //         //exit application
        //     }
        // }
    }


}
