using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FermiInTheAir.GameObjects
{
    public abstract class GameObject
    {
        public GameObject(int height, int width, Point pos, char symbol)
        {
            this.Height = height;
            this.Width = width;
            this.UpLeftCorner = pos;
            HaveCollision = false;
        }

        public int Height { get; set; }

        public int Width { get; set; }

        public Point UpLeftCorner { get; set; }

        public bool HaveCollision { get; set; }

        public char Symbol { get; set; }


        public abstract GameObject GenerateObject();
      

        public void Move(GameObject obj)
        {
            obj.UpLeftCorner.X++;
        }

        public void Print(GameObject obj)
        {
            int x = obj.UpLeftCorner.X;
            int y = obj.UpLeftCorner.Y;

            for (int i = x; i < x + this.Height; i++)
            {
                for (int j = y; j < y + this.Width; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(this.Symbol);
                }
            }
        }

        public void Clear(GameObject obj)
        {
            int x = obj.UpLeftCorner.X;
            int y = obj.UpLeftCorner.Y;

            for (int i = x; i < x + this.Height; i++)
            {
                for (int j = y; j < y + this.Width; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(' ');
                }
            }
        }



    }
}
