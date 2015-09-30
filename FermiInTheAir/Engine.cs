using FermiInTheAir.GameObjects;
using FermiInTheAir.Utility;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FermiInTheAir
{
    public class Engine
    {
        private Queue<GameObject> gameObjectsList = new Queue<GameObject>();
        private Queue<GameObject> newGameObjectsList = new Queue<GameObject>();

        private Queue<Projectile> projectilesFired = new Queue<Projectile>();
        private Queue<Projectile> projectilesInAir = new Queue<Projectile>();


        private Random rnd = new Random();
        Settings settings = new Settings();
        Player plane = new Player();
        private DestroyObject destroyObject;
        private CollectedObject collectObject;
        private GameObject current;
        private Projectile projectile;
        private int sleepTime = 300;

        public void Run()
        {
            plane.Print();

            while (!settings.GameOver)
            {
                // adding chance to spawn @ 25%               
                int chanceToSpawn = rnd.Next(0, 100);


                if (chanceToSpawn <= 80)
                {
                    int objXPosition = 0;
                    int objYPosition = rnd.Next(0, settings.Width - 2);
                    destroyObject = new DestroyObject(new Point(objXPosition, objYPosition));
                    gameObjectsList.Enqueue(destroyObject);
                }

                if (chanceToSpawn <= 15)
                {
                    int objXPosition = 0;
                    int objYPosition = rnd.Next(0, settings.Width - 1);
                    collectObject = new CollectedObject(new Point(objXPosition, objYPosition));
                    gameObjectsList.Enqueue(collectObject);
                }


                while (gameObjectsList.Count > 0)
                {
                    current = gameObjectsList.Dequeue();

                    if (!current.HaveCollision)
                    {
                        PrintGameObject.PrintObject(current);
                        newGameObjectsList.Enqueue(current);
                    }
                }
               
                gameObjectsList = newGameObjectsList;
                newGameObjectsList = new Queue<GameObject>();


                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey();

                    plane.Clear();

                    if (keyPressed.Key == ConsoleKey.UpArrow)
                    {
                        plane.Position.X--;

                        if (plane.Position.X < 0)
                        {
                            plane.Position.X = 0;
                        }
                    }

                    if (keyPressed.Key == ConsoleKey.DownArrow)
                    {
                        plane.Position.X++;

                        if (plane.Position.X >= settings.Height - plane.PlaneHeight)
                        {
                            plane.Position.X = settings.Height - plane.PlaneHeight - 1;
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

                        if (plane.Position.Y >= settings.Width - plane.PlaneWidth)
                        {
                            plane.Position.Y = settings.Width - plane.PlaneWidth - 1;
                        }
                    }

                    if (keyPressed.Key == ConsoleKey.Spacebar)
                    {
                        projectile = new Projectile(new Point(plane.Position.X - 1, plane.Position.Y + plane.PlaneWidth / 2));
                        projectilesFired.Enqueue(projectile);
                        PrintGameObject.PrintObject(projectile);
                    }

                    if (keyPressed.Key == ConsoleKey.P)
                    {
                        //TODO : Print pause screen
                        settings.Pause = !settings.Pause;
                        Console.ReadKey();
                    }


                    plane.Print();

                }


                while (projectilesFired.Count > 0)
                {
                    Projectile current = projectilesFired.Dequeue();
                    PrintGameObject.ClearObject(current);
                    current.Move();

                    if (!current.HaveCollision)
                    {
                        PrintGameObject.PrintObject(current);
                        projectilesInAir.Enqueue(current);
                    }
                }

                projectilesFired = projectilesInAir;
                projectilesInAir = new Queue<Projectile>();


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
                    current = gameObjectsList.Dequeue();
                    PrintGameObject.ClearObject(current);
                    current.Move();

                    if (!current.HaveCollision)
                    {
                        PrintGameObject.PrintObject(current);
                        newGameObjectsList.Enqueue(current);
                    }
                }

                gameObjectsList = newGameObjectsList;
                newGameObjectsList = new Queue<GameObject>();
               

                Thread.Sleep(sleepTime);
            }

            Settings.PrintGameOver();
        }
    }
}

