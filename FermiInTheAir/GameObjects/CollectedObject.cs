using System;

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

    }
}
