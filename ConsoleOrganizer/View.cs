using System;
using System.Collections.Generic;

namespace ConsoleOrganizer
{
    class View
    {
        public static string database = "organizerdata";

        private string sql = "SELECT tasks.id, tasks.name, start, stop, statuses.name, criticalities.name, categories.name, smallDescription, largeDescription " +
         $"FROM {database}.tasks " +
         "INNER JOIN criticalities ON tasks.criticality_id = criticalities.id " +
         "INNER JOIN categories ON tasks.category_id = categories.id " +
         "INNER JOIN statuses ON tasks.status_id = statuses.id ";

        public void SelectGroup(List<GroupBy> groups)
        {
            Console.Clear();
            //Showing group values
            Console.WriteLine("GROUP BY: ");
            foreach (GroupBy group in groups)
            {
                Console.WriteLine($"{group.Key}. {group.Name};");
            }

            //Reading from console
            bool isWriteSucc = false;
            do
            {
                char k = Console.ReadKey().KeyChar;
                foreach (GroupBy group in groups)
                {
                    if (group.Key == k)
                    {
                        if (group.Name == "None")
                        {
                            SelectSort();
                        }
                        else
                        {
                            sql += group.Where;
                            SelectGroupVal(group);
                        }
                        isWriteSucc = true;
                    }
                }
            }
            while (!isWriteSucc);
        }

        public void SelectGroupVal(GroupBy group)
        {
            Console.Clear();
            Console.WriteLine("SELECT GROUP VALUE");

            List<GroupByValues> values = group.GetValues();
            foreach (GroupByValues val in values)
            {
                Console.WriteLine($"{val.Key}. {val.Name};");
            }

            //Reading from console
            bool isWriteSucc = false;
            do
            {
                char k = Console.ReadKey().KeyChar;
                foreach (GroupByValues val in values)
                {
                    if (val.Key == k)
                    {
                        sql += $"'{val.Name}' ";
                        SelectSort();
                        isWriteSucc = true;
                    }
                }
            }
            while (!isWriteSucc);
        }

        public void SelectSort()
        {
            //Console write info
            Console.Clear();
            Console.WriteLine("SELECT SORT TYPE:");
            List<SortValues> sorts = SortValues.GetSortVal();
            foreach (SortValues s in sorts)
                Console.WriteLine($"{s.Key}. {s.Name}");

            //Console read info
            bool isWriteSucc = false;
            do
            {
                char k = Console.ReadKey().KeyChar;
                foreach (SortValues s in sorts)
                {
                    if (s.Key == k)
                    {
                        sql += $"ORDER BY '{s.Name}' ";
                        SelectSortOrder();
                        isWriteSucc = true;
                    }
                }
            }
            while (!isWriteSucc);
        }

        public void SelectSortOrder()
        {
            //Console write info
            Console.Clear();
            Console.WriteLine("SELECT SORT Order:");
            Console.WriteLine("1.ASC");
            Console.WriteLine("2.DESC");

            //Console read indo
            bool isWriteSucc = false;
            do
            {
                char k = Console.ReadKey().KeyChar;
                if (k == '1')
                {
                    sql += $"ASC ";
                    ShowTasks(sql);
                    isWriteSucc = true;
                }
                else if (k == '2')
                {
                    sql += $"DESC ";
                    ShowTasks(sql);
                    isWriteSucc = true;
                }
            }
            while (!isWriteSucc);
            Console.ReadKey();
        }

        public void ShowTasks(string sql)
        {
            Console.WriteLine(sql);
        }
    }
}
