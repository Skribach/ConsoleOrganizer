using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    class SubGroup
    {
        public string Name { get; private set; }
        public string TableName { get; private set; }
        public List<Item> Items { get; private set; }

        public SubGroup(string name, string tablename)
        {
            Name = name;
            TableName = TableName;
            Items = GetItems();
        }

        public List<Item> GetItems()
        {
            return new List<Item>() { new Item(1, "Complited"), new Item(2, "Failed"), new Item(3, "In progress") };
        }
    }

}
