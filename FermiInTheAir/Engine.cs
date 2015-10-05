using FermiInTheAir.GameObjects;
using FermiInTheAir.Utility;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;


public class Engine
{
    private List<GameObject> gameObjectsList = new List<GameObject>();
    private List<GameObject> newGameObjectsList = new List<GameObject>();

    StatusLine status = new StatusLine();
    Settings settings = new Settings();
    Player plane = new Player();

    private Random rnd = new Random();
    private DestroyObject destroyObject;
    private CollectedObject collectObject;
    private GameObject current;
    private Projectile projectile;
    private int sleepTime = 300;

    public void Run()
    {
        plane.Print();

        //set plane point coordinates to true       

        while (!settings.GameOver)
        {
            // adding chance to spawn @ 25%               
            int chanceToSpawn = rnd.Next(0, 100);

            status.ClearStatus();
            status.PrintStatus();

            if (chanceToSpawn <= 80)
            {
                int objXPosition = 1;
                int objYPosition = rnd.Next(0, settings.Width - 2);
                destroyObject = new DestroyObject(new Point(objXPosition, objYPosition));

                foreach (var point in destroyObject.PositionsCoordinates)
                {
                    if (CheckCollisionWhitPlane(destroyObject, plane))
                    {
                        destroyObject.HaveCollision = true;
                        plane.Lives--;
                        break;
                    }
                    if (CheckCollisionWhitOtherObject(point))
                    {
                        destroyObject.HaveCollision = true;
                    }
                }

                if (!destroyObject.HaveCollision)
                {
                    gameObjectsList.Add(destroyObject);
                    destroyObject.SetPositionsCoordinates();
                }
            }

            if (chanceToSpawn <= 15)
            {
                int objXPosition = 1;
                int objYPosition = rnd.Next(0, settings.Width);
                collectObject = new CollectedObject(new Point(objXPosition, objYPosition));

                if (CheckCollisionWhitPlane(collectObject, plane))
                {
                    collectObject.HaveCollision = true;
                    settings.Score += 5; //TODO : regulate score
                }

                if (CheckCollisionWhitOtherObject(collectObject.UpLeftCorner))
                {
                    destroyObject.HaveCollision = true;
                }

                if (!destroyObject.HaveCollision)
                {
                    gameObjectsList.Add(collectObject);
                    collectObject.SetPositionsCoordinates();
                }
            }

            while (gameObjectsList.Count > 0)
            {
                current = gameObjectsList[gameObjectsList.Count - 1];
                gameObjectsList.RemoveAt(gameObjectsList.Count - 1);

                if (!current.HaveCollision)
                {
                    PrintGameObject.PrintObject(current);
                    newGameObjectsList.Add(current);
                }
            }

            if (plane.Lives < 0)
            {
                settings.GameOver = true;
                break;
            }

            gameObjectsList = newGameObjectsList;
            newGameObjectsList = new List<GameObject>();

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                plane.Clear();

                if (keyPressed.Key == ConsoleKey.UpArrow)
                {
                    plane.Position.X--;

                    if (plane.Position.X < 1)
                    {
                        plane.Position.X = 1;
                    }
                }

                if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    plane.Position.X++;

                    if (plane.Position.X > settings.Height - plane.PlaneHeight)
                    {
                        plane.Position.X = settings.Height - plane.PlaneHeight;
                    }
                }

                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    plane.Position.Y--;

                    if (plane.Position.Y < 0)
                    {
                        plane.Position.Y = 0;
                    }
                }

                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    plane.Position.Y++;

                    if (plane.Position.Y > settings.Width - plane.PlaneWidth)
                    {
                        plane.Position.Y = settings.Width - plane.PlaneWidth;
                    }
                }

                if (keyPressed.Key == ConsoleKey.Spacebar)
                {
                    projectile = new Projectile(new Point(plane.Position.X - 1, plane.Position.Y + plane.PlaneWidth / 2));

                    if (CheckCollisionWhitOtherObject(projectile.UpLeftCorner))
                    {
                        projectile.HaveCollision = true;
                    }
                    else
                    {
                        gameObjectsList.Add(projectile);
                    }

                    PrintGameObject.PrintObject(projectile);
                }

                if (keyPressed.Key == ConsoleKey.P)
                {
                    PauseScreenPage pause = new PauseScreenPage();
                    pause.PauseMain();
                    settings.Pause = !settings.Pause;
                    Console.ReadKey();
                    Console.Clear();
                }


                plane.SetPlaneCoordinates();
                bool haveCollision = CheckPlaneCollision();

                if (haveCollision)
                {
                    plane.Lives--;
                }

                if (plane.Lives < 0)
                {
                    settings.GameOver = true;
                    break;
                }

                plane.Print();
            }

            while (gameObjectsList.Count > 0)
            {
                current = gameObjectsList[gameObjectsList.Count - 1];
                gameObjectsList.RemoveAt(gameObjectsList.Count - 1);

                PrintGameObject.ClearObject(current);

                current.Move();
                current.SetPositionsCoordinates();

                if (CheckCollisionWhitPlane(current, plane))
                {
                    current.HaveCollision = true;
                    plane.Lives--;
                }
                else if (CheckCollisionWhitOtherObject(current.UpLeftCorner))
                {
                    current.HaveCollision = true;
                }
                else
                {
                    PrintGameObject.PrintObject(current);
                    newGameObjectsList.Add(current);
                }
            }

            gameObjectsList = newGameObjectsList;
            newGameObjectsList = new List<GameObject>();

            status.Score += 1;
            Thread.Sleep(sleepTime);
        }

        Settings.PrintGameOver();
    }

    private bool CheckCollisionWhitOtherObject(Point point)
    {
        bool haveCollision = false;

        foreach (var obj in gameObjectsList)
        {
            foreach (var o in obj.PositionsCoordinates)
            {
                if (point.GetHashCode() == o.GetHashCode())
                {
                    obj.HaveCollision = true;
                    return true;
                }
            }
        }

        return haveCollision;
    }

    private bool CheckPlaneCollision()
    {
        bool haveCollision = false;

        foreach (var point in plane.PositionCoordinate)
        {
            foreach (var obj in gameObjectsList)
            {
                foreach (var o in obj.PositionsCoordinates)
                {
                    if (point.GetHashCode() == o.GetHashCode())
                    {
                        if (obj is CollectedObject)
                        {
                            settings.Score += 5;
                        }
                        else if (obj is DestroyObject)
                        {
                            haveCollision = true;
                            obj.HaveCollision = true;
                        }
                    }
                }
            }
        }

        return haveCollision;
    }

    private bool CheckCollisionWhitCollectedObject(Point currentPoint)
    {
        bool isCollectedObject = false;

        foreach (var obj in gameObjectsList)
        {
            foreach (var point in obj.PositionsCoordinates)
            {
                if (point.GetHashCode() == currentPoint.GetHashCode())
                {
                    if (obj is CollectedObject)
                    {
                        return true;
                    }
                }
            }
        }

        return isCollectedObject;
    }


    private bool CheckCollisionWhitPlane(GameObject current, Player plane)
    {
        bool haveCollision = false;

        foreach (var objectPosition in current.PositionsCoordinates)
        {
            foreach (var planePosition in plane.PositionCoordinate)
            {
                if (objectPosition.GetHashCode() == planePosition.GetHashCode())
                {
                    return true;
                }
            }
        }

        return haveCollision;
    }
}

