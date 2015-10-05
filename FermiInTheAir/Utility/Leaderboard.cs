using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace FermiInTheAir.Utility
{
    public class Leaderboard
    {
        public static void WriteScores(int currentScore, string playerName, DateTime currentDate)
        {

            List<Tuple<int, Tuple<string, string>>> leaderboard = new List<Tuple<int, Tuple<string, string>>>();
            StreamReader scoreReader = new StreamReader(@"../../score.txt");
            using (scoreReader)
            {
                try
                {
                    string[] score = scoreReader.ReadLine().Split(' ');
                    while (score != null)
                    {
                        leaderboard.Add(new Tuple<int, Tuple<string, string>>(Convert.ToInt32(score[0]), new Tuple<string, string>(score[1], score[2])));
                        score = scoreReader.ReadLine().Split(' ');
                    }
                }
                catch (Exception)
                {
                }
            }
            leaderboard.Add(new Tuple<int, Tuple<string, string>>(currentScore, new Tuple<string, string>(playerName, currentDate.ToString())));
            leaderboard = leaderboard.OrderByDescending(x => x.Item1).ToList();

            StreamWriter scoreWriter = new StreamWriter(@"../../score.txt");
            using (scoreWriter)
            {
                int scoresCount = 1;
                foreach (var leader in leaderboard)
                {
                    if (scoresCount == 11)
                    {
                        break;
                    }

                    scoreWriter.WriteLine(leader.Item1.ToString() + " " + leader.Item2.Item1.ToString() + " " + leader.Item2.Item2.ToString());
                    scoresCount++;
                }
            }
        }

        public static void ViewScores()
        {
            Console.Clear();
            StreamReader scoreReader = new StreamReader(@"../../score.txt");
            string[] score = scoreReader.ReadLine().Split(' ');
            WriteLines(6);
            if (score == null)
            {
                Console.WriteLine("\t\t\tThere aren't any records yet!");
                //TODO: some design
                scoreReader.Close();
                return;
            }
            Console.WriteLine("\tRank:\t\tPlayer:\t\tTotal score:\t\tDate:");
            WriteLines(3);
            using (scoreReader)
            {
                int rank = 1;
                while (score != null)
                {
                    if (rank%2==0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.WriteLine("\t{0}\t\t{1}\t\t{2}\t\t\t{3}", rank, score[1], score[0], score[2]);
                    Console.WriteLine();
                    try
                    {
                        score = scoreReader.ReadLine().Split(' ');
                    }
                    catch (Exception)
                    {
                        Console.ResetColor();
                        WriteLines(3);
                        Console.WriteLine("\t\t     << Press <Enter> to start a new game >>");
                        Console.WriteLine();
                        Console.WriteLine("\t\t       << Press <m> to go to main menu >>");
                        ConsoleKeyInfo action = Console.ReadKey();

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
                        return;
                    }
                    rank++;
                }

                
                //TODO: some design
            }
        }
        public static void WriteLines(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
