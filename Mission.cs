using System;

namespace ConsoleOrganizer

public class Mission
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

	public Mission(int id, string name, DateTime start, DateTime stop, string status, string criticality, string category, string sdesc, string ldesc)
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
}
