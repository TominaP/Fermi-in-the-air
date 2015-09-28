using FermiInTheAir.GameObjects;
using FermiInTheAir.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FermiInTheAir
{
    public class Engine
    {
        private Queue<GameObject> gameObjectLsit = new Queue<GameObject>();
        private Random rnd = new Random();
        Settings settings = new Settings();
        private DestroyObject destoyObject;
        private CollectedObject collectObject;

        public void Run()
        {
            while (!settings.GameOver)
            {
                // adding chance to spawn @ 25%               
                int chanceToSpawn = rnd.Next(0, 100);


                if (chanceToSpawn <= 80)
                {
                    int objXPosition = 0;
                    int objYPosition = rnd.Next(0, settings.Width - 2);
                    destoyObject = new DestroyObject(new Point(objXPosition, objYPosition));
                    gameObjectLsit.Enqueue(destoyObject);                   
                }
                else if (chanceToSpawn <= 40)
                {
                    int objXPosition = 0;
                    int objYPosition = rnd.Next(0, settings.Width);
                    collectObject = new CollectedObject(new Point(objXPosition, objYPosition));
                    gameObjectLsit.Enqueue(collectObject);
                }
                

                foreach (var obj in gameObjectLsit)
                {
                    PrintGameObject.PrintObject(obj);
                }



                foreach (var obj in gameObjectLsit)
                {
                    PrintGameObject.ClearObject(obj);
                    obj.Move();
                    PrintGameObject.PrintObject(obj);
                }

                Thread.Sleep(200);
            }
        }
    }
}
