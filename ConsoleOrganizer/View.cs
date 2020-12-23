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
        public string sql = "SELECT tasks.id, tasks.name, start, stop, statuses.name, criticalities.name, categories.name, description " +
         $"FROM {database}.tasks " +
         "INNER JOIN criticalities ON tasks.criticality_id = criticalities.id " +
         "INNER JOIN categories ON tasks.category_id = categories.id " +
         "INNER JOIN statuses ON tasks.status_id = statuses.id ";

        public void GroupBy(List<Group> groups)
        {
            Console.Clear();            
            Console.WriteLine("\nSELECT GROUP YOU WANT TO SEE\n");
            int i = 1;
            foreach (Group gr in groups)
                Console.WriteLine($"\t{i++}. {gr.Name}");
            Console.WriteLine($"\t{i}. None");

            int j;
            while (true)
            {
                int.TryParse(Console.ReadLine(), out j);
                if ((0 < j) && (j < i))
                {
                    sql += $"WHERE {groups[j - 1].TableName}.name = ";
                    SelectGroupVal(groups[j - 1]);
                    return;
                }
                else if (j == i)
                    return;
                else
                    Console.WriteLine("Invalid choise. Please select again");
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

            int j;
            while (true)
            {
                int.TryParse(Console.ReadLine(), out j);
                if ((0 < j) && (j < i))
                {
                    sql += $"'{items[j - 1].Value}' ";
                    return;
                }
                else
                    Console.WriteLine("Invalid choise. Please select again");
            }
        }

        public void SortBy(Group ord)
        {
            Console.Clear();
            Console.WriteLine("SELECT SORT");
            int i = 1;
            List<Order> orders = ord.GetOrders();
            foreach (Order o in orders)
                Console.WriteLine($"{i++}. {o.Name}");
            Console.WriteLine($"{i}. None");

            int j;
            while (true)
            {
                int.TryParse(Console.ReadLine(), out j);
                if ((0 < j) && (j < i))
                {
                    sql += $"ORDER BY '{orders[j - 1].Value}' ";
                    SelectSortDirect();
                    return;
                }
                else if (j == i)
                    return;
                else
                    Console.WriteLine("Invalid choise. Please select again");
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
                int.TryParse(Console.ReadLine(), out j);
                if (j == 1)
                {
                    sql += "ASC ";
                    return;
                }
                else if (j == 2)
                {
                    sql += "DESC ";
                    return;
                }
                else
                    Console.WriteLine("Invalid choise. Please select again");
            }
        }
    }
}