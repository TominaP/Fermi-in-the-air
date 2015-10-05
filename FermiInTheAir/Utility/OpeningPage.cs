using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace FermiInTheAir.Utility
{
    public class Music
    {
        private static string Source = "http://www.thesoundarchive.com/starwars/imperial_march.wav";

        public Music()
        {
            this.Play();
        }

        public void Play()
        {
            SoundPlayer player = new SoundPlayer(Source);

            using (player)
            {
                player.PlayLooping();
            }
        }
    }



    public class OpeningPage
    {

        public static void FrontPageGameName()
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;

            var nameGame1 = new[]
            {
            @"   *  _______   _______  .______       .___  ___.   __    *                        *          ",
            @"     |   ____| |   ____| |   _  \  *   |   \/   |  |  |             *                      *  ",
            @"     |  |__    |  |__*   |  |_)  |     |  \  /  |  |  |                                       ",
            @"  *  |   __|   |   __|   |      /    * |  |\/|  |  |  |                   *                   ",
            @"     |  |      |  |____  |  |\  \----. |  |  |  |  |  |                                *      ",
            @"     |__|  *   |_______| | _| `._____| |__| *|__|  |__|     *                                 ",


            };

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            var artGame = new[]
            {

                @"     *                                                                           ,o888      ",
                @"                                                    *                         ,o888888'  *  ",
                @"            *               /\         *               ,:o: o: oooo.    *   ,8O88Pd88       ",
                @"                           (  )                     ,.::.::o:ooooOoOoO. ,oO8O8Pd888'        ",
                @"                     *     (  )                   ,.:.::o:ooOoOoOO8O8OOo 8OOPd8O8O          ",
                @"                          /|/\|\                 , ..:.::o:ooOoOOOO8OOOOo FdO8O8            ",
                @"        *                /_||||_\               , ..:.::o:ooOoOO8O888O8O,COCOO              ",
                @"                                               , . ..:.::o:ooOoOOOO8OOOOCOCO       *        ",
                @"                   *                 *          . ..:.::o:ooOoOoOO8O8OCCC Co                ",
                @"            /\                                     . ..:.::o:ooooOoCoCCC o:o                ",
                @"   *       (  )                                    . ..:.::o:o:,cooooCo oo:o:               ",
                @"           (  )              *                  `   . . ..:.:cocoooo 'o:o:::'    *          ",
                @"          /|/\|\                       *        .`   . ..::ccccoc 'o:o:o:::'          *     ",
                @"         /_||||_\                              :.:.    ,c: cccc ':.:.:.:.:.'                ",
                @"                       *          *            ..:.: '`::::c:'..:.:.:.:.:.'            *    ",
                @"                                             ...:.'.:.:::: '   . . . . .'                   ",
                @"           *                                .. . ....:. ' `   . . . ''                      ",
                @"    *           *              *            . . ... '                           *           ",
                @"                                           . . ..                                           ",
                @"                     *                    . .                  *                            "

            };

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;

            var nameGame2 = new[]
            {
                @"    __  .__   __.    .___________. __    __   _______     *   ___       __  .______       ",
                @"   |  | |  \ |  |    |           ||  |  |  | |   ____|       /   \     |  | |   _  \   *  ",
                @"  *|  | |   \|  | *  `---|  |----`|  |__|  |*|  |__      *  /  ^  \    |  | |  |_)  |     ",
                @"   |  | |  . `  |      * |  |     |   __   | |   __|       /  /_\  \  *|  | |      / *    ",
                @"   |  | |  |\   |        |  |  *  |  |  |  | |  |____     /  _____  \  |  | |  |\  \----. ",
                @" * |__| |__| \__| *      |__|     |__|  |__| |_______|*  /__/     \__\ |__| | _| `._____| ",
            };

            Console.WindowWidth = 95; //previous WindowWidth = 140
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

            while (true)
            {
                ConsoleKeyInfo action = Console.ReadKey();
                if (action.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    OpeningPage.OpenPage();
                    return;
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
            WriteLines(2);

            Console.WriteLine(new string(' ', (80 - "<< If you don't want music press <N>, and if you want press <Y>. >>".Length - 1) / 2)
                + "<< If you don't want music press <N>, and if you want press <Y>. >>");
            WriteLines(2);

            Console.WriteLine(new string(' ', (80 - "<< Press <p> to change plane >>".Length - 1) / 2)
                + "<< Press <p> to change plane >>");
            WriteLines(2);

            Console.WriteLine(new string(' ', (80 - "<< Press <c> to change plane's color >>".Length - 1) / 2)
                + "<< Press <c> to change plane's color >>");
            WriteLines(2);

            Console.WriteLine("{0}A game by Fermi ©2015{0}", new string(' ', (80 - "A game by Fermi ©2015".Length - 1) / 2));

            Footer();

            while (true)
            {
                ConsoleKeyInfo action = Console.ReadKey();
                if (action.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    return;
                }
                else if (action.Key == ConsoleKey.C)
                {
                    PlaneSettings.SelectPlaneColor();
                }
                else if (action.Key == ConsoleKey.P)
                {
                    PlaneSettings.SelectPlane();
                }
                else if (action.Key == ConsoleKey.Y)
                {
                    Music music = new Music();
                }
            }
        }

        private static void WriteLines(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }
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
