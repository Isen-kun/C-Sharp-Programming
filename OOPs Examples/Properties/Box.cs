using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    internal class Box
    {
        private int length;
        private int breadth;
        //private int height;
        private int volume;
        
        public Box(int br)
        {
            breadth = br;
        }
        public int Height { get; set; }

        //public void setLength(int l) {
        //    length = l;
        //}

        //public int getLength() {
        //    return length;
        //}

        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }

        public void displayVol() {
            volume = length * breadth * Height;
            Console.WriteLine($"The volume of the created box is: {volume}");
        }

        public int SurfaceArea 
        { 
            get
            {
                return length * breadth;
            }
        }
    }
}
