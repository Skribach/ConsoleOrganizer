using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ConsoleOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 40);

            List<GroupBy> groups = new List<GroupBy>();
            groups.Add(new GroupBy("None", '1'));
            groups.Add(new GroupBy("Statuses", '2'));
            groups.Add(new GroupBy("Criticalities", '3'));
            groups.Add(new GroupBy("Categories", '4'));
            
            View v = new View();

            v.SelectGroup(groups);

            Console.ReadKey();
        }
    }
}
