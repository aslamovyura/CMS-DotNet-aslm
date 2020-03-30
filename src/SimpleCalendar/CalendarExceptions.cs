using System;
namespace SimpleCalendar
{

    public class NegativeEventLengthException : ApplicationException
    {
        private string messageDetails = "Negative length of event is not possible!";
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public NegativeEventLengthException() { }
        public NegativeEventLengthException(string message,
                                            string cause,
                                            DateTime time)
        {
            messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
        public override string Message => $"Calendar usage error : {messageDetails}";
    }

    public class ZeroEventLengthException : ApplicationException
    {
        private string messageDetails = "The length of event should not be equal to zero!";
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public ZeroEventLengthException() { }
        public ZeroEventLengthException(string message,
                                        string cause,
                                        DateTime time)
        {
            messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        public override string Message => $"Calendar usage error : {messageDetails}";
    }

    public class OutOfDateEventException : ApplicationException
    {
        private string messageDetails = "Event cannot be scheduled in the past!";
        public string CauseOfError { get; set; }

        public OutOfDateEventException() { }
        public OutOfDateEventException(string message,
                                       string cause)
        {
            messageDetails = message;
            CauseOfError = cause;
        }

        public override string Message => $"Calendar usage error : {messageDetails}";
    }

}
