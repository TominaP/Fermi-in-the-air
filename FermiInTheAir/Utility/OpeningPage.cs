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
        public static void OpenPage()
        {
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
            
            Console.WriteLine(new string(' ', (80 - "<< Press <p> to change plane >> (under construction)".Length - 1) / 2)
                + "<< Press <p> to change plane >> (under construction)");
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
                    SelectPlane(); // TODO
                }
            }

        }

        private static void SelectPlane()
        {
            throw new NotImplementedException();
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