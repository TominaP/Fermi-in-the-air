using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FermiInTheAir.GameObjects
{
    public class Player
    {
        private const int WindowHeigth = 40;

        private const int WindowWidth = 80;

        private const int planeWidth = 20;

        private const int planeHeigth = 5;

        private static int playerStartPositionX = WindowWidth / 2 - planeWidth / 2;

        private static int playerStartPositionY = WindowHeigth - planeHeigth;

        private static int StartLives = 3;

        private Point StartPosition = new Point(playerStartPositionX, playerStartPositionY);      

        public Player()
        {
            this.PlaneHeight = planeHeigth;
            this.PlaneWidth = planeWidth;
            this.Position = StartPosition;
            this.Lives = StartLives;
            this.isAlive = false;
            this.isHitted = false;
        }

        public int PlaneHeight { get; private set; }

        public int PlaneWidth { get; set; }

        public Point Position { get; set; }

        public int Lives { get; set; }

        public bool isAlive { get; set; }

        public bool isHitted { get; set; }


        public void Print()
        {
            int x = this.Position.X;
            int y = this.Position.Y;
            Console.SetCursorPosition(y+9, x);
            Console.ForegroundColor = FermiInTheAir.Utility.OpeningPage.planeColor;
            Console.WriteLine("[]");
            Console.SetCursorPosition(y+2, x+1);
            Console.WriteLine("______[  ]______");
            Console.SetCursorPosition(y+1, x+2);
            Console.WriteLine(@"/_____[FERMI]____\");
            Console.SetCursorPosition(y+8, x+3);
            Console.WriteLine("[  ]");
            Console.SetCursorPosition(y+7, x+4);
            Console.WriteLine("--[]--");
            Console.ResetColor();

           //
           // for (int i = x; i < x + planeHeigth; i++)
           // {
           //     for (int j = y; j < y + planeWidth; j++)
           //     {
           //         Console.SetCursorPosition(j, i);
           //         Console.ForegroundColor = ConsoleColor.Blue;
           //         Console.Write('x');
           //     }
           // }
        }

        public void Clear()
        {
            int x = this.Position.X;
            int y = this.Position.Y;

            for (int i = x; i < x + planeHeigth; i++)
            {
                for (int j = y; j < y + planeWidth; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(' ');
                }
            }
        }

    }
}
