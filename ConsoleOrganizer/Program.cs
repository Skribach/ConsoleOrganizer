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

            View v = new View();    

            if (v.IsNeedGroup())
                v.SelectGroup(new List<Group>() { new Group("Status", "statuses", '1'), new Group("Category", "categories", '2'), new Group("Criticality", "criticalities", '3') });
            v.SelectSort(Sort.GetSorts());


            Console.WriteLine();
            Console.WriteLine(v.sql);
            Console.ReadKey();
        }
    }
}
