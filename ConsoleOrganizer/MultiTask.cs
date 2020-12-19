using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;



namespace ConsoleOrganizer
{    
    public enum SearchFields
    {
        id, name, start, stop, status, criticality, category
    }
    public enum SortFields
    {
        id, name, start, stop, status, criticality, category
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

        public static string FormMySqlQuery()
        {
            return "SELECT tasks.id, tasks.name, start, stop, statuses.name, criticality.name, categories.name, smallDescription, largeDescription " +
                $"FROM {database}.tasks " +
                "INNER JOIN criticality ON tasks.criticality_id = criticality.id " +
                "INNER JOIN categories ON tasks.category_id = categories.id " +
                "INNER JOIN statuses ON tasks.status_id = statuses.id ";
        }

        public static string FormMySqlQuery(SearchFields searchBy, string searchVal)
        {
            string res = FormMySqlQuery() + "WHERE ";
            switch (searchBy)
            {               
                case SearchFields.id:
                    res += $"tasks.id = {searchVal} ";
                    break;
                case SearchFields.name:
                    res += $"tasks.name = '{searchVal}' ";
                    break;
                case SearchFields.start:
                    res += $"tasks.start = '{searchVal}' ";
                    break;
                case SearchFields.stop:
                    res += $"tasks.stop = '{searchVal}' ";
                    break;
                case SearchFields.status:
                    res += $"statuses.name = '{searchVal}' ";
                    break;
                case SearchFields.criticality:
                    res += $"criticality.name = '{searchVal}' ";
                    break;
                case SearchFields.category:
                    res += $"categories.name = '{searchVal}' ";
                    break;
            }
            return res;
        }

        public static string FormMySqlQuery(SortFields sortBy, bool isAscOrder)
        {
            string res = FormMySqlQuery() + "ORDER BY ";
            switch (sortBy)
            {   
                case SortFields.id:
                    res += $"tasks.id ";
                    break;
                case SortFields.name:
                    res += $"tasks.name ";
                    break;
                case SortFields.start:
                    res += $"tasks.start ";
                    break;
                case SortFields.stop:
                    res += $"tasks.stop ";
                    break;
                case SortFields.status:
                    res += $"statuses.name ";
                    break;
                case SortFields.criticality:
                    res += $"criticality.name ";
                    break;
                case SortFields.category:
                    res += $"categories.name ";
                    break;
            }
            if (!isAscOrder)
                res += "DESC ";
            return res;
        }

        public static string FormMySqlQuery(SearchFields searchBy, string searchVal, SortFields sortBy, bool isDecsOrder)
        {
            string res = FormMySqlQuery(searchBy, searchVal) + "ORDER BY ";
            switch (sortBy)
            {
                case SortFields.id:
                    res += $"tasks.id ";
                    break;
                case SortFields.name:
                    res += $"tasks.name ";
                    break;
                case SortFields.start:
                    res += $"tasks.startDateTime ";
                    break;
                case SortFields.stop:
                    res += $"tasks.stopDateTime ";
                    break;
                case SortFields.status:
                    res += $"statuses.name ";
                    break;
                case SortFields.criticality:
                    res += $"criticality.name ";
                    break;
                case SortFields.category:
                    res += $"categories.name ";
                    break;
            }
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
