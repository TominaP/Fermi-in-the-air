using System;
using FermiInTheAir.Utility;

namespace FermiInTheAir.GameObjects
{
    public class Player
    {
        private const int WindowHeigth = 40;

        private const int WindowWidth = 80;

        private static int planeWidth = GetPlaneWidth();

        private static int planeHeigth = GetPlaneHeight();

        private static int playerStartPositionY = WindowWidth / 2 - planeWidth / 2;

        private static int playerStartPositionX = WindowHeigth - planeHeigth -1;

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


        private static int GetPlaneWidth()
        {
            if (PlaneSettings.planeOneIsSelected)
            {
                return 18;
            }
            else if (PlaneSettings.planeTwoIsSelected)
            {
                return 17;
            }
            else if (PlaneSettings.planeThreeIsSelected)
            {
                return 9;
            }
            return 0;
        }


        private static int GetPlaneHeight()
        {
            if (PlaneSettings.planeOneIsSelected)
            {
                return 5;
            }
            else if (PlaneSettings.planeTwoIsSelected)
            {
                return 7;
            }
            else if (PlaneSettings.planeThreeIsSelected)
            {
                return 7;
            }
            return 0;
        }


        public void Print()
        {
            int x = this.Position.X;
            int y = this.Position.Y;
            Console.ForegroundColor = PlaneSettings.planeColor;
            PrintSelectedPlane(x, y);
        }

        private void PrintSelectedPlane(int x, int y)
        {
            if (PlaneSettings.planeOneIsSelected)
            {
                Console.SetCursorPosition(y + 8, x);
                Console.WriteLine("[]");
                Console.SetCursorPosition(y + 1, x + 1);
                Console.WriteLine("______[  ]______");
                Console.SetCursorPosition(y, x + 2);
                Console.WriteLine(@"/_____[FERMI]____\");
                Console.SetCursorPosition(y + 7, x + 3);
                Console.WriteLine("[  ]");
                Console.SetCursorPosition(y + 6, x + 4);
                Console.WriteLine("--[]--");
                Console.ResetColor();
            }
            else if (PlaneSettings.planeTwoIsSelected)
            {
                //planeHeigth = 7;
                //planeWidth = 15;
                Console.SetCursorPosition(y + 8, x);
                Console.WriteLine("|");
                Console.SetCursorPosition(y + 7, x + 1);
                Console.WriteLine("+++");
                Console.SetCursorPosition(y + 5, x + 2);
                Console.WriteLine("#=====#");
                Console.SetCursorPosition(y, x + 3);
                Console.WriteLine("*****************");
                Console.SetCursorPosition(y, x + 4);
                Console.WriteLine("*****************");
                Console.SetCursorPosition(y + 5, x + 5);
                Console.WriteLine("#######");
                Console.SetCursorPosition(y + 1, x + 6);
                Console.WriteLine(@"//    ||    \\");
                Console.ResetColor();
            }
            else if (PlaneSettings.planeThreeIsSelected)
            {
                Console.SetCursorPosition(y + 4, x);
                Console.WriteLine(@"^");
                Console.SetCursorPosition(y + 3, x + 1);
                Console.WriteLine(@"(*)");
                Console.SetCursorPosition(y + 3, x + 2);
                Console.WriteLine(@"(*)");
                Console.SetCursorPosition(y + 2, x + 3);
                Console.WriteLine(@"// \\");
                Console.SetCursorPosition(y + 1, x + 4);
                Console.WriteLine(@"/|/*\|\");
                Console.SetCursorPosition(y, x + 5);
                Console.WriteLine(@"/_FERMI_\");
                Console.SetCursorPosition(y, x + 6);
                Console.WriteLine(@"\/     \/");

            }
        }

        public void Clear()
        {
            int x = this.Position.X;
            int y = this.Position.Y;

            if (PlaneSettings.planeOneIsSelected)
            {
                Console.SetCursorPosition(y + 8, x);
                Console.WriteLine("{0}", new string(' ', 2));
                Console.SetCursorPosition(y + 1, x + 1);
                Console.WriteLine("{0}", new string(' ', 18));
                Console.SetCursorPosition(y, x + 2);
                Console.WriteLine("{0}", new string(' ', 18));
                Console.SetCursorPosition(y + 7, x + 3);
                Console.WriteLine("{0}", new string(' ', 4));
                Console.SetCursorPosition(y + 6, x + 4);
                Console.WriteLine("{0}", new string(' ', 6));
                Console.ResetColor();
            }
            else if (PlaneSettings.planeTwoIsSelected)
            {
                //planeHeigth = 7;
                //planeWidth = 15;
                Console.SetCursorPosition(y + 8, x);
                Console.WriteLine("{0}", new string(' ', 1));
                Console.SetCursorPosition(y + 7, x + 1);
                Console.WriteLine("{0}", new string(' ', 3));
                Console.SetCursorPosition(y + 5, x + 2);
                Console.WriteLine("{0}", new string(' ', 7));
                Console.SetCursorPosition(y, x + 3);
                Console.WriteLine("{0}", new string(' ', 17));
                Console.SetCursorPosition(y, x + 4);
                Console.WriteLine("{0}", new string(' ', 17));
                Console.SetCursorPosition(y + 5, x + 5);
                Console.WriteLine("{0}", new string(' ', 7));
                Console.SetCursorPosition(y + 1, x + 6);
                Console.WriteLine("{0}", new string(' ', 14));
                Console.ResetColor();
            }
            else if (PlaneSettings.planeThreeIsSelected)
            {
                Console.SetCursorPosition(y + 4, x);
                Console.WriteLine("{0}", new string(' ', 1));
                Console.SetCursorPosition(y + 3, x + 1);
                Console.WriteLine("{0}", new string(' ', 3));
                Console.SetCursorPosition(y + 3, x + 2);
                Console.WriteLine("{0}", new string(' ', 3));
                Console.SetCursorPosition(y + 2, x + 3);
                Console.WriteLine("{0}", new string(' ', 5));
                Console.SetCursorPosition(y + 1, x + 4);
                Console.WriteLine("{0}", new string(' ', 7));
                Console.SetCursorPosition(y, x + 5);
                Console.WriteLine("{0}", new string(' ', 9));
                Console.SetCursorPosition(y, x + 6);
                Console.WriteLine("{0}", new string(' ', 9));

            }

        }
    }
}