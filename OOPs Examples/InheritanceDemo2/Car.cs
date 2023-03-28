using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo2
{
    internal class Car: Vehicle, IDestroyable
    {
        public string DestructionSound { get; set; }

        public List<IDestroyable> DestroyablesNearby;

        public Car(float speed, string color)
        {
            this.Speed = speed;
            this.Color = color;
            DestructionSound = "CarExplosionSound.mp3";
            DestroyablesNearby = new List<IDestroyable>();
        }

        public void Destroy()
        {
            Console.WriteLine($"Playing destruction sound {DestructionSound}");
            Console.WriteLine("Create Fire");

            foreach (IDestroyable destroyable in DestroyablesNearby)
            {
                destroyable.Destroy();
            }
        }
    }
}
