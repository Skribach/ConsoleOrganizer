using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    class View
    {
        public static string database = "organizerData";
        public string sql = "SELECT tasks.id, tasks.name, start, stop, statuses.name, criticalities.name, categories.name, smallDescription " +
         $"FROM {database}.tasks " +
         "INNER JOIN criticalities ON tasks.criticality_id = criticalities.id " +
         "INNER JOIN categories ON tasks.category_id = categories.id " +
         "INNER JOIN statuses ON tasks.status_id = statuses.id ";

        public void GroupBy(List<Group> groups)
        {
            Console.Clear();
            Console.WriteLine("SELECT GROUP YOU WANT TO SEE");
            int i = 1;
            foreach (Group gr in groups)
                Console.WriteLine($"{i++}. {gr.Name}");
            Console.WriteLine($"{i}. None");

            int j;
            while (true)
            {
                j = int.Parse(Console.ReadLine());
                if ((0 < j) && (j < i))
                {
                    sql += $"WHERE {groups[j - 1].TableName}.name = ";
                    SelectGroupVal(groups[j - 1]);
                    return;
                }
                else if (j == i)
                {
                    return;
                }
            }
        }
        public void SelectGroupVal(Group gr)
        {
            Console.Clear();
            Console.WriteLine("SELECT GROUP NAME YOU WANT TO SEE");
            int i = 1;
            List<Item> items = gr.GetItems();
            foreach (Item item in items)
                Console.WriteLine($"{i++}. {item.Value}");
            Console.WriteLine($"{i}. Back");

            int j;
            while (true)
            {
                j = int.Parse(Console.ReadLine());
                if ((0 < j) && (j < i))
                {
                    sql += $"'{items[j - 1].Value}' ";
                    return;
                }
                else if (j == i)
                {
                    return;
                }
            }
        }

        public void SortBy(Group sort)
        {
            Console.Clear();
            Console.WriteLine("SELECT SORT");
            int i = 1;
            List<Item> items = sort.GetItems();
            foreach (Item item in items)
                Console.WriteLine($"{i++}. {item.Value}");
            Console.WriteLine($"{i}. None");

            int j;
            while (true)
            {
                j = int.Parse(Console.ReadLine());
                if ((0 < j) && (j < i))
                {
                    sql += $"ORDER BY '{items[j - 1].Value}' ";
                    SelectSortDirect();
                    return;
                }
                else if (j == i)
                {
                    return;
                }
            }
        }
        public void SelectSortDirect()
        {
            Console.Clear();
            Console.WriteLine("SELECT SORT");
            Console.WriteLine($"1. ASC");
            Console.WriteLine($"2. DESC");

            int j;
            while (true)
            {
                j = int.Parse(Console.ReadLine());
                if (j == 1)
                {
                    sql += "ASC;";
                    return;
                }
                else if (j == 2)
                {
                    sql += "DESC;";
                    return;
                }

            }
        }

    }
}