using Moq;

namespace Dip.Test
{
    public class BirthdayGreeterShould
    {
        private const int CURRENT_MONTH = 7;
        private const int CURRENT_DAY_OF_MONTH = 9;

        private static readonly DateTime TODAY = new DateTime(DateTime.Today.Year, CURRENT_MONTH, CURRENT_DAY_OF_MONTH);

        private readonly StringWriter consoleContent;
        private readonly Mock<IEmployeeRepository> employeeRepositoryMock;
        private readonly Mock<Clock> clockMock;
        private readonly Mock<EmailSender> emailSenderMock;

        public BirthdayGreeterShould()
        {
            consoleContent = new StringWriter();
            Console.SetOut(consoleContent);

            employeeRepositoryMock = new Mock<IEmployeeRepository>();
            clockMock = new Mock<Clock>();
            emailSenderMock = new Mock<EmailSender>();
        }

        [Fact]
        public void Should_Send_Greeting_Email_To_Employee()
        {
            clockMock
                .Setup(cm => cm.MonthDay())
                .Returns(TODAY);

            Employee employee = new EmployeeBuilder()
                .Build();

            employeeRepositoryMock
                .Setup(erm => erm.FindEmployeesBornOn(new DateTime(DateTime.Today.Year, CURRENT_MONTH, CURRENT_DAY_OF_MONTH)))
                .Returns(new List<Employee>() { employee });

            var args = new List<Email>();
            emailSenderMock.Setup(esm => esm.Send(Capture.In(args)));

            BirthdayGreeter birthdayGreeter = new BirthdayGreeter(employeeRepositoryMock.Object, clockMock.Object, emailSenderMock.Object);
            birthdayGreeter.SendGreetings();

            var sentEmail = args.First();

            Assert.Equal(sentEmail.To, employee.Email);
            Assert.Equal("Happy birthday!", sentEmail.Subject);
            Assert.Equal("Happy birthday, dear John!", sentEmail.Message);
        }
    }
}