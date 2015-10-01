using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FermiInTheAir.Utility
{
    public class PlaneSettings
    {

        public static ConsoleColor planeColor = ConsoleColor.Red;
        public static bool planeOneIsSelected = true; //by default
        public static bool planeTwoIsSelected = false;
        public static bool planeThreeIsSelected = false;

        private static void WriteLines(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }
        }

        public static void SelectPlane()
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

        public static void SelectPlaneColor()
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
    }
}
