using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    class SortValues
    {
        public string Name { get; private set; }
        public char Key { get; private set; }

        public SortValues(string name, char key)
        {
            Name = name;
            Key = key;
        }

        public static List<SortValues> GetSortVal()
        {
            List<SortValues> res = new List<SortValues>();
            res.Add(new SortValues("firstSort", '1'));
            res.Add(new SortValues("secondSort", '2'));
            res.Add(new SortValues("thirdSort", '3'));
            return res;
        }
    }
}
