using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ConsoleOrganizer
{
    class Program
    {
        delegate string Check(string s);

        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 40);

            WorkDB db = new WorkDB("f0500850.xsph.ru", "f0500850_organizer_user", "f0500850_organizerdata", "1234");
            //WorkDB db = new WorkDB("localhost", "root", "organizerdata", "1234");

            Data data = new Data(db);
            Display display = new Display(data.groups);
            Menus menu = new Menus(db, display);

            Group workGroup;
            while (true)
            {
                switch (menu.MainPage())
                {
                    case 0:
                        workGroup = menu.SelectGroupedTasksBy(data.groups);
                        if (workGroup == null)
                        {
                            Field fiOrd = menu.SelectOrder(data.fields);
                            bool isAsc = menu.SelectOrderDirection();
                            menu.View(fiOrd, isAsc);
                        }
                        else
                        {
                            Item it = menu.SelectGroupName(workGroup, "Select group name:");
                            Field fiOrd = menu.SelectOrder(data.fields);
                            bool isAsc = menu.SelectOrderDirection();
                            menu.View(workGroup, it, fiOrd, isAsc);
                        }
                        break;
                    case 1:
                        workGroup = menu.SelectGroup(data.groups, "Add");
                        if (workGroup == null)
                        {
                            STask newTask = menu.EnterSTaskParams(data.groups);
                            menu.Add(newTask);
                        }
                        else
                        {
                            menu.Add(workGroup, menu.EnterNewGroupName(workGroup));
                            data.UpdateFields();
                        }
                        break;
                    case 2:
                        workGroup = menu.SelectGroup(data.groups, "Delete");
                        if (workGroup == null)
                        {
                            menu.Remove(menu.SelectSTask());
                        }
                        else
                        {
                            menu.Remove(workGroup, menu.SelectGroupName(workGroup, "Select group name"));
                            foreach (Group group in data.groups)
                                group.UpdateItems();
                        }
                        break;
                    case 3:
                        workGroup = menu.SelectGroup(data.groups, "Edit");
                        if (workGroup == null)
                        {
                            Field fi = menu.SelectFieldTask(data.fields);
                            menu.Edit(menu.SelectSTask(), fi, menu.UpdateFieldTask(fi, data.groups));
                        }
                        else
                        {
                            menu.Edit(workGroup, menu.SelectGroupName(workGroup, "Select group you want rename"), menu.EnterNewItemName(workGroup));
                            foreach (Group gr in data.groups)
                                gr.UpdateItems();
                        }
                        break;
                }
            }
        }
    }


}
