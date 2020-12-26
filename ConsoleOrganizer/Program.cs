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

            List<Group> groups = new List<Group>()
            {
                new Group ("Category", "categories", "category_id"),
                new Group ("Status", "statuses", "status_id"),
                new Group ("Criticality", "criticalities", "criticality_id")
            };

            WorkDB db = new WorkDB("localhost", "root", "organizerdata", "1234");
            Display d = new Display();

            /*db.Remove(new STask(10, "sdf", DateTime.Now, DateTime.Now.AddMinutes(10), 1, 3, 2, "smaaaaldesc"));*/
            /*STask st = new STask("someTask", DateTime.Now, DateTime.Now.AddMinutes(10), 1, 3, 2, "smaaaaldesc");
            db.Add(st);*/

            /*db.Add(groups[0], "noncategory");*/

            /* db.Edit(new STask(7, "123", DateTime.Now, DateTime.Now.AddMinutes(10), 1, 3, 2, "smaaaaldesc"), new Field(1, "name", ""), "newName);*/




            Console.ReadKey();

        }
    }


}
