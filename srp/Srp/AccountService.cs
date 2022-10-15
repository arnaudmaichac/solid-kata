using System.Globalization;

namespace Srp
{
    public class AccountService
    {
        private const string STATEMENT_HEADER = "DATE | AMOUNT | BALANCE";
        private const string DATE_FORMAT = "dd/MM/yyyy";
        private const string AMOUNT_FORMAT = "#.00";

        private readonly ITransactionRepository transactionRepository;
        private readonly Clock clock;
        private readonly Console console;

        public AccountService(ITransactionRepository transactionRepository, Clock clock, Console console)
        {
            this.transactionRepository = transactionRepository;
            this.clock = clock;
            this.console = console;
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
            PrintHeader();
            PrintTransactions();
        }


        private void PrintHeader()
        {
            PrintLine(STATEMENT_HEADER);
        }

        private void PrintTransactions()
        {
            List<Transaction> transactions = transactionRepository.All();

            int balance = 0;

            transactions
                .Select(t =>
                {
                    return StatementLine(t, Interlocked.Add(ref balance, t.Amount));
                })
                .Reverse()
                .ToList()
                .ForEach(PrintLine);
        }

        private Transaction TransactionWith(int amount)
        {
            return new Transaction(clock.Today(), amount);
        }

        private string StatementLine(Transaction transaction, int balance)
        {
            return string.Format("{0} | {1} | {2}", FormatDate(transaction.Date), FormatNumber(transaction.Amount), FormatNumber(balance));
        }

        private string FormatDate(DateTime date)
        {
            return date.ToString(DATE_FORMAT);
        }

        private string FormatNumber(int amount)
        {
            return Convert.ToDecimal(amount).ToString(AMOUNT_FORMAT, new CultureInfo("en-GB"));
        }

        private void PrintLine(string line)
        {
            console.PrintLine(line);
        }
    }
}