using System;

namespace SendingMailInConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var ms = new EmailSender();
            ms.SendEmailAsync("michal.stehlik@pslib.cz","Testovací Mail","Tak jak se to povedlo?");
        }
    }
}
