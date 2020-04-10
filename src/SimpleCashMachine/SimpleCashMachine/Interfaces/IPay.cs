using System;
namespace SimpleCashMachine.Interfaces
{
    public interface IPay
    {
        public void PutMoney(decimal sum);

        public void TakeMoney(decimal sum);

        public bool IsEmpty();
    }
}
