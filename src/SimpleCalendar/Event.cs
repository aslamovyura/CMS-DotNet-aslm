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
        public DateTime StartDate { get; set; } = DateTime.Today;
        public int LengthInHours { get; set; } = 1;
        public string Description { get; set; } = string.Empty;
        public Priority Priority { get; set; } = Priority.Low;
        public int ID { get; set; } = 0;

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
        public Event(DateTime startDate, int lengthInHours, string description)
        {
            StartDate = startDate;
            LengthInHours = lengthInHours;
            Description = description;
            Priority = Priority.Low;
        }
        public Event(DateTime startDate, int lengthInHours, string description, Priority priority)
        {
            StartDate = startDate;
            LengthInHours = lengthInHours;
            Description = description;
            Priority = priority;
        }
        public Event(DateTime startDate, int lengthInHours, string description, Priority priority, int id)
        {
            StartDate = startDate;
            LengthInHours = lengthInHours;
            Description = description;
            Priority = priority;
            ID = id;
        }

        public void Print()
        {
            Console.WriteLine($"Event:\n  Start time: {StartDate}\n  length: {LengthInHours} h\n  description: {Description}\n  priority: {Priority}\n  ID: {ID}\n");
        }

        public void ShiftEvent(TimeSpan shift)
        {
            if (shift != null)
                StartDate = StartDate.Add(shift);
            else
                throw new ArgumentNullException();
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
