using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    internal class TV : ElectricalDevice
    {
        public TV(bool isOn, string brand) : base(isOn, brand)
        {

        }

        public void WatchTV()
        {
            if (IsOn)
            {
                Console.WriteLine("Watching TV");
            }
            else
            {
                Console.WriteLine("TV is Switched off, switch it on first");
            }
        }
    }
}
