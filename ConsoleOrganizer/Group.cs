using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleOrganizer
{
    class Group
    {
        public string Name { get; private set; }
        public string TableName { get; private set; }
        public string ColumnName { get; private set; }
        private WorkDB db;
        public List<Item> items = new List<Item>();

        public Group(string name, string tableName, string columnName, WorkDB db )
        {
            ColumnName = columnName;
            Name = name;
            TableName = tableName;
            this.db = db;
            items = db.GetItems(this);
        }

        public string GetNameById(int id)
        {
            for (int i = 0; i < items.Count; i++)
                if (items[i].Id == id)
                    return items[i].Name;
            return "notFound";
        }

        public void UpdateItems()
        {
            items = db.GetItems(this);
        }

        public string CheckName(string name)
        {
            return null;
        }
    }

}
