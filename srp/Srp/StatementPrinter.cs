using System.Globalization;

namespace Srp
{
    public class StatementPrinter
    {
        private const string STATEMENT_HEADER = "DATE | AMOUNT | BALANCE";
        private const string DATE_FORMAT = "dd/MM/yyyy";
        private const string AMOUNT_FORMAT = "#.00";

        private readonly Console console;

        public StatementPrinter(Console console)
        {
            this.console = console;
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

        private void PrintHeader()
        {
            PrintLine(STATEMENT_HEADER);
        }

        private void PrintLine(string line)
        {
            console.PrintLine(line);
        }

        public void Print(List<Transaction> transactions)
        {
            PrintHeader();

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
    }
}