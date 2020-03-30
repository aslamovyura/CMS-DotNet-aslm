using System;
using System.Collections;

namespace SimpleCalendar
{
    public class StartDateComparer : IComparer
    {
        public StartDateComparer() { }

        int IComparer.Compare(object o1, object o2)
        {

            Event e1 = o1 as Event;
            Event e2 = o2 as Event;

            if (e1 != null && e2 != null)
                return DateTime.Compare(e1.StartDate, e2.StartDate);
            else
                throw new ArgumentException("Comparable object is not a calendar Event!");
        }
    }
}
