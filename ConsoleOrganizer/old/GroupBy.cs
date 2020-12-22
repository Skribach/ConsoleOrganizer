using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer2
{
    
    class GroupBy
    {
        public string Name { get; private set; }
        public char Key { get; private set; }
        public string Where { get; private set; }

        private static string database = "organizerdata";

        public GroupBy(string name, char groupKey)
        {
            Name = name;
            Key = groupKey;
            Where = $"WHERE {database}.{Name} = ";
        }        

        public List<GroupByValues> GetValues()
        {
            List<GroupByValues> res = new List<GroupByValues>();
            res.Add(new GroupByValues("firstValue", '1'));
            res.Add(new GroupByValues("secondValue", '2'));
            res.Add(new GroupByValues("thirdValue", '3'));
            return res;
        }

        public void AddValue(string add)
        {

        }

        public void RemoveValue(string del)
        {

        }

        public void EditValue(string currVal, string newVal)
            {

            }
    }
}
