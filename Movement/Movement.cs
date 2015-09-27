using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movement
{
    class Movement
    {
        //The size of the console can be easily changed by changing the constants below as well as the player's position
        private const int WindowHeigth = 60;

        private const int WindowWidth = 140;

        private const int PlaneWidth = 10;

        private const int PlaneHeigth = 5;

        private static int playerPositionY = WindowWidth / 2;

        private static int playerPositionX = WindowHeigth - 1;

        static void Main(string[] args)
        {
            Console.WindowHeight = WindowHeigth;
            Console.WindowWidth = WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            Console.CursorVisible = false;

            InitializePlane(playerPositionX, playerPositionY);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo direction = Console.ReadKey();

                    if (direction.Key == ConsoleKey.UpArrow)
                    {
                        playerPositionX -= 2;

                        if (playerPositionX < 0)
                        {
                            playerPositionX = 0;
                        }
                    }

                    if (direction.Key == ConsoleKey.DownArrow)
                    {
                        playerPositionX += 2;

                        if (playerPositionX >= WindowHeigth)
                        {
                            playerPositionX = WindowHeigth - PlaneHeigth - 1;
                        }
                    }

                    if (direction.Key == ConsoleKey.LeftArrow)
                    {
                        playerPositionY -= 2;

                        if (playerPositionY < 0)
                        {
                            playerPositionY = 0;
                        }
                    }

                    if (direction.Key == ConsoleKey.RightArrow)
                    {
                        playerPositionY += 2;

                        if (playerPositionY >= WindowWidth - PlaneWidth - 2)
                        {
                            playerPositionY = WindowWidth - PlaneWidth;
                        }
                    }

                    Console.Clear();
                    InitializePlane(playerPositionX, playerPositionY);
                }
            }
        }

        //Initializing the plane figure
        private static void InitializePlane(int playerPositionX, int playerPositionY)
        {
            for (int i = 0; i < PlaneHeigth; i++)
            {
                Console.SetCursorPosition(playerPositionY, playerPositionX);
                for (int j = 0; j < PlaneWidth; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}
