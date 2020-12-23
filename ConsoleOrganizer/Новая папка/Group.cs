using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    class Group
    {
        public List<SubGroup> SubGroups { get; private set; }

        public Group()
        {
            SubGroups = GetSubGroups();
        }

        public List<SubGroup> GetSubGroups()
        {
            return new List<SubGroup>() { new SubGroup("Status", "statuses"), new SubGroup("Category", "categories"), new SubGroup("Criticality", "criticalities") };
        }
    }
}
