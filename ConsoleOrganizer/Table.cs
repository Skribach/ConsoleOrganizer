using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    abstract class Table
    {
        public string Name { get; private set; }
        public string TableName { get; private set; }
        public Table(string name, string tableName)
        {
            Name = name;
            TableName = tableName;
        }
    }
}
