using System;


public class FermiInTheAir
{
    public class Settings
    {
        //default settings
        public Settings()
        {
            Console.WindowHeight = 40;
            Console.WindowWidth = 80;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
        }

    }

    public static void Main()
    {
        new Settings();
    }
}

