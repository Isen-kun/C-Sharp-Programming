using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Basics
{
    internal class Human
    {
        private string firstName;
        private string lastName;
        private string eyeColor;

        public Human() {
            firstName = "Generic first name";
            lastName = "Generic last name";
            eyeColor = "black";
        }

        public Human(string fname, string lname, string color) {
            firstName = fname;
            lastName = lname;
            eyeColor = color;
        }

        public Human(string fname, string lname)
        {
            firstName = fname;
            lastName = lname;
            eyeColor = "blue";
        }
        public void IntroduceMyself()
        {
            Console.WriteLine($"Hi my name is {firstName} {lastName}");
            Console.WriteLine($"I happen to have {eyeColor} eyes");
        }
    }
}
