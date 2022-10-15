using Moq;
using Xunit;

namespace Srp.Test
{
    public class AccountServiceShould
    {
        private const int POSITIVE_AMOUNT = 100;
        private const int NEGATIVE_AMOUNT = -POSITIVE_AMOUNT;

        private static readonly DateTime Today = new DateTime(2017, 9, 6);

        private static readonly List<Transaction> Transactions = new List<Transaction> {
                new Transaction(new DateTime(2014, 4, 1), 1000),
                new Transaction(new DateTime(2014, 4, 2), -100),
                new Transaction(new DateTime(2014, 4, 10), 500)
        };

        private readonly AccountService accountService;

        public AccountServiceShould()
        {
            StatementPrinter statementPrinter = new StatementPrinter(consoleMock.Object);

            accountService = new AccountService(
                transactionRepositoryMock.Object,
                statementPrinter,
                clockMock.Object);
        }

        private Mock<Clock> clockMock = new Mock<Clock>();
        private Mock<ITransactionRepository> transactionRepositoryMock = new Mock<ITransactionRepository>();
        private Mock<Console> consoleMock = new Mock<Console>();

        private void SetupClock()
        {
            clockMock.Setup(cm => cm.Today()).Returns(Today);
        }

        [Fact]
        public void Deposit_Amount_Into_The_Account()
        {
            SetupClock();

            accountService.Deposit(POSITIVE_AMOUNT);

            transactionRepositoryMock.Verify(
                trm => trm.Add(
                    It.Is<Transaction>(t => t.Amount == POSITIVE_AMOUNT && t.Date == Today)));
        }

        [Fact]
        public void Withdraw_Amount_From_The_Account()
        {
            SetupClock();

            accountService.Withdraw(POSITIVE_AMOUNT);

            transactionRepositoryMock.Verify(
                trm => trm.Add(
                    It.Is<Transaction>(t => t.Amount == NEGATIVE_AMOUNT && t.Date == Today)));
        }

        [Fact]
        public void Print_Statement()
        {
            transactionRepositoryMock.Setup(trm => trm.All()).Returns(Transactions);

            var consoleOutput = new[] {
                "DATE | AMOUNT | BALANCE",
                "10/04/2014 | 500.00 | 1400.00",
                "02/04/2014 | -100.00 | 900.00",
                "01/04/2014 | 1000.00 | 1000.00" };

            int index = 0;
            consoleMock.Setup(cm => cm.PrintLine(It.IsAny<string>()))
                .Callback((string s) => Assert.Equal(consoleOutput[index++], s));

            accountService.PrintStatement();

            consoleMock.Verify(cm => cm.PrintLine(It.IsAny<string>()), Times.Exactly(4));
        }
    }
}