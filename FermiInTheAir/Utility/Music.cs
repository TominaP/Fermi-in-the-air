using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace FermiInTheAir
{
    public class Music
    {
        private static string Source = @"../../imperial_march.wav";

        public Music()
        {
            this.Play();
        }

        public void Play()
        {
            SoundPlayer player = new SoundPlayer(Source);

            using (player)
            {
                player.PlayLooping();
            }
        }
    }
}