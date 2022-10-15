namespace Dip
{
    public class BirthdayGreeter
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly Clock clock;

        public BirthdayGreeter(IEmployeeRepository employeeRepository, Clock clock)
        {
            this.employeeRepository = employeeRepository;
            this.clock = clock;
        }

        public void SendGreetings()
        {
            DateTime today = clock.MonthDay();

            employeeRepository.FindEmployeesBornOn(today)
                .Select(EmailFor)
                .ToList()
                .ForEach(e => new EmailSender().Send(e));
        }

        private Email EmailFor(Employee employee)
        {
            string message = $"Happy birthday, dear {employee.FirstName}!";
            return new Email(employee.Email, "Happy birthday!", message);
        }
    }
}