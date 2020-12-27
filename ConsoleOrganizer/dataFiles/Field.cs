using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    public class Field : Item
    {
        public string Value { get; private set; }

        public Field(int id, string name, string value) : base (id, name)
        {
            Value = value;
        }
    }
}
