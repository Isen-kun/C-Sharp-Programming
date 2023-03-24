using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualOverrideDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Tom", 10);
            Console.WriteLine($"{dog.Name} Is {dog.Age} years old");
            dog.MakeSound();
            dog.Play();
            dog.Eat();

            Console.ReadKey();
        }
    }
}
