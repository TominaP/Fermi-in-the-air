using System;
using System.Collections.Generic;
using System.Threading;

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


public class Point
{
    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public int X { get; set; }

    public int Y { get; set; }
}


public class GameObject
{
    public static void Main()
    {
        new Settings();

        GameObject obj = new GameObject();

        for (int i = 0; i < 2; i++)
        {
            obj.GenerateObject();
        }

        while (true)
        {
            obj.MoveObjects();
            Thread.Sleep(200);
        }

        Console.Read();
    }

    const int WindowHeight = 40;
    const int WindowWidth = 80;
    private int objHeight = 2;
    private int objWidth = 2;
    private char objSymbol = '#';
    public Queue<Point> gameObjects = new Queue<Point>();

    Random rnd = new Random();


    //generate object on top of the screen
    public void GenerateObject()
    {
        int objXPosition = 0;
        int objYPosition = rnd.Next(0, WindowWidth - objWidth);

        //if not collision print object, else we call same method recursively
        if (!CheckForCollision(objXPosition, objYPosition))
        {
            gameObjects.Enqueue(new Point(objXPosition, objYPosition));

            PrintObject(objXPosition, objYPosition);
        }
        else
        {
            GenerateObject();
        }
    }

    public bool CheckForCollision(int objXPosition, int objYPosition)
    {
        //TODO: need more info to implement
        return false;
    }

    public void PrintObject(int xPos, int yPos)
    {
        for (int i = xPos; i < xPos + objHeight; i++)
        {
            for (int j = yPos; j < yPos + objWidth; j++)
            {
                Console.SetCursorPosition(j, i);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(objSymbol);
            }
        }
    }

    public void MoveObjects()
    {
        int objCount = gameObjects.Count;

        for (int i = 0; i < objCount; i++)
        {
            Point currentObject = gameObjects.Dequeue();

            int newXPos = currentObject.X + 1;

            //clear object from console
            ClearObject(currentObject.X, currentObject.Y);

            if (!CheckForCollision(newXPos, currentObject.Y))
            {
                gameObjects.Enqueue(new Point(newXPos, currentObject.Y));
                PrintObject(newXPos, currentObject.Y);
            }
            else
            {
                //object is destroyed and plane is hitted!
            }
        }

    }

    public void ClearObject(int xPos, int yPos)
    {
        for (int i = xPos; i < xPos + objHeight; i++)
        {
            for (int j = yPos; j < yPos + objWidth; j++)
            {
                Console.SetCursorPosition(j, i);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(' ');
            }
        }
    }

}





