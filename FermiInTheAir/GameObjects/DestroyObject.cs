using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FermiInTheAir.GameObjects
{
    public class DestroyObject : GameObject
    {
        const int DestroyObjectHeight = 2;
        const int DestroyObjectWidth = 2;
        const char DestroyObjectSymbol = '#';
        private Random rnd = new Random();

        public DestroyObject(Point pos)
            : base(DestroyObjectHeight, DestroyObjectWidth, pos, DestroyObjectSymbol)
        {

        }

        public override GameObject GenerateObject()
        {
            int objXPosition = 0;
            int objYPosition = rnd.Next(0, Settings.Width - this.Width);
            GameObject current = new DestroyObject(new Point(objXPosition, objYPosition));

            return current;
        }
    }

}

