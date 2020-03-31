using System;
using System.Collections;
using System.Globalization;

namespace SimpleCalendar
{
    public class Calendar
    {
        ArrayList EventsList { get; set; } = new ArrayList();
        private static Calendar _instance;

        public Calendar() { }

        public static Calendar GetInstance()
        {
            if (_instance == null)
                _instance = new Calendar();

            return _instance;
        }

        // Function
        public void AddEvent(Event newEvent)
        {
            EventsList.Add(newEvent);
            Console.WriteLine("\nNew event is successufully added to the calendar!\n");

            SortEventsByDate();
        }

        public void AddEvent(DateTime startDate, int lengthInHours, String descrtiption, Priority priority)
        {
            Event newEvent = new Event(startDate, lengthInHours, descrtiption, priority);
            EventsList.Add(newEvent);
            Console.WriteLine("\nNew event is successufully added to the calendar!\n");

            SortEventsByDate();
        }

        public void AddEvent()
        {
            Console.WriteLine("\n---------------- Add New Event ---------------");
            Console.WriteLine("Please, enter the following event information:");

            // Parse main parameters of the event
            DateTime startDate = ParseEventDate();
            int lengthInHours = ParseEventLength();
            string descrtiption = ParseEventDescription();
            Priority priority = ParseEventPriority();

            // Create new event and add it to the list
            Event myEvent = new Event(startDate, lengthInHours, descrtiption, priority);
            AddEvent(myEvent);           
        }


        protected DateTime ParseEventDate()
        {
            bool success = false;

            // Available date formats
            string[] formats = {"dd-MM-yyyy hh:mm:ss",
                                "dd-MM-yyyy hh:mm",
                                "dd-MM-yyyy hh",
                                "dd-MM-yyyy"};               

            DateTime date = default(DateTime);

            while (!success)
            {
                try
                {
                    Console.Write("date & time [dd-mm-yyyy hh:mm:ss] : ");
                    date = DateTime.ParseExact(Console.ReadLine(),
                                                    formats,
                                                    CultureInfo.InvariantCulture,
                                                    DateTimeStyles.None);

                    if (date < DateTime.Today)
                        throw new OutOfDateEventException();

                    success = true;
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (OutOfDateEventException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            return date;
        }

        protected int ParseEventLength()
        {
            bool success = false;
            int lengthInHours = default(int);

            while (!success)
            {
                try
                {
                    Console.Write("length [in hours] : ");
                    lengthInHours = int.Parse(Console.ReadLine());

                    if (lengthInHours < 0)
                        throw new NegativeEventLengthException();

                    else if (lengthInHours == 0)
                        throw new ZeroEventLengthException();

                    success = true;
                }

                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e1)
                {
                    Console.WriteLine(e1.Message);
                }
                catch (OverflowException e2)
                {
                    Console.WriteLine(e2.Message);
                }
                catch (NegativeEventLengthException e3)
                {
                    Console.WriteLine(e3.Message);
                    Console.WriteLine(e3.CauseOfError);
                }
                catch (ZeroEventLengthException e4)
                {
                    Console.WriteLine(e4.Message);
                    Console.WriteLine(e4.CauseOfError);
                }
                //finally
                //{
                //    Console.WriteLine("Try again\n");
                //}    
            }
            return lengthInHours;
        }

        protected string ParseEventDescription()
        {

            Console.Write("description :  ");
            string descrtiption = Console.ReadLine();

            return descrtiption;
        }

        protected Priority ParseEventPriority()
        {
            bool success = false;
            Priority priority = default(Priority);
            while(!success)
            {
                try
                {
                    Console.Write("priority : ");
                    //Enum.TryParse(Console.ReadLine(), out priority);
                    priority = (Priority)Enum.Parse(typeof(Priority),Console.ReadLine());
                    //priority = System.Enum.TryParse(Console.ReadLine());
                    success = true;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Error message : {e.Message}");
                }
            }
            return priority;
        }

        public void PrintAll()
        {
            if (EventsList.Count == 0)
                Console.WriteLine("There are no events in your calendar");
            else
            {
                Console.WriteLine("\n*********** Calendar ***********");
                foreach (Event e in EventsList)
                    e.Print();
            }

        }

        public void PrintEventsForDate()
        {

            if (EventsList.Count == 0)
                Console.WriteLine("There is no events in your calendar!");

            // Get the date of events from user input
            DateTime date = ParseEventDate();

            ArrayList daylyEventsList = new ArrayList();
            foreach (Event e in EventsList)
                daylyEventsList.Add(e);


            if (daylyEventsList.Count == 0)
                Console.WriteLine("There is no events for the defined day!");
            else
            {
                Console.WriteLine("*********** Dayly Calendar ***********");
                foreach (Event e in EventsList)
                {
                    if (e.StartDate >= date && e.StartDate <= date.AddDays(1))
                        e.Print();
                }
            }
        }

        public void SortEventsByDate()
        {
            EventsList.Sort(Event.SortByStartDate);
        }

        public void SortEventsByPriority()
        {
            EventsList.Sort(Event.SortByPriority);
        }


    }
}
