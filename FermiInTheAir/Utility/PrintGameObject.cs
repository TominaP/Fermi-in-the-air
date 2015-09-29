using FermiInTheAir.GameObjects;
using System;

namespace FermiInTheAir.Utility
{
    public static class PrintGameObject
    {
        public static void PrintObject(GameObject obj)
        {
            int x = obj.UpLeftCorner.X;
            int y = obj.UpLeftCorner.Y;

            if (obj.HaveCollision)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("<x>");
            }
            else
            {
                for (int i = x; i < x + obj.Height; i++)
                {
                    for (int j = y; j < y + obj.Width; j++)
                    {
                        Console.SetCursorPosition(j, i);
                        if (obj.Symbol == '$')
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(obj.Symbol);
                    }
                }
            }

        }

        public static void ClearObject(GameObject obj)
        {
            int x = obj.UpLeftCorner.X;
            int y = obj.UpLeftCorner.Y;

            for (int i = x; i < x + obj.Height; i++)
            {
                for (int j = y; j < y + obj.Width; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(' ');
                }
            }
        }
    }
}