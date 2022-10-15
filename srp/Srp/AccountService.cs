namespace Srp
{
    public class AccountService
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly StatementPrinter statementPrinter;
        private readonly Clock clock;

        public AccountService(ITransactionRepository transactionRepository, StatementPrinter statementPrinter, Clock clock)
        {
            this.transactionRepository = transactionRepository;
            this.statementPrinter = statementPrinter;
            this.clock = clock;
        }

        public void Deposit(int amount)
        {
            transactionRepository.Add(TransactionWith(amount));
        }

        public void Withdraw(int amount)
        {
            transactionRepository.Add(TransactionWith(-amount));
        }

        public void PrintStatement()
        {
            statementPrinter.Print(transactionRepository.All());
        }

        private Transaction TransactionWith(int amount)
        {
            return new Transaction(clock.Today(), amount);
        }
    }
}