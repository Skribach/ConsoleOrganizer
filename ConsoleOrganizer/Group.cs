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
        public char Key { get; private set; }

        public Group(string name, string tableName, char key)
        {
            Name = name;
            TableName = tableName;
            Key = key;
        }

        public List<Item> GetItems()        //TODO -> MySQL query
        {
            return new List<Item>()
            {
                new Item(1, "In progress", '1'),
                new Item(2, "Complited", '2'),
                new Item(3, "Failed", '3')
            };
        }
    }
}
