namespace DigitalWatch.Email
{
    public sealed class Email
    {
        public string Message { get; private set; }
        public string Subject { get; private set; }
        public string FromContact { get; private set; }
        public string ToContact { get; private set; }


        public Email(string message, string subject, string fromContact, string toContact)
        {
            Message = message;
            Subject = subject;
            FromContact = fromContact;
            ToContact = toContact;
        }
    }
}
