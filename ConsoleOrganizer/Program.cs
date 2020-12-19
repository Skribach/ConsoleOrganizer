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

            SingleTask st = new SingleTask("nameTask", DateTime.Now, DateTime.Now.AddDays(3), "In Progress", "low", "gnome", "sdesc14", "null");

            MultiTask my = new MultiTask();
            my.Remove(9);
            my.Create(st);

            my.Get();
            my.ShowMultiTask();

            Console.ReadKey();
        }
    }
}
