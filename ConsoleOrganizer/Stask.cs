using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOrganizer
{
	public class STask : Item
	{
		public DateTime Start { get; }
		public DateTime Stop { get; }
		public int StatusId { get; }
		public int CriticalityId { get; }
		public int CategoryId { get; }
		public string Desc { get; }

		
		public STask(int id, string name, DateTime start, DateTime stop, int status, int criticality, int category, string sdesc) : base(id, name)
		{			
			Start = start;
			Stop = stop;
			StatusId = status;
			CriticalityId = criticality;
			CategoryId = category;
			Desc = sdesc;
		}

		public STask(string name, DateTime start, DateTime stop, int status, int criticality, int category, string sdesc) : base(0, name)
		{
			Start = start;
			Stop = stop;
			StatusId = status;
			CriticalityId = criticality;
			CategoryId = category;
			Desc = sdesc;
		}

		
	}
}