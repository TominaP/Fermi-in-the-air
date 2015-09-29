using System;
 
class Class
{
    static void Main()
    {
        OpeningPage();
    }
    static void OpeningPage()
    {
        Header();
 
 
        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine();
        }
        string teamName = "FERMI";
        string game = "in the air";
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("{0}{1}{0}", new string(' ', (80 - teamName.Length - 1) / 2), teamName);
        Console.WriteLine("{0}{1}{0}", new string(' ', (80 - game.Length - 1) / 2), game);
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine();
        }
 
        string press = "<<Press any key to continue>>";
        Console.WriteLine("{0}{1}{0}", new string(' ', (80 - press.Length - 1) / 2), press);
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine();
        }
        string producer = "A game by Fermi";
        Console.WriteLine("{0}{1}{0}", new string(' ', (80 - producer.Length -1) / 2), producer);
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine();
        }
 
 
 
        Footer();
    }
 
 
    static void Header()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(new string('*', 80));
        Console.WriteLine(new string('*', 80));
        for (int i = 10; i >= 0; i--)
        {
            Console.WriteLine("{0}{1}{0}", new string('*', i), new string(' ', 80 - 2*i));
        }
        Console.ResetColor();
    }
    static void Footer()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('*', i), new string(' ', 80 - 2* i));
        }
        Console.WriteLine(new string('*', 80));
        Console.WriteLine(new string('*', 80));
        Console.ResetColor();
        Console.Read();
    }
}
