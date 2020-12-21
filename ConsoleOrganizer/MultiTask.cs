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

        private string server = "localhost";
        private string user = "root";
        private string database = "organizerdata";
        private string pass = "1234";


        public List<SingleTask> tasks;
        public int Count { get; set; }


        private string MySql_select = "SELECT tasks.id, tasks.name, start, stop, statuses.name, criticality.name, categories.name, smallDescription, largeDescription " +
         $"FROM {database}.tasks " +
         "INNER JOIN criticality ON tasks.criticality_id = criticality.id " +
         "INNER JOIN categories ON tasks.category_id = categories.id " +
         "INNER JOIN statuses ON tasks.status_id = statuses.id ";
        //Secondary methods to generate SQL query
        private string ToSearch(SearchFields searchBy, string searchVal)
        {
            string res = "WHERE ";
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
        private string ToSort(SortFields sortBy, bool isAscOrder)
        {
            string res = "ORDER BY ";
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

        //Method for copy Rows from database by sql query
        private void UpdateTasks(string sql)
        {
            MySqlConnection connection = new MySqlConnection($"server = {server}; user = {user}; database = {database}; password = {pass}");
            tasks = new List<SingleTask>();
            Count = 0;
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

        //Method for copy Rows from database to tasks with search, sort
        public void Get()
        {
            UpdateTasks(MySql_select);
        }
        public void Get(SearchFields searchBy, string searchVal)
        {
            UpdateTasks(MySql_select + ToSearch(searchBy, searchVal));
        }
        public void Get(SortFields sortBy, bool isAscOrder)
        {
            UpdateTasks(MySql_select + ToSort(sortBy, isAscOrder));
        }
        public void Get(SearchFields searchBy, string searchVal, SortFields sortBy, bool isAscOrder)
        {
            UpdateTasks(MySql_select + ToSearch(searchBy, searchVal) + ToSort(sortBy, isAscOrder));
        }

        //Method for operations like INSERT, DELETE, UPDATE
        private void MySqlQuery1(string sql)
        {
            MySqlConnection connection = new MySqlConnection($"server = {server}; user = {user}; database = {database}; password = {pass}");
            connection.Open();
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        //Method for operations like SELECT with 1 result
        private string MySqlQuery2(string sql)
        {
            MySqlConnection connection = new MySqlConnection($"server = {server}; user = {user}; database = {database}; password = {pass}");
            connection.Open();
            MySqlCommand command = new MySqlCommand(sql, connection);
            string ans = command.ExecuteScalar().ToString();
            connection.Close();
            return ans;
        }

        public void Remove(int id)
        {
            MySqlQuery1($"DELETE FROM tasks WHERE id = '{id}'");
        }
        public void Create(SingleTask st)
        {
            MySqlConnection connection = new MySqlConnection($"server = {server}; user = {user}; database = {database}; password = {pass}");
            connection.Open();


            string sql = "INSERT INTO `organizerdata`.`tasks` " +
                "(`name`, `start`, `stop`, `status_id`, `criticality_id`, `user_id`, `category_id`, `smallDescription`, `largeDescription`) " +
                $"VALUES ('{st.Name}', '{st.Start.ToString(fd)}', '{st.Stop.ToString(fd)}', '1', '1', '1', '1', '1', '1')");
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void ShowMultiTask()
        {
            SingleTask.ShowTitle("To Do");
            foreach (SingleTask t in tasks)
                t.ShowRow();
        }
    }
    //INSERT INTO `organizerdata`.`tasks` (`name`, `start`, `stop`, `status_id`, `criticality_id`, `user_id`, `category_id`, `smallDescription`, `largeDescription`) VALUES ('123', '2020-12-18 22:42:15', '2020-12-18 22:42:15', '1', '1', '1', '1', '1', '1');

}
