using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;



namespace ConsoleOrganizer
{
    public class MultiTask
    {
        private static string server = "localhost";
        private static string user = "root";
        private static string database = "organizerdata";
        private static string pass = "1234";

        public List<SingleTask> tasks;
        public int Count { get; set; }

        private void TasksFromDB(string sql)
        {
            tasks = new List<SingleTask>();
            Count = 0;
            MySqlConnection connection = new MySqlConnection($"server = {server}; user = {user}; database = {database}; password = {pass}");
            connection.Open();
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader r = command.ExecuteReader();
            while (r.Read())
            {
                tasks.Add(new SingleTask((int)r[0], r[1].ToString(), DateTime.Parse(r[2].ToString()), DateTime.Parse(r[3].ToString()), r[4].ToString(), r[5].ToString(), r[6].ToString(), r[7].ToString(), r[8].ToString()));
                Count++;
            }
            r.Close();
            connection.Close();
        }

        public void GetAllTasks()           //Получение всех заданий
        {
            TasksFromDB($"SELECT tasks.id, tasks.name, startDateTime, stopDateTime, statuses.name, criticality.value, categories.name, smallDescription, largeDescription FROM {database}.tasks " +
                "INNER JOIN criticality ON tasks.criticality_id = criticality.id " +
                "INNER JOIN categories ON tasks.category_id = categories.id " +
                "INNER JOIN statuses ON tasks.status_id = statuses.id");
        }

        public void GetTaskByID(int id)
        {
            TasksFromDB($"SELECT tasks.id, tasks.name, startDateTime, stopDateTime, statuses.name, criticality.value, categories.name, smallDescription, largeDescription FROM {database}.tasks " +
                "INNER JOIN criticality ON tasks.criticality_id = criticality.id " +
                "INNER JOIN categories ON tasks.category_id = categories.id " +
                "INNER JOIN statuses ON tasks.status_id = statuses.id " +
                $"WHERE tasks.id = {id}");
        }

        public void ShowMultiTask()
        {
            SingleTask.ShowTitle("To Do");
            foreach (SingleTask t in tasks)
                t.ShowRow();
        }
    }
}
