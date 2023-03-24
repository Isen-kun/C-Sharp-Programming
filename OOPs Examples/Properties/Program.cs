using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box a = new Box(8);
            //a.setLength(5);
            //a.breadth = 5;
            //a.height = 5;
            //Console.WriteLine($"The set height is {a.getLength()}");
            a.Length = 4;
            a.Height = 6;

            Console.WriteLine(a.Height);
            Console.WriteLine(a.Length);

            a.displayVol();

            Console.WriteLine($"The surface area of the box is: {a.SurfaceArea}");

            Console.ReadKey();
        }
    }
}
