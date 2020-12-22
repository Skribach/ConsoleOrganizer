using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
    class Show
    {
        public void MakeChoise(string title, Items items)
        {
            Console.Clear();
            Console.WriteLine(title);
            int i = 1;
            foreach (Cell c in items.Cells)
            {
                Console.WriteLine($"{i++}. {c.Value};");
            }
            items.Cells.Count();

            int j;
            while(true)
            {
                j = int.Parse(Console.ReadLine());
                if ((0 < j) && (j < i))
                {
                    Console.WriteLine();
                    Console.WriteLine(items.Cells[j-1].Value);
                    return;
                }
                else
                    Console.WriteLine("Incorrect input, enter once");
            }
        }
    }
}
