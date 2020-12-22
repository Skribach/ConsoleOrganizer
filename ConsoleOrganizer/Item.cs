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
        public string Name { get; private set; }
        public char Key { get; private set; }

        public Item(int id, string name, char key)
        {
            Id = id;
            Name = name;
            Key = key;
        }
    }
}
