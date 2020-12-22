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

            Show sh = new Show();
            sh.MakeChoise("HELLO WORLD!", new Items("name", "tablename"));

            Console.ReadKey();
        }
    }
}
