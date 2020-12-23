using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    class Item
    {
        public int Id { get; private set; }
        public string Value { get; private set; }

        public Item(int id, string value)
        {
            Id = id;
            Value = value;
        }

    }
}
