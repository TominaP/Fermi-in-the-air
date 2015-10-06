using System;


public class Sounds
{
    public void Crash()
    {
        Console.Beep(420, 115);
        Console.Beep(420, 250);
    }

    public void DestroyObject()
    {
        Console.Beep(500, 200);
    }

    public void LevelUp()
    {
        Console.Beep(420, 100);
        Console.Beep(500, 150);
        Console.Beep(400, 80);
        Console.Beep(300, 150);
    }

    public void GameOver()
    {
        Console.Beep(400, 80);
        for (int i = 300; i < 800; i += 50)
        {
            Console.Beep(i, 50);
        }
        Console.Beep(600, 50);
        Console.Beep(800, 50);
        Console.Beep(600, 50);
        Console.Beep(300, 50);
        Console.Beep(300, 100);
    }
}


