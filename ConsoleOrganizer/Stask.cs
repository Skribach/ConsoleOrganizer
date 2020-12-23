using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
	public class Stask
	{
		public int Id { get; }
		public string Name { get; }
		public DateTime Start { get; }
		public DateTime Stop { get; }
		public string StatusId { get; }
		public string CriticalityId { get; }
		public string CategoryId { get; }
		public string Desc { get; }

		public Stask(string name, DateTime start, DateTime stop, string status, string criticality, string category, string sdesc)
		{
			Name = name;
			Start = start;
			Stop = stop;
			StatusId = status;
			CriticalityId = criticality;
			CategoryId = category;
			Desc = sdesc;
		}
		public Stask(int id, string name, DateTime start, DateTime stop, string status, string criticality, string category, string sdesc) : base()
		{
			Id = id;
			Name = name;
			Start = start;
			Stop = stop;
			StatusId = status;
			CriticalityId = criticality;
			CategoryId = category;
			Desc = sdesc;
		}

		static public void ShowTitle(string name)
		{
			Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------|");
			Console.WriteLine($"{name,60}{" ",82}|");
			Console.WriteLine("-----+-----------------+---------------------+---------------------+---------------+------------+------------+--------------------------------|");
			Console.WriteLine($"{"ID",4} | {"Name",15} | {"Start",19} | {"Stop",19} | {"Status",13} | {"Critical",10} | {"Category",10} | {"SmallDesc",30} |");
			Console.WriteLine("-----+-----------------+---------------------+---------------------+---------------+------------+------------+--------------------------------|");
		}

		public void ShowRow()
		{
			Console.WriteLine($"{Id,4} | {Name,15} | {Start,19} | {Stop,19} | {StatusId,13} | {CriticalityId,10} | {CategoryId,10} | {Desc,30} |");
			Console.WriteLine("-----+-----------------+---------------------+---------------------+---------------+------------+------------+--------------------------------|");
		}
	}
}