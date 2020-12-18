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

            /*SingleTask a = new SingleTask(1, "solarTask", DateTime.Now, DateTime.Now.AddMinutes(5), "in progress", "criticaly", "home", "sdesc", "ldesc");
            SingleTask b = new SingleTask(1111, "myTasko", DateTime.Now, DateTime.Now.AddMinutes(15), "in progress", "criticaly", "work", "sdesc", "ldesc");

            SingleTask.ShowTitle("Task To Do");
            a.ShowRow();
            b.ShowRow();*/

            MultiTask my = new MultiTask();
            my.GetTasks(MultiTask.FormMySqlQuery(Fields.none, Fields.start, "", true));
            //my.GetTaskByID(2);
            my.ShowMultiTask();

            Console.ReadKey();
        }
    }
}
