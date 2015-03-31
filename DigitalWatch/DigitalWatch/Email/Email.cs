namespace DigitalWatch.Email
{
    /// <summary>
    ///Email class. Once set only get is permitted.
    /// </summary>
    public sealed class Email
    {
        /// <summary>
        /// Gets the emails message text
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Gets the emails subject
        /// </summary>
        public string Subject { get; private set; }

        /// <summary>
        /// Gets the senders email address
        /// </summary>
        public string FromContact { get; private set; }

        /// <summary>
        /// Gets the recipients email address
        /// </summary>
        public string ToContact { get; private set; }

        /// <summary>
        /// Constructor for Email objects
        /// </summary>
        /// <param name="message">The emails message text.</param>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="fromContact">The email address of the sender</param>
        /// <param name="toContact">The email address of the recipient</param>
        public Email(string message, string subject, string fromContact, string toContact)
        {
            Message = message;
            Subject = subject;
            FromContact = fromContact;
            ToContact = toContact;
        }
    }
}
