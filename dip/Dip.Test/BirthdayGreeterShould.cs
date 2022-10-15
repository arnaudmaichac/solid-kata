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

        public BirthdayGreeterShould()
        {
            consoleContent = new StringWriter();
            Console.SetOut(consoleContent);

            employeeRepositoryMock = new Mock<IEmployeeRepository>();
            clockMock = new Mock<Clock>();
        }

        [Fact]
        public void Should_Send_Greeting_Email_To_Employee()
        {
            clockMock
                .Setup(cm => cm.MonthDay())
                .Returns(TODAY);

            Employee employee = EmployeeBuilder
                .AnEmployee()
                .Build();

            employeeRepositoryMock
                .Setup(erm => erm.FindEmployeesBornOn(new DateTime(DateTime.Today.Year, CURRENT_MONTH, CURRENT_DAY_OF_MONTH)))
                .Returns(new List<Employee>() { employee });

            BirthdayGreeter birthdayGreeter = new BirthdayGreeter(employeeRepositoryMock.Object, clockMock.Object);
            birthdayGreeter.SendGreetings();

            string actual = consoleContent.ToString();
            Assert.Equal($"To:{employee.Email}, Subject: Happy birthday!, Message: Happy birthday, dear {employee.FirstName}!", actual);
        }
    }
}