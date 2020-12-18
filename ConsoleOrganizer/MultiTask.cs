using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;



namespace ConsoleOrganizer
{    
    public enum Fields
    {
        none, id, name, start, stop, status, criticality, category
    }

    public class MultiTask
    {
        private static string server = "localhost";
        private static string user = "root";
        private static string database = "organizerdata";
        private static string pass = "1234";

        public List<SingleTask> tasks;  
        public int Count { get; set; }        

        public void GetTasks(string sql)
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

        public static string FormMySqlQuery(Fields searchBy, Fields sortBy, string searchVal, bool isDecsOrder)
        {
            string res = $"SELECT tasks.id, tasks.name, startDateTime, stopDateTime, statuses.name, criticality.name, categories.name, smallDescription, largeDescription " +
                $"FROM {database}.tasks " +
                "INNER JOIN criticality ON tasks.criticality_id = criticality.id " +
                "INNER JOIN categories ON tasks.category_id = categories.id " +
                "INNER JOIN statuses ON tasks.status_id = statuses.id ";
            switch (searchBy)
            {
                case Fields.none:
                    break;
                case Fields.id:
                    res += $"WHERE tasks.id = {searchVal} ";
                    break;
                case Fields.name:
                    res += $"WHERE tasks.name = '{searchVal}' ";
                    break;
                case Fields.start:
                    res += $"WHERE tasks.start = '{searchVal}' ";
                    break;
                case Fields.stop:
                    res += $"WHERE tasks.stop = '{searchVal}' ";
                    break;
                case Fields.status:
                    res += $"WHERE statuses.name = '{searchVal}' ";
                    break;
                case Fields.criticality:
                    res += $"WHERE criticality.name = '{searchVal}' ";
                    break;
                case Fields.category:
                    res += $"WHERE categories.name = '{searchVal}' ";
                    break;
            }
            switch (sortBy)
            {
                case Fields.none:
                    break;
                case Fields.id:
                    res += $"ORDER BY tasks.id ";
                    break;
                case Fields.name:
                    res += $"ORDER BY tasks.name ";
                    break;
                case Fields.start:
                    res += $"ORDER BY tasks.startDateTime ";
                    break;
                case Fields.stop:
                    res += $"ORDER BY tasks.stopDateTime ";
                    break;
                case Fields.status:
                    res += $"ORDER BY statuses.name ";
                    break;
                case Fields.criticality:
                    res += $"ORDER BY criticality.name ";
                    break;
                case Fields.category:
                    res += $"ORDER BY categories.name ";
                    break;
            }
            if (sortBy != Fields.none)
                if (isDecsOrder)
                    res += "DESC ";
            return res;
        }    

        public void ShowMultiTask()
        {
            SingleTask.ShowTitle("To Do");
            foreach (SingleTask t in tasks)
                t.ShowRow();
        }
    }




    

}
