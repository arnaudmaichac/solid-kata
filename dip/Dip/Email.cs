namespace Dip
{
    public class Email
    {
        public string To { get; private set; }
        public string Subject { get; private set; }
        public string Message { get; private set; }

        public Email(string to, string subject, string message)
        {
            To = to;
            Subject = subject;
            Message = message;
        }
    }
}