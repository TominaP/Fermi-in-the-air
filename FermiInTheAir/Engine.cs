using FermiInTheAir.GameObjects;
using FermiInTheAir.Utility;
using System;
using System.Collections.Generic;
using System.Threading;


public class Engine
{
    private LinkedList<GameObject> gameObjectsList = new LinkedList<GameObject>();
    private LinkedList<GameObject> newGameObjectsList = new LinkedList<GameObject>();

    private LinkedList<Projectile> projectilesFired = new LinkedList<Projectile>();
    private LinkedList<Projectile> projectilesInAir = new LinkedList<Projectile>();
    private HashSet<int> objectPosition = new HashSet<int>();//3200

    StatusLine status = new StatusLine();
    Settings settings = new Settings();
    Player plane = new Player();

    private Random rnd = new Random();
    private DestroyObject destroyObject;
    private CollectedObject collectObject;
    private LinkedListNode<GameObject> current;
    private Projectile projectile;
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
                gameObjectsList.AddLast(destroyObject);
            }

            if (chanceToSpawn <= 15)
            {
                int objXPosition = 1;
                int objYPosition = rnd.Next(0, settings.Width);
                collectObject = new CollectedObject(new Point(objXPosition, objYPosition));
                gameObjectsList.AddLast(collectObject);
            }


            while (gameObjectsList.Count > 0)
            {
                current = gameObjectsList.First;
                gameObjectsList.RemoveFirst();

                if (!current.Value.HaveCollision)
                {
                    PrintGameObject.PrintObject(current.Value);
                    newGameObjectsList.AddLast(current.Value);
                }
            }

            gameObjectsList = newGameObjectsList;
            newGameObjectsList = new LinkedList<GameObject>();


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
                    projectilesFired.AddLast(projectile);
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


            while (projectilesFired.Count > 0)
            {
                Projectile current = (projectilesFired.First).Value;
                projectilesFired.RemoveFirst();
                PrintGameObject.ClearObject(current);
                current.Move();

                if (!current.HaveCollision)
                {
                    PrintGameObject.PrintObject(current);
                    projectilesInAir.AddLast(current);
                }
            }

            projectilesFired = projectilesInAir;
            projectilesInAir = new LinkedList<Projectile>();


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




            while (gameObjectsList.Count > 0)
            {
                current = gameObjectsList.First;
                gameObjectsList.RemoveFirst();
                PrintGameObject.ClearObject(current.Value);
                current.Value.Move();

                if (!current.Value.HaveCollision)
                {
                    PrintGameObject.PrintObject(current.Value);
                    newGameObjectsList.AddLast(current);
                }
            }

            gameObjectsList = newGameObjectsList;
            newGameObjectsList = new LinkedList<GameObject>();

            status.Score += 1;
            Thread.Sleep(sleepTime);
        }

        Settings.PrintGameOver();
    }
}

