using System;

namespace Events
{
    class Program
    {
        delegate void Receive(string recepient, string message);
        static event Receive Subscribe;

        private static void MMSSubscriber(string recepient, string message)
        {
            Console.WriteLine($"Sending MMS to -> {recepient}, message -> {message}");
        }

        private static void GmailSubscriber(string recepient, string message)
        {
            Console.WriteLine($"Sending email to -> {recepient}, message -> {message}");
        }

        static void Main(string[] args)
        {
            Subscribe += MMSSubscriber;
            Subscribe += GmailSubscriber;

            //Subscribe.Invoke("samin", "apurba");

            Subscribe -= MMSSubscriber;
            Subscribe.Invoke("samin", "apurba");
        }
    }
}
