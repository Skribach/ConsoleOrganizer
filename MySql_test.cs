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
            string connstr = "server = localhost; user = root; database = organizerdata; password = 1234";
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            string sql = "SELECT id, name FROM organizerdata.tasks";

            //Вывод единственного результата
            /* MySqlCommand command = new MySqlCommand(sql, conn);
             string ans = command.ExecuteScalar().ToString();
             Console.WriteLine(ans);*/

            //Вывод результата запроса 1-го столбца всех строк 
            /*MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine(reader[0]);
            }
            reader.Close();*/

            //Вывод результата запроса всех столбцов всех строк 
            /*MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());
            }
            reader.Close();*/

            conn.Close();
            Console.ReadKey();
        }
    }
}
