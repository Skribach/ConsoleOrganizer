using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    class Group
    {
        public string Name { get; private set; }
        public string TableName { get; private set; }

        public Group(string name, string tableName)
        {
            Name = name;
            TableName = tableName;
        }
        
        public List<Item> GetItems()   //TODO -> MySQL request to return all items from group
        {
            return new List<Item>() { new Item(1, "Complited"), new Item(2, "Failed"), new Item(3, "In progress") };
        }
    }

}
