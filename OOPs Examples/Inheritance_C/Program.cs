using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Post post1 = new Post("Thanks for birthday wishes", true, "Rajorshi Ghosh");
            Console.WriteLine(post1.ToString());

            ImagePost imagePost1 = new ImagePost("Check out my new shoes", "Rajorshi Ghosh", "https://images.com/shoes", true);

            Console.WriteLine(imagePost1.ToString());

            Console.ReadKey();
        }
    }
}
