namespace FermiInTheAir.GameObjects
{
    public abstract class GameObject
    {
        public GameObject(int height, int width, Point pos, char symbol)
        {
            this.Height = height;
            this.Width = width;
            this.UpLeftCorner = pos;
            this.HaveCollision = false;
            this.Symbol = symbol;
            SetPositionsCoordinates();
        }

        public int Height { get; set; }

        public int Width { get; set; }

        public Point UpLeftCorner { get; set; }

        public bool HaveCollision { get; set; }

        public char Symbol { get; set; }

        public Point[] PositionsCoordinates { get; set; }

        public void SetPositionsCoordinates()
        {
            Point[] positions = new Point[Height*Width];
            int index = 0;

            for (int i = this.UpLeftCorner.X; i < this.UpLeftCorner.X + Height; i++)
            {
                for (int j = this.UpLeftCorner.Y; j < this.UpLeftCorner.Y + Width; j++)
                {
                    positions[index] = new Point(i, j);
                    index++;
                }
            }

            this.PositionsCoordinates = positions;
        }

        public virtual void Move()
        {
            this.UpLeftCorner.X++;

            //this may be must check in collision metod
            if (UpLeftCorner.X >= 40 - Height)
            {
                this.HaveCollision = true;
                this.UpLeftCorner.X--;
            }
        }

        public override int GetHashCode()
        {
            int hashCode = 80* this.UpLeftCorner.X + this.UpLeftCorner.Y;
            return hashCode; //x y coordinates concatenated
        }
    }
}
