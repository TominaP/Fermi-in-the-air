public class Settings
{
    public Settings()
    {
        Width = 80;
        Height = 40;
        Speed = 1;
        Score = 0;
        GameOver = false;
    }

    public static int Width { get; set; }

    public static int Height { get; set; }

    public static int Speed { get; set; }

    public static int Score { get; set; }
    
    public static bool GameOver { get; set; } 
}
