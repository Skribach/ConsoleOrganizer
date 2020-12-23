using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    class Order : Item
    {
        public string Name { get; private set; }

        public Order(int id, string value, string name) : base (id, value)
        {
            Name = name;
        }
    }
}
