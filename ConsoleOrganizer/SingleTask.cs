using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
	public class SingleTask
	{
		private int id;
		public string Name { get; }
		public DateTime Start { get; }
		public DateTime Stop { get; }
		public string Status { get; }
		public string Criticality { get; }
		public string Category { get; }
		public string SmallDesc { get; }
		public string LargeDesc { get; }

		public SingleTask(int id, string name, DateTime start, DateTime stop, string status, string criticality, string category, string sdesc, string ldesc)
		{
			this.id = id;
			Name = name;
			Start = start;
			Stop = stop;
			Status = status;
			Criticality = criticality;
			Category = category;
			SmallDesc = sdesc;
			LargeDesc = ldesc;
		}

		public void ShowRow()
        {
            Console.WriteLine($"{id, 4} | {Name, 15} | {Start, 19} | {Stop, 19} | {Status, 13} | {Criticality, 10} | {Category, 10} | {SmallDesc, 30} |");
            Console.WriteLine("-----+-----------------+---------------------+---------------------+---------------+------------+------------+--------------------------------|");
        }

		static public void ShowTitle(string name)
        {
			Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------|");
			Console.WriteLine($"{name, 60}{" ",82}|");
			Console.WriteLine("-----+-----------------+---------------------+---------------------+---------------+------------+------------+--------------------------------|");
			Console.WriteLine($"{"ID",4} | {"Name",15} | {"Start",19} | {"Stop",19} | {"Status",13} | {"Critical",10} | {"Category",10} | {"SmallDesc", 30} |");
			Console.WriteLine("-----+-----------------+---------------------+---------------------+---------------+------------+------------+--------------------------------|");
		}

		
	}
}
