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

            WorkDB db = new WorkDB("localhost", "root", "organizerdata", "1234");

            List<Group> groups = new List<Group>()
            {
                new Group ("Category", "categories", "category_id", db),
                new Group ("Status", "statuses", "status_id", db),
                new Group ("Criticality", "criticalities", "criticality_id", db)
            };
            List<Field> fields = db.GetFields();

            Display di = new Display(groups);
            Menus me = new Menus(db, di);

            while(true)
            {
                switch(me.MainPage())
                {
                    case 0:
                        Group gView = me.SelectGroupedTasksBy(groups);
                        if (gView == null)
                        {
                            Field fiOrd = me.SelectOrder(fields);
                            bool isAsc = me.SelectOrderDirection();
                            me.ViewResult(fiOrd, isAsc);
                        }
                        else
                        {
                            Item it = me.SelectGroupName(gView, "Select group name:");
                            Field fiOrd = me.SelectOrder(fields);
                            bool isAsc = me.SelectOrderDirection();
                            me.ViewResult(gView, it, fiOrd, isAsc);
                        }
                        break;
                    case 1:
                        Group gAdd = me.SelectGroup(groups, "Add");
                        if(gAdd == null)
                        {
                            STask newTask = me.EnterSTaskParams(groups);
                            me.AddResult(newTask);
                        }
                        else
                        {
                            me.AddResult(gAdd, me.EnterNewGroupName(gAdd));
                        }
                        break;
                    case 2:
                        Group gDel = me.SelectGroup(groups, "Delete");
                        if(gDel == null)
                        {
                            me.RemoveResults(me.SelectSTask());
                        }
                        else
                        {
                            me.RemoveResults(gDel, me.SelectGroupName(gDel, "Select group name"));
                            fields = db.GetFields();
                        }
                        break;
                }
            }
        }
    }


}
