using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    class Sort
    {
        public string Name {get; private set; }
        public char Key { get; private set; }
        public string ColumnName { get; private set; }

        public Sort (string name, char key, string columnName)
        {
            Name = name;
            Key = key;
            ColumnName = columnName;
        }

        public static List<Sort> GetSorts()  //TODO -> Create table in BD with parameters of Sort
        {
            return new List<Sort>()
            {
                new Sort("none", '1', ""),
                new Sort("Name", '2', "name"),
                new Sort("Start Date", '3', "start"),
                new Sort("Finish Date", '4', "stop"),
                new Sort("Status", '5', "statuses.name"),
                new Sort("Criticality", '6', "criticalities.name"),
                new Sort("Category", '7', "categories.name")
            };
        }
    }
}
