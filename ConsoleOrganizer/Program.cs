using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 40);
            List<Group> groups = new List<Group>()
            {
                new Group("Status", "statuses"),
                new Group("Category", "categories"),
                new Group("Criticality", "criticalities")
            };
            Group sort = new Group("Sort", "sort");

            View v = new View();

            v.GroupBy(groups);
            v.SortBy(sort);
            Console.WriteLine(v.sql);


            Console.ReadKey();
        }
    }
}
