using System;

namespace Behavioural.Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringSubject = new Subject<string>("Bengaluru");

            stringSubject.Register(m => Console.WriteLine($"Observer 1: {m}")); 
            stringSubject.Register(m => Console.WriteLine($"Observer 2: {m}"));
            stringSubject.Register(m => Console.WriteLine($"Observer 3: {m}"));

            stringSubject.Value = "Mumbai";
        }
    }
}
