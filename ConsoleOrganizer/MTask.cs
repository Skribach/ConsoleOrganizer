using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;



namespace ConsoleOrganizer
{

    public class MTask  //Class contains many STasks(single tasks) and methods to work with
    {
        public MySqlConnection conn;

        private static string fd = "yyyy-MM-dd HH:mm:ss";   //Format date to MySQL server

        public MTask(MySqlConnection connection)
        {
            conn = connection;
        }

        public List<Stask> tasks = new List<Stask>();
        //Method for copy Rows from database by sql query
        public void GetTasks(string sql)
        {        
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader r = command.ExecuteReader();
            while (r.Read())
            {
                tasks.Add(new Stask((int)r[0], r[1].ToString(), DateTime.Parse(r[2].ToString()), DateTime.Parse(r[3].ToString()), r[4].ToString(), r[5].ToString(), r[6].ToString(), r[7].ToString()));
            }
            r.Close();
            conn.Close();
        }

        /*public void Remove(int id)
        {

        }
        public void Create(Stask st)
        {
            MySqlConnection connection = new MySqlConnection($"server = {Server}; user = {User}; database = {Database}; password = {Pass}");
            connection.Open();
            string sql = $"INSERT INTO `{Database}`.`tasks` " +
                "(`name`, `start`, `stop`, `status_id`, `criticality_id`, `user_id`, `category_id`, `smallDescription`, `largeDescription`) " +
                $"VALUES ('{st.Name}', '{st.Start.ToString(fd)}', '{st.Stop.ToString(fd)}', '1', '1', '1', '1', '1', '1')";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }*/

        public void ShowMultiTask()
        {
            Stask.ShowTitle("To Do");
            foreach (Stask t in tasks)
                t.ShowRow();
        }
    }
}

//INSERT INTO `organizerdata`.`tasks` (`name`, `start`, `stop`, `status_id`, `criticality_id`, `user_id`, `category_id`, `smallDescription`, `largeDescription`) VALUES ('123', '2020-12-18 22:42:15', '2020-12-18 22:42:15', '1', '1', '1', '1', '1', '1');