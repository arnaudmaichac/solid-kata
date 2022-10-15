namespace Dip
{
    public class BirthdayGreeter
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly Clock clock;
        private readonly EmailSender emailSender;

        public BirthdayGreeter(IEmployeeRepository employeeRepository, Clock clock, EmailSender emailSender)
        {
            this.employeeRepository = employeeRepository;
            this.clock = clock;
            this.emailSender = emailSender;
        }

        public void SendGreetings()
        {
            DateTime today = clock.MonthDay();

            employeeRepository.FindEmployeesBornOn(today)
                .Select(EmailFor)
                .ToList()
                .ForEach(e => emailSender.Send(e));
        }

        private Email EmailFor(Employee employee)
        {
            string message = $"Happy birthday, dear {employee.FirstName}!";
            return new Email(employee.Email, "Happy birthday!", message);
        }
    }
}