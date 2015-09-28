﻿namespace FermiInTheAir.GameObjects
{
    public abstract class GameObject
    {
        public GameObject(int height, int width, Point pos, char symbol)
        {
            this.Height = height;
            this.Width = width;
            this.UpLeftCorner = pos;
            HaveCollision = false;
            this.Symbol = symbol;
        }

        public int Height { get; set; }

        public int Width { get; set; }

        public Point UpLeftCorner { get; set; }

        public bool HaveCollision { get; set; }

        public char Symbol { get; set; }

        public void Move()
        {
            this.UpLeftCorner.X++;
        }  
    }
}
