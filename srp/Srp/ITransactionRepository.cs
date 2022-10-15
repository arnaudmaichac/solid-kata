namespace Srp
{
    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
        List<Transaction> All();
    }
}