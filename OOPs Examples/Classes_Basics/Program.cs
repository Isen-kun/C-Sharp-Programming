using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Human Denis = new Human();
            Denis.IntroduceMyself();

            Human Micheal = new Human("Michael", "Shumacher");
            Micheal.IntroduceMyself();

            Human Raj = new Human("Rajorshi", "Ghosh", "Brown");
            Raj.IntroduceMyself();

            Console.ReadKey();
        }
    }
}
