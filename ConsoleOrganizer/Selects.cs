using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    class Selects
    {
        public delegate string GroupQuery(Group gr);

        

        public int SelectGroup(List<Group> groups, string title, string addChoise)
        {
            Console.Clear();
            Console.WriteLine($"\n\t{title}\n");            //SELECT GROUP YOU WANT TO SEE:
            int i = 1;
            foreach (Group gr in groups)
                Console.WriteLine($"\t{i++}. {gr.Name}");
            Console.WriteLine($"\t{i}. {addChoise}");       //One more choise "None" if it View

            int j;
            while (true)
            {
                int.TryParse(Console.ReadLine(), out j);
                if ((0 < j) && (j < i))
                {
                    return j;
                }
                else if (j == i)
                {

                    return 0;
                }
                else
                    Console.WriteLine("Invalid choise. Please select again");
            }
        }

        public string AddGroupVal(Group gr)
        {
            Console.Clear();
            Console.WriteLine($"\n\tValues of group {gr.Name} are:\n");
            int i = 1;
            List<Item> items = gr.GetItems();
            foreach (Item item in items)
                Console.WriteLine($"\t{i++}. {item.Value}");
            Console.WriteLine("\nWrite name of new group:");
            string newName = Console.ReadLine();
            while (newName.Length > 10)
            {
                Console.WriteLine("The value is very large: MAX characters for groups = 10. Please, enter again");
                newName = Console.ReadLine();
            }

            return $"INSERT INTO '{gr.TableName}' ('name') VALUES ('{newName}');";
        }

        public string RemoveGroupVal(Group gr)
        {
            Console.Clear();
            Console.WriteLine($"\n\tValues of group {gr.Name} are:\n");
            int i = 1;
            List<Item> items = gr.GetItems();
            foreach (Item item in items)
                Console.WriteLine($"\t{i++}. {item.Value}");
            Console.WriteLine("\nWrite digit of group you want remove:");

            int j;
            while (true)
            {
                int.TryParse(Console.ReadLine(), out j);
                if ((0 < j) && (j < i))
                {
                    return $"DELETE FROM '{gr.TableName}' WHERE id = '{items[j - 1]}'; ";
                }
                else
                    Console.WriteLine("Invalid choise. Please select again");
            }
        }

        public string EditGroupVal(Group gr)
        {
            Console.Clear();
            Console.WriteLine($"\n\tValues of group {gr.Name} are:\n");
            int i = 1;
            List<Item> items = gr.GetItems();
            foreach (Item item in items)
                Console.WriteLine($"\t{i++}. {item.Value}");
            Console.WriteLine("\nWrite digit of group you want edit:");

            int j;
            bool isOk = false;
            while (!isOk)
            {
                int.TryParse(Console.ReadLine(), out j);
                if ((0 < j) && (j < i))
                {
                    isOk = true;
                }
                else
                    Console.WriteLine("Invalid choise. Please select again");
            }
            Console.WriteLine("\nWrite new name of group:");
            string newName = Console.ReadLine();
            while (newName.Length > 10)
            {
                Console.WriteLine("The value is very large: MAX characters for groups = 10. Please, enter again");
                newName = Console.ReadLine();
            }
            return $"UPDATE '{gr.TableName}' SET 'name' = '{newName}' WHERE('id') = '{items[j - 1].Id}') ";
        }

    }
}
