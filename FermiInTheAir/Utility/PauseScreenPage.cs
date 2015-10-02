using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FermiInTheAir.Utility
{
    public class PauseScreenPage
    {
        public void PauseMain()
        {
            Header();
            Footer();
        }

        static void Header()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(new string('*', 80));
            }

            WritingLines(4);

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
            WritingLines(2);
        }
        static void Footer()
        {
            WritingLines(3);
            Console.ForegroundColor = ConsoleColor.Red;
            string paused = "The game is paused";
            Console.WriteLine("{0}{1}{0}", new string(' ', (80 - paused.Length - 1) / 2), paused);
            string printing = "Press any key to continue:";
            Console.WriteLine("{0}{1}{0}", new string(' ', (80 - printing.Length - 1) / 2), printing);

            WritingLines(4);

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
}
