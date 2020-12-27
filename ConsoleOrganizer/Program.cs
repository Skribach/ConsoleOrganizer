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
            Display di = new Display(data.groups);
            Menus me = new Menus(db, di);

            Group workGroup;
            while(true)
            {
                switch(me.MainPage())
                {
                    case 0:
                        workGroup = me.SelectGroupedTasksBy(data.groups);
                        if (workGroup == null)
                        {
                            Field fiOrd = me.SelectOrder(data.fields);
                            bool isAsc = me.SelectOrderDirection();
                            me.View(fiOrd, isAsc);
                        }
                        else
                        {
                            Item it = me.SelectGroupName(workGroup, "Select group name:");
                            Field fiOrd = me.SelectOrder(data.fields);
                            bool isAsc = me.SelectOrderDirection();
                            me.View(workGroup, it, fiOrd, isAsc);
                        }
                        break;
                    case 1:
                        workGroup = me.SelectGroup(data.groups, "Add");
                        if(workGroup == null)
                        {
                            STask newTask = me.EnterSTaskParams(data.groups);
                            me.Add(newTask);
                        }
                        else
                        {
                            me.Add(workGroup, me.EnterNewGroupName(workGroup));
                            data.UpdateFields();
                        }
                        break;
                    case 2:
                        workGroup = me.SelectGroup(data.groups, "Delete");
                        if(workGroup == null)
                        {
                            me.Remove(me.SelectSTask());
                        }
                        else
                        {
                            me.Remove(workGroup, me.SelectGroupName(workGroup, "Select group name"));
                            foreach (Group group in data.groups)
                                group.UpdateItems();
                        }
                        break;
                    case 3:
                        workGroup = me.SelectGroup(data.groups, "Edit");
                        if(workGroup==null)
                        {
                            Field fi = me.SelectFieldTask(data.fields);
                            me.Edit(me.SelectSTask(),fi, me.UpdateFieldTask(fi, data.groups));
                        }
                        else
                        {
                            me.Edit(workGroup, me.SelectGroupName(workGroup, "Select group you want rename"), me.EnterNewItemName(workGroup));
                            foreach (Group gr in data.groups)
                                gr.UpdateItems();
                        }
                        break;
                }
            }
        }
    }


}
