using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer2
{
    class GroupByValues
    {
        public string Name { get; private set; }
        public char Key { get; private set; }

        public GroupByValues(string name, char key)
        {
            Name = name;
            Key = key;
        }
    }
}
