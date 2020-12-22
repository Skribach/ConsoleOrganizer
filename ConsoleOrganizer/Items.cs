using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    class Items
    {
        public string Name { get; private set; }
        public string TableName { get; private set; }
        public List<Cell> Cells { get; private set; }

        public Items(string name, string tableName)
        {
            Name = name;
            TableName = tableName;
            Cells = GetItems();
        }

        public List<Cell> GetItems()                      //TODO -> get items from database
        {
            List<Cell> a = new List<Cell>();
            a.Add(new Cell(1, "firstName"));
            a.Add(new Cell(2, "secondName"));
            a.Add(new Cell(3, "thirdName"));
            return a;
        }
    }
}
