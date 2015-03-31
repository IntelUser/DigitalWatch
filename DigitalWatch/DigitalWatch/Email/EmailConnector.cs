using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;

namespace DigitalWatch.Email
{
    public static class EmailConnector
    {
        private static readonly EmailCollection _emailCollection = new EmailCollection();
        private static readonly String[] _subjectStrings = new[] {"Birthday","Party","Agenda","Lunch invitation","Pool party","Gaming","Work","Babes"};
        private static readonly String[] _messageStrings = new[] {"Hello John, here is my invitation you know where to go!", "Hello Tjeerd, Thanks for your email! I liked it very much!"};
        private static readonly String[] _contactStrings = new[] {"raymon@gmail.com", "wybren@hotmail.com", "gerjan@yahoo.com", "info@helloworld.com"};
        private const String MyEmail = "johannes@gmail.com";

        

        public static Iterator GetEmails()
        {
            return _emailCollection.CreateIterator();
        }

        public static void GenerateEmails(int intervalMs)
        {
            var timer = new Timer(intervalMs);

            timer.Elapsed += timer_Elapsed;
            timer.Enabled = true;
        }

        static void AddEmail(Email email)
        {
            _emailCollection[_emailCollection.Count + 1] = email;
        }

        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var message = _messageStrings[new Random().Next(0, _messageStrings.Length)];
            var subject = _subjectStrings[new Random().Next(0, _subjectStrings.Length)];
            var from = _contactStrings[new Random().Next(0, _contactStrings.Length)];

            AddEmail(new Email(message, subject, from, MyEmail));
        }
    }
}
