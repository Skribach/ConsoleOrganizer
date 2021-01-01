using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        //public STask() : base(0, "") { }

        public static string CheckName(string name)
        {
            if (name.Count() > 10)
                return "Max. length of name = 10";
            else if (name.Count() == 0)
                return "Empty field. Please reEnter";
            Regex regex = new Regex("[0-9a-zA-Z ]");
            MatchCollection matches = regex.Matches(name);
            if (matches.Count != name.Count())
                return "Available symbols are [0-9] or/and [a-z] or/and [A-Z]\nPlease, reEnter";
            return null;
        }
        public static string CheckStart(string start)
        {
            DateTime dt;
            if (DateTime.TryParse(start, out dt))
                return null;
            return "Wrong Format date. ReEnter ";
        }
        public static string CheckStop(string stop)
        {
            DateTime dt;
            if (DateTime.TryParse(stop, out dt))
                return null;
            return "Wrong Format date. ReEnter";
        }
        public static string CheckDesc(string desc)
        {
            if (desc.Count() > 35)
                return "Max. length of description = 35";
            else if (desc.Count() == 0)
                return "Empty field. Please reEnter";
            Regex regex = new Regex("[0-9a-zA-Z ]");
            MatchCollection matches = regex.Matches(desc);
            if (matches.Count != desc.Count())
                return "Available symbols are [0-9] or/and [a-z] or/and [A-Z]\nPlease, reEnter";
            return null;
        }
    }
}