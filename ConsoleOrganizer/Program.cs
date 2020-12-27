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
        delegate string Check(string s);

        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 40);

            WorkDB db = new WorkDB("localhost", "root", "organizerdata", "1234");

            List<Group> groups = new List<Group>()
            {
                new Group ("Category", "categories", "category_id", db),
                new Group ("Status", "statuses", "status_id", db),
                new Group ("Criticality", "criticalities", "criticality_id", db)
            };
            List<Field> fields = db.GetFields();

            Display di = new Display(groups);
            Menus me = new Menu(db, d);

            while(true)
            {
                switch()
            }
            

            

            Console.ReadKey();

        }
    }


}
