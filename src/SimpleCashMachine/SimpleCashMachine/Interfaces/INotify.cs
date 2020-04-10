namespace SimpleCashMachine.Interfaces
{
    public interface INotify
    {
        /// <summary>
        /// Notification message.
        /// </summary>
        public string Message{ get; set; }

        /// <summary>
        /// Send notification with sertain message.
        /// </summary>
        public void Send(string msg);

        /// <summary>
        /// Send default notification.
        /// </summary>
        public void Send();

        /// <summary>
        /// Action on send notification.
        /// </summary>
        public void OnSend() { }
    }
}