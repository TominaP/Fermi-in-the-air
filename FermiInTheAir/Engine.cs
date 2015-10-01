using FermiInTheAir.GameObjects;
using FermiInTheAir.Utility;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FermiInTheAir
{
    class PauseScreenPage
    {
         public static void PauseMain()
        {
            Header();
            Footer();


            Console.ReadKey(true);
            if (true)
            {
                //the game is starting again
            }
        }

        static void Header()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(new string('*', 80));
            }

            WritingLines(5);

            string[] team =
            {
            "             !$$$$$$$!  |#######|   %%%@@@@     &&&++    ++&&&   XXX            ",
            "             !$$!       |##|        %%%   @@    &&& ++  ++ &&&   XXX            ",
            "             !$$!       |##|        %%%  @@@    &&&   ++   &&&   XXX            ",
            "             !$$$$$$$!  |#######|   %%%@@@      &&&        &&&   XXX            ",
            "             !$$!       |##|        %%% @@@     &&&        &&&   XXX            ",
            "             !$$!       |#######|   %%%  @@@    &&&        &&&   XXX            ",
        };
            for (int i = 0; i < team.Length; i++)
            {
                Console.WriteLine(team[i]);
            }
            Console.WriteLine();
            string[] logo =
            {
            @"       ()  1\\   1     <<<<>>>> ||   ||  010101          //\\     /\  ??&&      ",
            @"       ()  1 \\  1        ^^    ||___||  01,,,          //  \\    /\  ?? @@     ",
            @"       ()  1  \\ 1        ^^    ||   ||  01'''         //====\\   /\  ??%%      ",
            @"       ()  1   \\1        ^^    ||   ||  010101       //      \\  /\  ?? ##     "
        };
            for (int i = 0; i < logo.Length; i++)
            {
                Console.WriteLine(logo[i]);
            }
            WritingLines(3);
        }
        static void Footer()
        {
            WritingLines(5);
            Console.ForegroundColor = ConsoleColor.Red;
            string paused = "The game is paused";
            Console.WriteLine("{0}{1}{0}", new string(' ', (80 - paused.Length - 1) / 2), paused);
            string printing = "Press any key to continue:";
            Console.WriteLine("{0}{1}{0}", new string(' ', (80 - printing.Length - 1) / 2), printing);

            WritingLines(8);

            string producers = "One game produced by team Fermi, SoftUni";
            Console.WriteLine("{0}{1}{0}", new string(' ', (80 - producers.Length - 1) / 2), producers);
            Console.WriteLine("{0}{1}{0}", new string(' ', 74 / 2), "2015");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(new string('*', 80));
            }
        }
        static void WritingLines(int line)
        {
            for (int i = 0; i < line; i++)
            {
                Console.WriteLine();
            }
        }
    }

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

            status.ClearStatus();
            status.PrintStatus();

            while (!settings.GameOver)
            {
                // adding chance to spawn @ 25%               
                int chanceToSpawn = rnd.Next(0, 100);


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
                        projectilesFired.AddLast(projectile);
                        PrintGameObject.PrintObject(projectile);
                    }

                    if (keyPressed.Key == ConsoleKey.P)
                    {
                        //added PauseScreen
                        PauseScreenPage pause = new PauseScreenPage();
                        settings.Pause = !settings.Pause;
                        Console.ReadKey();
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


                Thread.Sleep(sleepTime);
            }

            Settings.PrintGameOver();
        }
    }
}
