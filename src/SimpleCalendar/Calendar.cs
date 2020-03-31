using System;
using System.Collections;
using System.Globalization;

namespace SimpleCalendar
{
    public class Calendar
    {

        private string[] DateFormats = {"dd-MM-yyyy hh:mm:ss",
                                        "dd-MM-yyyy hh:mm",
                                        "dd-MM-yyyy hh",
                                        "dd-MM-yyyy"};

        ArrayList EventsList { get; set; } = new ArrayList();
        private static Calendar _instance;

        public Calendar() { }

        public static Calendar GetInstance()
        {
            if (_instance == null)
                _instance = new Calendar();

            return _instance;
        }


        public void AddEventAction()
        {
            Console.WriteLine("\n---------------- Add New Event ---------------");
            Console.WriteLine("Please, enter the following event information:");

            // Parse main parameters of the event
            DateTime startDate = ParseEventDate();
            int lengthInHours = ParseEventLength();
            string descrtiption = ParseEventDescription();
            Priority priority = ParseEventPriority();
            int eventID = EventsList.Count + 1;

            // Create new event and add it to the list
            Event myEvent = new Event(startDate, lengthInHours, descrtiption, priority, eventID);
            AddEvent(myEvent);
        }

        public void AddEvent(Event newEvent)
        {
            EventsList.Add(newEvent);
            Console.WriteLine("\nNew event is successufully added to the calendar!\n");

            SortEventsByDate();
        }
        public void AddEvent(DateTime startDate, int lengthInHours, string descrtiption, Priority priority, int eventID)
        {
            Event newEvent = new Event(startDate, lengthInHours, descrtiption, priority, eventID);
            EventsList.Add(newEvent);

            Console.WriteLine("\nNew event is successufully added to the calendar!\n");
            SortEventsByDate();
        }
        public void AddEvent(DateTime startDate, int lengthInHours, string descrtiption, Priority priority)
        {
            int eventID = EventsList.Count + 1;
            Event newEvent = new Event(startDate, lengthInHours, descrtiption, priority, eventID);
            EventsList.Add(newEvent);

            Console.WriteLine("\nNew event is successufully added to the calendar!\n");
            SortEventsByDate();
        }
        

        public void RemoveEventAction()
        {
            if (EventsList.Count == 0)
            {     Console.WriteLine("Events list is empty!");
                return;
            }

            Console.WriteLine("Please, type `ID` or `Date` of the event you want to remove");
            bool formatDetected = false;

            while (!formatDetected)
            {
                string userInput = Console.ReadLine().Trim();

                // Try to detect eventID as integer
                try
                {
                    int eventId = Int32.Parse(userInput);
                    Console.WriteLine("Event `ID` is detected!\n");
                    RemoveEvent(eventId);
                    formatDetected = true;
                }
                catch { }

                // Try to detect event startDate as DateTime
                if (!formatDetected)
                {
                    try
                    {
                        DateTime eventDate = DateTime.ParseExact(userInput,
                                                                 DateFormats,
                                                                 CultureInfo.InvariantCulture,
                                                                 DateTimeStyles.None);
                        Console.WriteLine("Event `Date` is detected!\n");
                        RemoveEvent(eventDate);
                        formatDetected = true;
                    }
                    catch
                    {
                        Console.WriteLine("Unknown data format! Please type event ID or Date\n");
                    }

                }
            }
        }

        // Remove event from the list by the ID
        public void RemoveEvent(int eventID)
        {
            foreach (Event ev in EventsList)
            {
                if (ev.ID == eventID)
                {
                    EventsList.Remove(ev);
                    break;
                } 
            }
        }

        // Remove event from the list by the Date
        public void RemoveEvent(DateTime eventDate)
        {
            foreach (Event ev in EventsList)
            {
                if (ev.StartDate.Equals(eventDate))
                {
                    EventsList.Remove(ev);
                    break;
                }
            }
        }

        public void RemoveAllEvents()
        {
            Console.WriteLine("Do you want to remove all events in your calendar? (y/n)");
            string userInput = Console.ReadLine().Trim();

            switch (userInput)
            {
                case "y":
                    EventsList.Clear();
                    Console.WriteLine("\nYour calendar is empty now!\n");
                    break;
                default:
                    break;
            } 

        }

        protected DateTime ParseEventDate()
        {
            bool success = false;
            DateTime date = default(DateTime);

            while (!success)
            {
                try
                {
                    Console.Write("date & time [dd-mm-yyyy hh:mm:ss] : ");
                    date = DateTime.ParseExact( Console.ReadLine().Trim(),
                                                this.DateFormats,
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
                    lengthInHours = int.Parse(Console.ReadLine().Trim());

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
            }
            return lengthInHours;
        }
        protected string ParseEventDescription()
        {

            Console.Write("description :  ");
            string descrtiption = Console.ReadLine().Trim();

            return descrtiption;
        }
        protected Priority ParseEventPriority()
        {
            bool success = false;
            Priority priority = default(Priority);
            while (!success)
            {
                try
                {
                    Console.Write("priority : ");
                    priority = (Priority) Enum.Parse(typeof(Priority),
                                                  Console.ReadLine().Trim());

                    if (Enum.IsDefined(typeof(Priority), priority))
                        success = true;
                    else
                        throw new ArgumentException();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine($"Argument error : {e.Message}");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Argument error : {e.Message}");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine($"Overflow exception : {e.Message}");
                }
            }
            return priority;
        }
        protected int ParseEventId()
        {
            bool success = false;
            int eventID = default(int);

            while (!success)
            {
                try
                {
                    Console.Write("event ID : ");
                    eventID = int.Parse(Console.ReadLine().Trim());

                    if (eventID < 0)
                        throw new NegativeEventLengthException();
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
                catch (NegativeEventIdException e3)
                {
                    Console.WriteLine(e3.Message);
                    Console.WriteLine(e3.CauseOfError);
                }
            }
            return eventID;
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
