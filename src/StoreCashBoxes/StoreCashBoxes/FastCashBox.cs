using System.Threading;
namespace StoreCashBoxes
{
    /// <summary>
    /// Fast store cash box.
    /// </summary>
    public class FastCashBox : CashBox
    {
        // Time (ms) to service 1 unit of customer goods.
        protected new int _serviceTimePerUnit = 500;

        /// <summary>
        /// Default constructor of FastCashBox.
        /// </summary>
        public FastCashBox() : base() { }

        /// <summary>
        /// Open cash box to manage customers.
        /// </summary>
        protected override void StartService()
        {
            base.StartService();
            _thread.Priority = ThreadPriority.Highest;
        }
    }
}