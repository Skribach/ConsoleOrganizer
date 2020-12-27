using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (name.Count() > 13)
                return "Max. length of group = 13";
            Regex regex = new Regex("[0-9a-zA-Z ]");
            MatchCollection matches = regex.Matches(name);
            if (matches.Count != name.Count())
                return "Available symbols are [0-9] or/and [a-z] or/and [A-Z]\nPlease, reEnter";
            return null;
        }
    }

}
