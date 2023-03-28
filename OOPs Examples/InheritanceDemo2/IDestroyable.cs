using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo2
{
    internal interface IDestroyable
    {
        string DestructionSound { get; set; }

        void Destroy();
    }
}
