using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleOrganizer
{
    class WorkDB
    {
        private string server;
        private string db;
        private string user;
        private string pass;
        public string fd = "yyyy-MM-dd HH:mm:ss";   //Format date to MySQL server
        private MySqlConnection connection;

        public WorkDB(string server, string user, string db, string pass)
        {
            this.server = server;
            this.user = user;
            this.db = db;
            this.pass = pass;
            connection = new MySqlConnection($"server = {server}; user = {user}; database = {db}; password = {pass}");
        }

        public List<Item> GetItems(Group group)
        {
            List<Item> items = new List<Item>();
            string sql = $"SELECT {group.TableName}.id, {group.TableName}.name FROM {db}.{group.TableName}";
            connection.Open();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                items.Add(new Item((int)reader[0], reader[1].ToString()));
            reader.Close();
            connection.Close();

            return items;
        }

        public List<Field> GetFields()
        {
            string TableName = "orders";
            List<Field> resFields = new List<Field>();
            string sql = $"SELECT {TableName}.id, {TableName}.name, {TableName}.value FROM {db}.{TableName}";
            connection.Open();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                resFields.Add(new Field((int)reader[0], reader[1].ToString(), reader[2].ToString()));
            reader.Close();
            connection.Close();

            return resFields;
        }

        private List<STask> GetSTasks(string sql)
        {
            List<STask> tasks = new List<STask>();
            connection.Open();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader r = command.ExecuteReader();
            while (r.Read())
            {
                tasks.Add(new STask((int)r[0], r[1].ToString(), DateTime.Parse(r[2].ToString()), DateTime.Parse(r[3].ToString()), (int)r[4], (int)r[5], (int)r[6], r[7].ToString()));
            }
            r.Close();
            connection.Close();
            return tasks;
        }
        public List<STask> GetSTasks()
        {
            return GetSTasks($"SELECT id, name, start, stop, status_id, criticality_id, category_id, description FROM {db}.tasks;");
        }//Return all tasks        
        public List<STask> GetSTasks(Field field, bool isAsc)
        {
            return GetSTasks($"SELECT id, name, start, stop, status_id, criticality_id, category_id, description FROM {db}.tasks ORDER BY {field.Name} {(isAsc ? "ASC" : "DESC")};");
        }//Return all tasks in ordered by field        
        public List<STask> GetSTasks(Group group, Item item, Field field, bool isAsc)
        {
            return GetSTasks($"SELECT id, name, start, stop, status_id, criticality_id, category_id, description FROM {db}.tasks WHERE tasks.{group.ColumnName} = {item.Id} ORDER BY {field.Name} {(isAsc ? "ASC" : "DESC")};");
        }//Return tasks groupped by group and ordered by field

        private string SendQuery(string sql)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
            return "send succesful or failed, i don't know";
        }

        public string Add(Group group, string newName)
        {
            return SendQuery($"INSERT INTO {db}.{group.TableName} (`name`) VALUES ('{newName}')"); ;
        }
        public string Add(STask task)
        {            
            return SendQuery($"INSERT INTO `{db}`.`tasks` (`name`, `start`, `stop`, `status_id`, `criticality_id`, `category_id`, `description`) " +
                $"VALUES ('{task.Name}', '{task.Start.ToString(fd)}', '{task.Stop.ToString(fd)}', '{task.StatusId}', '{task.CriticalityId}', '{task.CategoryId}', '{task.Desc}')");
        }

        public string Remove(Group group, Item item)
        {
            return SendQuery($"DELETE FROM `{db}`.`{group.TableName}` WHERE id = {item.Id};");
        }
        public string Remove(STask task)
        {
            return SendQuery($"DELETE FROM `{db}`.`tasks` WHERE id = {task.Id};");
        }

        public string Edit(Group group, Item item, Item newItem)
        {
            return SendQuery($"UPDATE `{db}`.`{group.TableName}` SET name = '{newItem.Name}' WHERE id = '{item.Id}'");
        }   //Edit group's item by ID
        public string Edit(STask task, Field field, string newData)
        {
            return SendQuery($"UPDATE `{db}`.tasks SET {field.Name} = '{newData}' WHERE id = '{task.Id}'");
        }//Edit task by ID
    }
}
