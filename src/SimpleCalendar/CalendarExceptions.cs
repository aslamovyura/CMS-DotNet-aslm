using System;
namespace SimpleCalendar
{

    public class CalendarException : ApplicationException
    {
        public string messageDetails { get; set; }
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CalendarException() { }
        public CalendarException(string message,
                                 string cause,
                                 DateTime time)
        {
            messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        public override string Message => $"Calendar usage error : {this.messageDetails}";
    }

    public class NegativeEventLengthException : CalendarException
    {
        //public string messageDetails { get; set; } = "Negative length of event is not possible!";

        public NegativeEventLengthException()
        {
            messageDetails = "Negative length of event is not possible!";
        }
        public NegativeEventLengthException(string message,
                                            string cause,
                                            DateTime time)
            : base(message, cause, time) { }
    }

    public class ZeroEventLengthException : CalendarException
    {
        //public string messageDetails { get; set; } = "The length of event should not be equal to zero!";

        public ZeroEventLengthException()
        {
            messageDetails = "The length of event should not be equal to zero!";
        }
        public ZeroEventLengthException( string message,
                                         string cause,
                                         DateTime time)
            : base(message, cause, time) { }
    }

    public class OutOfDateEventException : CalendarException
    {
        //public string messageDetails { get; set; } = "Event cannot be scheduled in the past!";

        public OutOfDateEventException()
        {
            messageDetails = "Event cannot be scheduled in the past!";
        }
        public OutOfDateEventException( string message,
                                        string cause,
                                        DateTime time)
            : base(message, cause, time) { }
    }

    public class NegativeEventIdException : NegativeEventLengthException
    {

        //public string messageDetails { get; set; } = "Negative event ID is not possible!";

        public NegativeEventIdException()
        {
            messageDetails = "Negative event ID is not possible!";
        }
        public NegativeEventIdException( string message,
                                         string cause,
                                         DateTime time)
            : base(message, cause, time) { }
    }

    //public class NegativeEventLengthException : ApplicationException
    //{
    //    protected string messageDetails = "Negative length of event is not possible!";
    //    protected DateTime ErrorTimeStamp { get; set; }
    //    protected string CauseOfError { get; set; }

    //    public NegativeEventLengthException() { }
    //    public NegativeEventLengthException(string message,
    //                                        string cause,
    //                                        DateTime time)
    //    {
    //        messageDetails = message;
    //        CauseOfError = cause;
    //        ErrorTimeStamp = time;
    //    }
    //    public override string Message => $"Calendar usage error : {messageDetails}";
    //}

    //public class ZeroEventLengthException : ApplicationException
    //{
    //    private string messageDetails = "The length of event should not be equal to zero!";
    //    public DateTime ErrorTimeStamp { get; set; }
    //    public string CauseOfError { get; set; }

    //    public ZeroEventLengthException() { }
    //    public ZeroEventLengthException(string message,
    //                                    string cause,
    //                                    DateTime time)
    //    {
    //        messageDetails = message;
    //        CauseOfError = cause;
    //        ErrorTimeStamp = time;
    //    }

    //    public override string Message => $"Calendar usage error : {messageDetails}";
    //}

    //public class OutOfDateEventException : ApplicationException
    //{
    //    private string messageDetails = "Event cannot be scheduled in the past!";
    //    public string CauseOfError { get; set; }

    //    public OutOfDateEventException() { }
    //    public OutOfDateEventException(string message,
    //                                   string cause)
    //    {
    //        messageDetails = message;
    //        CauseOfError = cause;
    //    }

    //    public override string Message => $"Calendar usage error : {messageDetails}";
    //}}
}