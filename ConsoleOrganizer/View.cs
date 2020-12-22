using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    class View
    {
        public static string database = "organizerdata";

           

        public string sql = "SELECT tasks.id, tasks.name, start, stop, statuses.name, criticalities.name, categories.name, smallDescription " +
         $"FROM {database}.tasks " +
         "INNER JOIN criticalities ON tasks.criticality_id = criticalities.id " +
         "INNER JOIN categories ON tasks.category_id = categories.id " +
         "INNER JOIN statuses ON tasks.status_id = statuses.id ";

        //public List<Group> groups = new List<Group>() { new Group("Status", "statuses", '1'), new Group("Category", "categories", '2'), new Group("Criticality", "criticalities", '3') };

        public bool IsNeedGroup()
        {
            Console.WriteLine("SELECT TASKS YOU WANT SEE:");
            Console.WriteLine("1. View All;");
            Console.WriteLine("2. View by Group;");

            char sym;
            do
            {
                sym = Console.ReadKey().KeyChar;
                if (sym == '1')
                    return false;
                if (sym == '2')
                    return true;
            }
            while (true);
        }

        public void SelectGroup(List<Group> groups)
        {
            Console.Clear();
            Console.WriteLine("SELECT GROUP YOU WANT TO SEE:");
            foreach (Group group in groups)
                Console.WriteLine($"{group.Key}. {group.Name}");

            //Reading from console
            do
            {
                char k = Console.ReadKey().KeyChar;
                foreach (Group group in groups)
                {
                    if (group.Key == k)
                    {
                        sql += $"WHERE {group.TableName}.id = ";
                        SelectGroupVal(group);
                        return;
                    }
                }
            }
            while (true);
        }

        private void SelectGroupVal(Group group)
        {
            Console.Clear();
            Console.WriteLine("SELECT GROUPNAME YOU WANT TO SEE:");
            List<Item> items = group.GetItems();
            foreach (Item item in items)
                Console.WriteLine($"{item.Key}. {item.Name}");

            //Reading from console
            do
            {
                char k = Console.ReadKey().KeyChar;
                foreach (Item item in items)
                {
                    if (item.Key == k)
                    {
                        sql += $"'{item.Id}' ";
                        return;
                    }
                }
            }
            while (true);
        }

        public void SelectSort(List<Sort> sorts)
        {
            Console.Clear();
            Console.WriteLine("SELECT SORT YOU WANT APPLY");

            foreach (Sort sort in sorts)
                Console.WriteLine($"{sort.Key}. {sort.Name}");

            //Reading from console
            do
            {
                char k = Console.ReadKey().KeyChar;
                foreach (Sort sort in sorts)
                {
                    if (sort.Key == k)
                    {
                        sql += $"ORDER BY {sort.ColumnName} ";
                        return;
                    }
                }
            }
            while (true);
        }
    }
}
