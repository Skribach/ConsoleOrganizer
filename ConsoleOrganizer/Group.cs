using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleOrganizer
{
    class Group : Table
    {
        public string ColumnName { get; private set; }

        public Group(string name, string tableName, string columnName) : base(name, tableName)
        {
            ColumnName = columnName;
        }
        public List<Item> items = new List<Item>();
        

        /*public List<Item> GetItems()
        {
            string sql = $"SELECT id, name FROM organizerdata.{TableName};";
            List<Item> items = new List<Item>();

            MySqlConnection connection = new MySqlConnection("server = localhost; user = root; database = organizerdata; password = 1234");            
            connection.Open();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader r = command.ExecuteReader();
            while (r.Read())
                items.Add(new Item((int)r[0], r[1].ToString()));
            r.Close();
            connection.Close();

            return items;
        }*/
    }

}
