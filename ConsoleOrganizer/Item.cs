using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    public class Item
    {
        public int Id { get;  private set; }
        public string Name { get; private set; }

        public Item(int id, string value)
        {
            Id = id;
            Name = value;
        }
    }
}
