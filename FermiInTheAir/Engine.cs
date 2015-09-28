using FermiInTheAir.GameObjects;
using FermiInTheAir.Utility;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FermiInTheAir
{
    public class Engine
    {
        private HashSet<GameObject> gameObjectLsit = new HashSet<GameObject>();
        private Random rnd = new Random();
        Settings settings = new Settings();
        Player plane = new Player();
        private DestroyObject destoyObject;
        private CollectedObject collectObject;

        public void Run()
        {
            while (!settings.GameOver)
            {
                // adding chance to spawn @ 25%               
                int chanceToSpawn = rnd.Next(0, 100);


                if (chanceToSpawn <= 40)
                {
                    int objXPosition = 0;
                    int objYPosition = rnd.Next(0, settings.Width - 2);
                    destoyObject = new DestroyObject(new Point(objXPosition, objYPosition));
                    gameObjectLsit.Add(destoyObject);
                }

                if (chanceToSpawn <= 15)
                {
                    int objXPosition = 0;
                    int objYPosition = rnd.Next(0, settings.Width - 1);
                    collectObject = new CollectedObject(new Point(objXPosition, objYPosition));
                    gameObjectLsit.Add(collectObject);
                }


                foreach (var obj in gameObjectLsit)
                {
                    if (!obj.HaveCollision)
                    {
                        PrintGameObject.PrintObject(obj);
                    }
                }
                plane.Print();


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo direction = Console.ReadKey();
                    plane.Clear();
                    if (direction.Key == ConsoleKey.UpArrow)
                    {
                        plane.Position.X--;

                        if (plane.Position.X < 0)
                        {
                            plane.Position.X = 0;
                        }
                    }

                    if (direction.Key == ConsoleKey.DownArrow)
                    {
                        plane.Position.X++;

                        if (plane.Position.X >= settings.Height - plane.PlaneHeight)
                        {
                            plane.Position.X = settings.Height - plane.PlaneHeight - 1;
                        }
                    }

                    if (direction.Key == ConsoleKey.LeftArrow)
                    {
                        plane.Position.Y--;

                        if (plane.Position.Y < 0)
                        {
                            plane.Position.Y = 0;
                        }
                    }

                    if (direction.Key == ConsoleKey.RightArrow)
                    {
                        plane.Position.Y++;

                        if (plane.Position.Y >= settings.Width - plane.PlaneWidth)
                        {
                            plane.Position.Y = settings.Width - plane.PlaneWidth - 1;
                        }
                    }

                    plane.Print();

                }

                foreach (var obj in gameObjectLsit)
                {
                    PrintGameObject.ClearObject(obj);
                    obj.Move();
                    if (!obj.HaveCollision)
                    {
                        PrintGameObject.PrintObject(obj);
                    }

                }

                Thread.Sleep(200);
            }
            Settings.PrintGameOver();
        }
    }
}

