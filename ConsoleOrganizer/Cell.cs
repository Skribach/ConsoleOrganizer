using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    class Cell
    {
        public int Id { get; private set; }
        public string Value { get; private set; }

        public Cell(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public void UpdateItem()
        {
            Id = 0;
            Value = "UpdatedValue";
        }
    }
}
