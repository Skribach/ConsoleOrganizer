using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleOrganizer
{
    class Group
    {
        public string Name { get; private set; }
        public string TableName { get; private set; }

        public Group(string name, string tableName)
        {
            Name = name;
            TableName = tableName;
        }

        public List<Item> GetItems()
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
        }

        public List<Order> GetOrders()
        {
            string sql = $"SELECT id, value, name FROM organizerdata.orders";
            List<Order> orders = new List<Order>();
            MySqlConnection connection = new MySqlConnection("server = localhost; user = root; database = organizerdata; password = 1234");
            connection.Open();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader r = command.ExecuteReader();
            while (r.Read())
                orders.Add(new Order((int)r[0], r[1].ToString(), r[2].ToString()));
            r.Close();
            connection.Close();

            return orders;
        }
    }

}
