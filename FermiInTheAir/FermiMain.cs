using System.Threading;

namespace FermiInTheAir
{
   public class FermiMain
    {
        public static void Main()
        {
            //Music playMusic = new Music();
            //Thread music = new Thread(playMusic.Play);
            //music.Start();

            Engine eng = new Engine();
            eng.Run();
        }
    }
}
