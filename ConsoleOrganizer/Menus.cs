using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    class Menus
    {
        private WorkDB db;
        private Display di;
        public Menus(WorkDB db, Display di)
        {
            this.db = db;
            this.di = di;
        }

        public int MainPage()
        {
            List<string> menus = new List<String>()
            {
                "View Tasks",
                "Add Task",
                "Remove Task",
                "Edit Task"
            };

            di.WriteChoise(menus, "Task orginizer");
            return di.ReadKey(menus.Count);
        }

        public Group SelectGroupedTasksBy(List<Group> li)
        {
            di.WriteChoise(li, "View:");
            Console.WriteLine($"{li.Count + 1}. All");
            int key = di.ReadKey(li.Count + 1);
            if (key == li.Count)
                return null;
            else
                return li[key];
        }

        public Item SelectGroupName(Group gr, string title)
        {
            di.WriteChoise(gr.items, title);
            int key = di.ReadKey(gr.items.Count + 1);
            if (key == gr.items.Count)
                return null;
            else
                return gr.items[key];
        }

        public Field SelectOrder(List<Field> li)
        {
            di.WriteChoise(li, "Order by");
            return li[di.ReadKey(li.Count)];

        }

        public bool SelectOrderDirection()
        {
            Console.Clear();
            Console.WriteLine($"\nSelect Order Direction\n");
            Console.WriteLine("1. ASC Order");
            Console.WriteLine("2. DESC Order");

            return di.ReadKey(2) == 2 ? true : false;
        }

        public void ViewResult(Field fi, bool isAsc)
        {
            List<STask> tasks = db.GetSTasks(fi, isAsc);
            di.MTask(tasks, $"Tasks ordered by {fi.Value}");
            return;
        }

        public void ViewResult(Group gr, Item it, Field fi, bool isAsc)
        {
            List<STask> tasks = db.GetSTasks(gr, it, fi, isAsc);
            di.MTask(tasks, $"Tasks in group {gr.Name} = {it.Name} ordered by {fi.Name}");
            return;
        }

        public Group SelectGroup(List<Group> li, string title)
        {
            di.WriteChoise(li, title);
            Console.WriteLine($"{li.Count + 1}. Task");
            int key = di.ReadKey(li.Count + 1);
            if (key == li.Count)
                return null;
            else
                return li[key];
        }

        public string EnterNewGroupName(Group gr)
        {
            Console.Clear();
            Console.WriteLine($"\nEnter new {gr.Name} name:\n");
            bool isWrong = true;
            string enterName = "";
            string err;
            while (isWrong)
            {
                enterName = Console.ReadLine();
                err = gr.CheckName(enterName);
                if (err != null)
                    Console.WriteLine(err);
                else
                    isWrong = false;
            }
            return enterName;
        }

        public STask EnterSTaskParams(List<Group> li)
        {
            string name = di.EnterValue("Enter name for task:", STask.CheckName);
            DateTime start = DateTime.Parse(di.EnterValue("Enter start time in format yyyy-MM-dd HH:mm:ss", STask.CheckStart));
            DateTime stop = DateTime.Parse(di.EnterValue("Enter stop time in format yyyy-MM-dd HH:mm:ss", STask.CheckStart));
            List<Item> items = new List<Item>();
            foreach (Group gr in li)
                items.Add(SelectGroupName(gr, $"Select {gr.Name}"));
            string desc = di.EnterValue("Enter description for task", STask.CheckDesc);
            return new STask(name, start, stop, items[1].Id, items[2].Id, items[0].Id, desc);
        }

        public void AddResult(Group gr, string newName)
        {
            Console.Clear();
            db.Add(gr, newName);
            Console.WriteLine("Group added successfully");
        }

        public void AddResult(STask st)
        {
            Console.Clear();
            db.Add(st);
            Console.WriteLine("Task added successfully");
        }

        public STask SelectSTask()
        {
            List<STask> li = db.GetSTasks();
            Console.Clear();
            di.MTask(li, "Select number of task you want to delete");
            di.ReadKey(li.Count);
            return li[di.ReadKey(li.Count)];
        }

        public void RemoveResults(Group gr, Item it)
        {
            Console.Clear();
            db.Remove(gr, it);
            Console.WriteLine("Remove group complited");
        }

        public void RemoveResults(STask st)
        {
            Console.Clear();
            db.Remove(st);
            Console.WriteLine("Remove task complited");
        }

        public Field SelectFieldTask(List<Field> fi)
        {
            Console.Clear();
            di.WriteChoise(fi, "Select field you want change");
            return fi[di.ReadKey(fi.Count)];
        }

        public void EditResult(STask st, Field fi, string newField)
        {
            Console.Clear();
            db.Edit(st, fi, newField);
            Console.WriteLine("Edit task complited");
        }

        public void EditResult(Group gr, Item it, Item newIt)
        {
            Console.Clear();
            db.Edit(gr, it, newIt);
            Console.WriteLine("Edit task complited");
        }
    }
}