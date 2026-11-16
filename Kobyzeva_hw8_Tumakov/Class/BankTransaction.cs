namespace Kobyzeva_hw8_Tumakov.Class
{
    internal class BankTransaction
    {
        public readonly DateTime Time;
        public readonly decimal Sum;
        public BankTransaction(decimal sum)
        {
            Time = DateTime.Now;
            Sum = sum;
        }
    }
}
