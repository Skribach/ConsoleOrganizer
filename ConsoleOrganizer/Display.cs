using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    class Display 
       
    {
        public delegate string Check(string a);
        private List<Group> grs;
        public Display(List<Group> groups)
        {
            grs = groups;
        }

        public void Title(string name)
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------|");
            Console.WriteLine($"{name,60}{" ",88}|");
            Console.WriteLine("-----+------------+---------------------+---------------------+---------------+---------------+---------------+-------------------------------------|");
            Console.WriteLine($"{"#",4} | {"Name",10} | {"Start",19} | {"Stop",19} | {"Status",13} | {"Critical",13} | {"Category",13} | {"Description",35} |");
            Console.WriteLine("-----+------------+---------------------+---------------------+---------------+---------------+---------------+-------------------------------------|");
        }

        public void STask(STask task, int num)
        {
            Console.WriteLine($"{num,4} | {task.Name,10} | {task.Start,19} | {task.Stop,19} | {grs[1].GetNameById(task.StatusId),13} | {grs[2].GetNameById(task.CriticalityId),13} | {grs[0].GetNameById(task.CategoryId),13} | {task.Desc,35} |");
            Console.WriteLine("-----+------------+---------------------+---------------------+---------------+---------------+---------------+-------------------------------------|");
        }

        public void MTask(List<STask> tasks, string title)
        {
            Console.Clear();
            Title(title);
            int i = 1;
            foreach (STask t in tasks)
                STask(t, i++);
        }

        public int ReadKey(int maxNum)
        {
            Console.WriteLine();
            int j;
            while (true)
            {
                int.TryParse(Console.ReadLine(), out j);
                if ((0 < j) && (j <= maxNum))
                {
                    return j - 1;
                }

                else
                    Console.WriteLine("Invalid choise. Please select again");
            }
        }       //Read key from 1 to maxNum

        public string EnterValue(string title, Check check)
        {
            Console.Clear();
            Console.WriteLine($"\n{title}\n");
            bool isWrong = true;
            string enterName = "";
            string err;
            while (isWrong)
            {
                enterName = Console.ReadLine();
                err = check(enterName);
                if (err != null)
                    Console.WriteLine(err);
                else
                    isWrong = false;
            }
            return enterName;
        }
        

        //Needed to use limited generics.
        public void WriteChoise(List<Group> li, string title)
        {
            Console.Clear();
            Console.WriteLine($"\n{title}\n");
            int i = 1;
            foreach (Group item in li)
                Console.WriteLine($"{i++}. {item.Name}");
        }
        public void WriteChoise(List<Item> li, string title)
        {
            Console.Clear();
            Console.WriteLine($"\n{title}\n");
            int i = 1;
            foreach (Item item in li)
                Console.WriteLine($"{i++}. {item.Name}");
        }
        public void WriteChoise(List<Field> li, string title)
        {
            Console.Clear();
            Console.WriteLine($"\n{title}\n");
            int i = 1;
            foreach (Field item in li)
                Console.WriteLine($"{i++}. {item.Name}");
        }
        public void WriteChoise(List<STask> li, string title)
        {
            Console.Clear();
            Console.WriteLine($"\n{title}\n");
            int i = 1;
            foreach (STask st in li)
                Console.WriteLine($"{i++}. {st.Name}");
        }
        public void WriteChoise(List<string> li, string title)
        {
            Console.Clear();
            Console.WriteLine($"\n{title}\n");
            int i = 1;
            foreach (string st in li)
                Console.WriteLine($"{i++}. {st}");
        }
    }
}
