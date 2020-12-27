using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    class Data
    {
        private WorkDB db;
        public List<Group> groups;
        public List<Field> fields;

        public Data (WorkDB db)
        {
            this.db = db;
            fields = db.GetFields();
            groups = new List<Group>()
            {
                new Group ("Category", "categories", "category_id", db),
                new Group ("Status", "statuses", "status_id", db),
                new Group ("Criticality", "criticalities", "criticality_id", db)
            };
        }
        
        public void UpdateFields()
        {
            fields = db.GetFields();
        }
    }
}
