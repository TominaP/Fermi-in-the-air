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

            if (UpLeftCorner.X <= 1 - Height)
            {
                this.HaveCollision = true;
            }
        }
    }
}

