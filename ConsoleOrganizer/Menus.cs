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
                "Add",
                "Remove",
                "Edit"
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

            return di.ReadKey(2) == 0 ? true : false;
        }

        public void View(Field fi, bool isAsc)
        {
            List<STask> tasks = db.GetSTasks(fi, isAsc);
            di.MTask(tasks, $"Tasks ordered by {fi.Name}");
            Console.ReadKey();
            return;
        }
        public void View(Group gr, Item it, Field fi, bool isAsc)
        {
            List<STask> tasks = db.GetSTasks(gr, it, fi, isAsc);
            di.MTask(tasks, $"Tasks in group {gr.Name} = {it.Name} ordered by {fi.Name}");
            Console.ReadKey();
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

        private string EnterName(string title)
        {
            return di.EnterValue(title, STask.CheckName);
        }
        private DateTime EnterDateTime(string title)
        {
            return DateTime.Parse(di.EnterValue(title, STask.CheckStart));
        }
        private string EnterDesc()
        {
            return di.EnterValue("Enter description for task", STask.CheckDesc);
        }
        private List<Item> EnterItems(List<Group> li)
        {
            List<Item> items = new List<Item>();
            foreach (Group gr in li)
                items.Add(SelectGroupName(gr, $"Select {gr.Name}"));
            return items;
        }
        public STask EnterSTaskParams(List<Group> li)
        {
            string name = EnterName("Enter name for new task:");
            DateTime start = EnterDateTime("Enter start time in format yyyy-MM-dd HH:mm:ss");
            DateTime stop;
            do
                stop = EnterDateTime("Enter stop time in format yyyy-MM-dd HH:mm:ss");
            while (stop <= start);
            List<Item> items = EnterItems(li);
            string desc = EnterDesc();
            return new STask(name, start, stop, items[1].Id, items[2].Id, items[0].Id, desc);
        }

        public void Add(Group gr, string newName)
        {
            Console.Clear();
            Console.WriteLine(db.Add(gr, newName));
            Console.ReadKey();
        }
        public void Add(STask st)
        {
            Console.Clear();
            Console.WriteLine(db.Add(st));
            Console.ReadKey();
        }

        public STask SelectSTask()
        {
            List<STask> li = db.GetSTasks();
            Console.Clear();
            di.MTask(li, "Select number of task you want to delete");
            return li[di.ReadKey(li.Count)];
        }

        public void Remove(Group gr, Item it)
        {
            Console.Clear();
            Console.WriteLine(db.Remove(gr, it));
            Console.ReadKey();
        }
        public void Remove(STask st)
        {
            Console.Clear();
            db.Remove(st);
            Console.WriteLine("Remove task complited");
            Console.ReadKey();
        }

        public Field SelectFieldTask(List<Field> fi)
        {
            Console.Clear();
            di.WriteChoise(fi, "Select field you want change");
            return fi[di.ReadKey(fi.Count)];
        }

        public string UpdateFieldTask(Field fi, List<Group> groups)
        {
            switch (fi.Name)
            {
                case "Name":
                    return EnterName("Update name");
                case "Start":
                    return EnterDateTime("Update start time in format yyyy-MM-dd HH:mm:ss").ToString(db.FD);
                case "Stop":
                    return EnterDateTime("Update start time in format yyyy-MM-dd HH:mm:ss").ToString(db.FD);
                case "Status":
                    return SelectGroupName(groups[1], "Update status:").Name;
                case "Criticality":
                    return SelectGroupName(groups[2], "Update status:").Name;
                case "Category":
                    return SelectGroupName(groups[0], "Update status:").Name;
            }
            return null;
        }

        public void Edit(STask st, Field fi, string newField)
        {
            Console.Clear();
            db.Edit(st, fi, newField);
            Console.WriteLine("Edit task complited");
        }
        public void Edit(Group gr, Item it, Item newIt)
        {
            Console.Clear();
            db.Edit(gr, it, newIt);
            Console.WriteLine("Edit task complited");
        }

        public Item EnterNewItemName(Group gr)
        {
            Console.Clear();
            Console.WriteLine($"\nEnter new name:\n");
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
            return new Item(0, enterName);
        }
    }
}