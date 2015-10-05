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

    private List<Projectile> projectilesFired = new List<Projectile>();
    private List<Projectile> projectilesInAir = new List<Projectile>();
    private Dictionary<int, int> objectPosition = new Dictionary<int, int>();//coordinates and index of gameobjects
    private Dictionary<int, int> newObjectPosition = new Dictionary<int, int>();//coordinates and index of gameobjects

    StatusLine status = new StatusLine();
    Settings settings = new Settings();
    Player plane = new Player();

    private Random rnd = new Random();
    private DestroyObject destroyObject;
    private CollectedObject collectObject;
    private GameObject current;
    private Projectile projectile;
    private int projectileCode;
    private int sleepTime = 300;

    public void Run()
    {
        plane.Print();


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
                gameObjectsList.Add(destroyObject);
            }

            if (chanceToSpawn <= 15)
            {
                int objXPosition = 1;
                int objYPosition = rnd.Next(0, settings.Width);
                collectObject = new CollectedObject(new Point(objXPosition, objYPosition));
                gameObjectsList.Add(collectObject);
            }

            gameObjectsList.RemoveAll(go => go.HaveCollision == true);
            while (gameObjectsList.Count > 0)
            {
                current = gameObjectsList.First();
                gameObjectsList.RemoveAt(0);

                if (!current.HaveCollision)
                {
                    PrintGameObject.PrintObject(current);
                    newGameObjectsList.Add(current);
                    newObjectPosition.Add(current.GetHashCode(), newGameObjectsList.IndexOf(current));//add gameObject to hash by its position
                }
            }

            gameObjectsList = newGameObjectsList;
            newGameObjectsList = new List<GameObject>();

            objectPosition = newObjectPosition;
            newObjectPosition = new Dictionary<int, int>();

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
                    projectileCode = projectile.GetHashCode();

                    if (objectPosition.ContainsKey(projectileCode))//have collision
                    {
                        projectile.HaveCollision = true;
                        gameObjectsList.ElementAt(objectPosition.ElementAt(projectileCode).Value).HaveCollision = true;
                        objectPosition.Remove(projectile.GetHashCode());
                    }
                    else
                    {
                        projectilesFired.Add(projectile);
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

                plane.Print();
            }

            //Check projectilesFired
            projectilesFired.RemoveAll(pr => pr.HaveCollision == true);
            while (projectilesFired.Count > 0)
            {
                Projectile projectile = projectilesFired.First();
                projectilesFired.RemoveAt(0);
                PrintGameObject.ClearObject(projectile);
                projectile.Move();
                projectileCode = projectile.GetHashCode();

                if (objectPosition.ContainsKey(projectileCode))//have collision
                {
                    projectile.HaveCollision = true;
                    gameObjectsList.ElementAt(objectPosition[projectileCode]).HaveCollision = true;
                    objectPosition.Remove(projectile.GetHashCode());
                }
                else
                {
                    PrintGameObject.PrintObject(projectile);
                    projectilesInAir.Add(projectile);
                }
            }

            projectilesFired = projectilesInAir;
            projectilesInAir = new List<Projectile>();

   
            while (gameObjectsList.Count > 0)
            {

                current = gameObjectsList.First();
                gameObjectsList.RemoveAt(0);
                PrintGameObject.ClearObject(current);
                current.Move();
                if (projectilesFired.Exists(p => p.GetHashCode() == current.GetHashCode()))//collision
                {
                    current.HaveCollision = true;
                    PrintGameObject.PrintObject(current);
                }
                else
                {
                    PrintGameObject.PrintObject(current);
                    newGameObjectsList.Add(current);
                    newObjectPosition.Add(current.GetHashCode(), newGameObjectsList.IndexOf(current));//add gameObject to hash by its position
                }
            }

            gameObjectsList = newGameObjectsList;
            newGameObjectsList = new List<GameObject>();

            objectPosition = newObjectPosition;
            newObjectPosition = new Dictionary<int, int>();

            status.Score += 1;
            Thread.Sleep(sleepTime);


            //foreach (var projectile in projectilesFired)
            //{
            //    if (projectile.UpLeftCorner.X >= 0)
            //    {
            //        PrintGameObject.ClearObject(projectile);
            //        projectile.Move();
            //        if (projectile.UpLeftCorner.X > 0)
            //        {
            //            PrintGameObject.PrintObject(projectile);
            //        }
            //    }
            //}

        }

        Settings.PrintGameOver();

    }
}

