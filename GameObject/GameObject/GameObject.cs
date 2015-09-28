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
    
      public static void Main()
    {
        //new Settings();
        FrontPage();
    }

    public static void FrontPageElitsa()
    {
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkRed;

        var nameGame1 = new[]
        {
            @"      _______  _______ .______      .___  ___.  __    ",
            @"     |   ____||   ____||   _  \     |   \/   | |  |   ",
            @"     |  |__   |  |__   |  |_)  |    |  \  /  | |  |   ",
            @"     |   __|  |   __|  |      /     |  |\/|  | |  |   ",
            @"     |  |     |  |____ |  |\  \----.|  |  |  | |  |   ",
            @"     |__|     |_______|| _| `._____||__|  |__| |__|   ",


        };


        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkBlue;

        var artGame = new[]
        {
          
            @"                                                                                 ,o888      ",
            @"                                                                              ,o888888'     ",
            @"                            /\                         ,:o: o: oooo.        ,8O88Pd88       ",
            @"                           (  )                     ,.::.::o:ooooOoOoO. ,oO8O8Pd888'        ",
            @"                           (  )                   ,.:.::o:ooOoOoOO8O8OOo 8OOPd8O8O          ",
            @"                          /|/\|\                 , ..:.::o:ooOoOOOO8OOOOo FdO8O8            ",
            @"                         /_||||_\               , ..:.::o:ooOoOO8O888O8O,COCOO              ",
            @"                                               , . ..:.::o:ooOoOOOO8OOOOCOCO                ",
            @"                                                . ..:.::o:ooOoOoOO8O8OCCC Co                ",
            @"            /\                                     . ..:.::o:ooooOoCoCCC o:o                ",
            @"           (  )                                    . ..:.::o:o:,cooooCo oo:o:               ",
            @"           (  )                                 `   . . ..:.:cocoooo 'o:o:::'               ",
            @"          /|/\|\                                .`   . ..::ccccoc 'o:o:o:::'                ",
            @"         /_||||_\                              :.:.    ,c: cccc ':.:.:.:.:.'                ",
            @"                                               ..:.: '`::::c:'..:.:.:.:.:.'                 ",
            @"                                             ...:.'.:.:::: '   . . . . .'                   ",
            @"                                            .. . ....:. ' `   . . . ''                      ",
            @"                                            . . ... '                                       ",
            @"                                           . . ..                                           ",
            @"                                          . .                                               ",

         };

        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkRed;

        var nameGame2 = new[]
        {
                @"    __  .__   __.    .___________. __    __   _______         ___       __  .______       ",
                @"   |  | |  \ |  |    |           ||  |  |  | |   ____|       /   \     |  | |   _  \      ",
                @"   |  | |   \|  |    `---|  |----`|  |__|  | |  |__         /  ^  \    |  | |  |_)  |     ",
                @"   |  | |  . `  |        |  |     |   __   | |   __|       /  /_\  \   |  | |      /      ",
                @"   |  | |  |\   |        |  |     |  |  |  | |  |____     /  _____  \  |  | |  |\  \----. ",
                @"   |__| |__| \__|        |__|     |__|  |__| |_______|   /__/     \__\ |__| | _| `._____| ",
        };





        Console.WindowWidth = 140;
        Console.WriteLine("\n\n");
        foreach (string line in nameGame1)
               Console.WriteLine(line);
             
        foreach (string line in artGame)
            Console.WriteLine(line);
            Console.WriteLine("\n");
        foreach (string line in nameGame2)
            Console.WriteLine(line);

        System.Threading.Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        string msg = "ENTER if you dare !!!";
        Console.WriteLine("\n \n \n \n {0, 50}", msg);
        Console.ReadKey();

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


        while (true)
        {
            // adding chance to spawn @ 25% 
            Random rnd = new Random();
            int chanceToSpawn = rnd.Next(0, 100);


            if (chanceToSpawn <= 25)
            {
                obj.GenerateObject();
                //Move if generated to reduce clustering of objects 
                obj.MoveObjects();
                Thread.Sleep(200);
            }


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
        //one object per line at least for now 
        //implement collision detection if needed later 
        int objXPosition = 0;
        int objYPosition = rnd.Next(0, WindowWidth - objWidth);
        gameObjects.Enqueue(new Point(objXPosition, objYPosition));
        PrintObject(objXPosition, objYPosition);
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
                //keep object if in console range and no collision 
                if (newXPos <= 40 - objHeight)
                {
                    gameObjects.Enqueue(new Point(newXPos, currentObject.Y));
                    PrintObject(newXPos, currentObject.Y);
                }
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
