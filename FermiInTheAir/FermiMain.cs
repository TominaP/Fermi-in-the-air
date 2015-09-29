using System.Threading;
using System;

namespace FermiInTheAir
{
   public class FermiMain
    {
        public static void Main()
        {
            Console.WindowHeight = 40;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            Console.CursorVisible = false;
            Music playMusic = new Music();
            Thread music = new Thread(playMusic.Play);
            music.Start();

            FermiInTheAir.Utility.OpeningPage.OpenPage();

            Engine eng = new Engine();
            eng.Run();

        }
    }
}
