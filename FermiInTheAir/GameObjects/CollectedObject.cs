using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FermiInTheAir.GameObjects
{
    public class CollectedObject : GameObject
    {
        const int CollectedObjectHeight = 1;
        const int CollectedObjectWidth = 1;
        const char CollectedObjectChar = '$';
        private Random rnd = new Random();

        public CollectedObject(Point pos)
            : base(CollectedObjectHeight, CollectedObjectWidth, pos, CollectedObjectChar)
        {

        }

        public override GameObject GenerateObject()
        {
            int objXPosition = 0;
            int objYPosition = rnd.Next(0, Settings.Width - this.Width);
            GameObject current = new CollectedObject(new Point(objXPosition, objYPosition));

            return current;
        }
    }
}
