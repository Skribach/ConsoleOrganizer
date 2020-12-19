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

            MultiTask my = new MultiTask();
            my.GetTasks(MultiTask.FormMySqlQuery(SortFields.stop, true));
            my.ShowMultiTask();

            Console.ReadKey();
        }
    }
}
