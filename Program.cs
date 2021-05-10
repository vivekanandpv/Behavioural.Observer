using System;

namespace Behavioural.Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject<string> stringSubject = new ConcreteSubject<string>("Bengaluru");

            Observer<string> smartphone = new SmartphoneObserver<string>(stringSubject);
            Observer<string> email = new EmailObserver<string>(stringSubject);

            stringSubject.Emit();

            Console.WriteLine("------------------------");

            smartphone.Transmit("Mumbai");
        }
    }
}
