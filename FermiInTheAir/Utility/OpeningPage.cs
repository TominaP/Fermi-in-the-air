using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FermiInTheAir.Utility
{
    public class OpeningPage
    {
        public static ConsoleColor planeColor = ConsoleColor.Red;
        public static bool planeOneIsSelected = true; //by default
        public static bool planeTwoIsSelected = false;
        public static bool planeThreeIsSelected = false;

        public static void FrontPageGameName()
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
            Console.WriteLine("\n");
            foreach (string line in nameGame1)
                Console.WriteLine(line);

            foreach (string line in artGame)
                Console.WriteLine(line);
            Console.WriteLine("\n");
            foreach (string line in nameGame2)
                Console.WriteLine(line);

            System.Threading.Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string msg = "Press <ENTER> ... if you dare !!!";
            Console.WriteLine("\n \n {0, 50}", msg);
            Console.ReadKey();

            while (true)
            {
                ConsoleKeyInfo action = Console.ReadKey();
                if (action.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    OpeningPage.OpenPage();
                }

            }

        }


        public static void OpenPage()
        {
            Console.WindowWidth = 80;
            Console.WindowHeight = 40;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            Header();

            string teamName = "FERMI";
            string game = "in the air";
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("{0}{1}{0}", new string(' ', (80 - teamName.Length - 1) / 2), teamName);
            Console.WriteLine("{0}{1}{0}", new string(' ', (80 - game.Length - 1) / 2), game);
            WriteLines(2);

            Console.WriteLine("{0}<< Press <Enter> to start a new game >>",
                new string(' ', (80 - "<< Press <Enter> to start a new game >>".Length - 1) / 2));
            WriteLines(3);

            Console.WriteLine(new string(' ', (80 - "<< Press <p> to change plane >>".Length - 1) / 2)
                + "<< Press <p> to change plane >>");
            WriteLines(3);

            Console.WriteLine(new string(' ', (80 - "<< Press <c> to change plane's color >>".Length - 1) / 2)
                + "<< Press <c> to change plane's color >>");
            WriteLines(3);

            Console.WriteLine("{0}A game by Fermi ©2015{0}", new string(' ', (80 - "A game by Fermi ©2015".Length - 1) / 2));

            Footer();

            while (true)
            {
                ConsoleKeyInfo action = Console.ReadKey();
                if (action.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Engine eng = new Engine();
                    eng.Run();
                }
                else if (action.Key == ConsoleKey.C)
                {
                    SelectPlaneColor();
                }
                else if (action.Key == ConsoleKey.P)
                {
                    SelectPlane();
                }
            }

        }

        private static void SelectPlane()
        {
            Console.Clear();
            while (true)
            {
                WriteLines(11);
                Console.WriteLine(new string(' ', 20) + "Plane #1: <<Press <1> to select this plane.>>");
                Console.WriteLine();
                Console.ForegroundColor = planeColor;
                Console.WriteLine(new string(' ', 35) + "       []");
                Console.WriteLine(new string(' ', 35) + " _____[  ]_____");
                Console.WriteLine(new string(' ', 35) + @"/___[FERMI]____\");
                Console.WriteLine(new string(' ', 35) + "      [  ]");
                Console.WriteLine(new string(' ', 35) + "     --[]--");
                Console.ResetColor();
                WriteLines(6);

                Console.WriteLine(new string(' ', 20) + "Plane #2: <<Press <2> to select this plane.>>");
                Console.WriteLine();
                Console.ForegroundColor = planeColor;

                Console.WriteLine(new string(' ', 35) + "        |");
                Console.WriteLine(new string(' ', 35) + "       +++");
                Console.WriteLine(new string(' ', 35) + "     #=====#");
                Console.WriteLine(new string(' ', 35) + "******************");
                Console.WriteLine(new string(' ', 35) + "******************");
                Console.WriteLine(new string(' ', 35) + "     #######");
                Console.WriteLine(new string(' ', 35) + "  //    ||    \\");
                Console.ResetColor();
                WriteLines(6);

                Console.WriteLine(new string(' ', 20) + "Plane #3: <<Press <3> to select this plane.>>");
                Console.WriteLine();
                Console.ForegroundColor = planeColor;

                Console.WriteLine(new string(' ', 35) + @"         ^");
                Console.WriteLine(new string(' ', 35) + @"        (*)");
                Console.WriteLine(new string(' ', 35) + @"        (*)");
                Console.WriteLine(new string(' ', 35) + @"       // \\");
                Console.WriteLine(new string(' ', 35) + @"      /|/*\|\");
                Console.WriteLine(new string(' ', 35) + @"     /_FERMI_\");
                Console.WriteLine(new string(' ', 35) + @"     \/     \/");
                Console.ResetColor();

                ConsoleKeyInfo action = Console.ReadKey();
                Console.Clear();
                if (action.Key == ConsoleKey.NumPad1 || action.Key == ConsoleKey.D1)
                {
                    planeTwoIsSelected = false;
                    planeOneIsSelected = true;
                    planeThreeIsSelected = false;
                }
                else if (action.Key == ConsoleKey.NumPad2 || action.Key == ConsoleKey.D2)
                {
                    planeOneIsSelected = false;
                    planeTwoIsSelected = true;
                    planeThreeIsSelected = false;
                }
                else if (action.Key == ConsoleKey.NumPad3 || action.Key == ConsoleKey.D3)
                {
                    planeOneIsSelected = false;
                    planeTwoIsSelected = false;
                    planeThreeIsSelected = true;
                }

                WriteLines(16);
                Console.WriteLine("\t\t\tYou have chosen this plane #" + action.KeyChar);
                Console.ForegroundColor = ConsoleColor.Gray;
                WriteLines(3);
                Console.WriteLine("\t\t\t<< Press <Enter> to start a new game >>");
                Console.WriteLine();
                Console.WriteLine("\t\t\t<< Press <m> to go to main menu >>");
                action = Console.ReadKey();
                if (action.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Engine eng = new Engine();
                    eng.Run();
                }
                else if (action.Key == ConsoleKey.M)
                {
                    Console.Clear();
                    OpeningPage.OpenPage();
                }

                Console.ResetColor();
                Console.Clear();
            }
        }

        private static void WriteLines(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }
        }
        private static void SelectPlaneColor()
        {
            Console.Clear();
            WriteLines(10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t<< Press <r> for red plane >>");
            WriteLines(5);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t<< Press <b> for blue plane >>");
            WriteLines(5);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t<< Press <g> for green plane >>");
            WriteLines(5);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t<< Press <y> for yellow plane >>");
            ConsoleKeyInfo color = Console.ReadKey();

            Console.Clear();
            Console.ResetColor();
            WriteLines(16);
            Console.Write("\t\t\tYour plane is now ");

            switch (color.KeyChar)
            {
                case 'r':
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("red.");
                    planeColor = ConsoleColor.Red;
                    break;
                case 'b':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("blue.");
                    planeColor = ConsoleColor.Blue;
                    break;
                case 'g':
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("green.");
                    planeColor = ConsoleColor.Green;
                    break;
                case 'y':
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("yellow.");
                    planeColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.WriteLine("red by default."); //any other key
                    break;
            }


            Console.ForegroundColor = ConsoleColor.Gray;
            WriteLines(3);
            Console.WriteLine("\t\t\t<< Press <Enter> to start a new game >>");
            Console.WriteLine();
            Console.WriteLine("\t\t\t<< Press <m> to go to main menu >>");
            ConsoleKeyInfo go = Console.ReadKey();
            if (go.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Engine eng = new Engine();
                eng.Run();
            }
            else if (go.Key == ConsoleKey.M)
            {
                Console.Clear();
                OpeningPage.OpenPage();
            }

            Console.ResetColor();
        }


        static void Header()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string('*', 80));
            Console.WriteLine(new string('*', 80));
            for (int i = 3; i >= 0; i--)
            {
                Console.WriteLine("{0}{1}{0}", new string('*', i), new string(' ', 80 - 2 * i));
            }
            Console.ResetColor();
        }
        static void Footer()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string('*', i), new string(' ', 80 - 2 * i));
            }
            Console.WriteLine(new string('*', 80));
            Console.WriteLine(new string('*', 80));
            Console.ResetColor();
            //Console.Read();
        }
    }
}