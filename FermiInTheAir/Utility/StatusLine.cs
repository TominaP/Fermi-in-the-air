using System;

public class StatusLine
{
    public StatusLine()
    {
        Lives = 3;
        Speed = 1;
        Score = 0;
        Ammo = "Infinite";
        this.Pause = false;
    }

    public int Lives { get; set; }

    public int Speed { get; set; }

    public int Score { get; set; }

    public string Ammo { get; set; }

    public bool Pause { get; set; }


    public void PrintStatus()
    {

        string lives = string.Format("Lives: {0}", this.Lives);
        string score = string.Format("Score: {0}", this.Score);
        string ammo = string.Format("Ammo: {0}", this.Ammo);

        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Gray;

        Console.WriteLine("{0}|{1}|{2}", lives.PadRight(Console.WindowWidth / 3), score.PadRight(Console.WindowWidth / 3), ammo.PadRight(Console.WindowWidth / 3));
        Console.ResetColor();

    }

    public void ClearStatus()
    {

        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Gray;

        Console.Write(new string(' ', Console.WindowWidth));

        Console.ResetColor();

    }

}

