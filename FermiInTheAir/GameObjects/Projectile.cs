using System;

namespace FermiInTheAir.GameObjects
{
    public class Projectile : GameObject
    {
        const int ProjectileHeight = 1;
        const int ProjectileWidth = 1;
        const char ProjectileChar = '^';

        public Projectile(Point pos)
            : base(ProjectileHeight, ProjectileWidth, pos, ProjectileChar)
        {

        }

        public void Move()
        {
            this.UpLeftCorner.X--;

            if (UpLeftCorner.X <= 0 - Height)
            {
                this.UpLeftCorner.X--;
            }
            else if (HaveCollision)
            {
                // play sound + add score + destroy both object and projectile
            }
        }
    }
}

