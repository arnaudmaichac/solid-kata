namespace Dip
{
    public class EmailSender
    {
        public virtual void Send(Email email)
        {
            Console.Write($"To:{email.To}, Subject: {email.Subject}, Message: {email.Message}");
        }
    }
}