﻿public class Settings
{
    public Settings()
    {        
        Width = 80;
        Height = 40;
        Speed = 1;
        Score = 0;
        GameOver = false;
    }

    public int Width { get; set; }

    public int Height { get; set; }

    public int Speed { get; set; }

    public int Score { get; set; }
    
    public bool GameOver { get; set; } 
}