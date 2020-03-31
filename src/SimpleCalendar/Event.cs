using System;
using System.Collections;

namespace SimpleCalendar
{

    public enum Priority
    {
        Low = 1,
        Medium = 2,
        High = 3
    }

    public class Event : IComparable
    {

        public DateTime StartDate { get; set; }
        public int LengthInHours { get; set; }
        public string Description { get; set; } = string.Empty;

        public Priority Priority { get; set; }

        public static IComparer SortByStartDate
            { get { return (IComparer)new StartDateComparer(); } }

        public static IComparer SortByPriority
            { get { return (IComparer)new PriorityComparer(); } }

        public Event() {}
        public Event(DateTime startDate)
        {
            StartDate = startDate;
        }
        public Event(DateTime startDate, int lengthInHours)
        {
            StartDate = startDate;
            LengthInHours = lengthInHours;
            Priority = Priority.Low;
        }
        public Event(DateTime startDate, int lengthInHours, String description)
        {
            StartDate = startDate;
            LengthInHours = lengthInHours;
            Description = description;
            Priority = Priority.Low;
        }
        public Event(DateTime startDate, int lengthInHours, String description, Priority priority)
        {
            StartDate = startDate;
            LengthInHours = lengthInHours;
            Description = description;
            Priority = priority;
        }

        public void Print()
        {
            Console.WriteLine($"Event:\n  Start time: {StartDate}\n  length: {LengthInHours} h\n  description: {Description}\n  priority: {Priority}\n");
        }

        public int CompareTo(object obj)
        {
            Event temp = obj as Event;
            if (temp != null)
            {
                return this.StartDate.CompareTo(temp.StartDate);
            }
            else
                throw new ArgumentException("Object is not a calendar Event!");
        }
    }
}
