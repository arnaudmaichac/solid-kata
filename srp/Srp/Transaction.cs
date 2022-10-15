namespace Srp
{
    public class Transaction
    {
        public DateTime Date { get; private set; }
        public int Amount { get; private set; }

        public Transaction(DateTime date, int amount)
        {
            this.Date = date;
            this.Amount = amount;
        }
    }
}