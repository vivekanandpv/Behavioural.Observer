using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioural.Observer
{
    public abstract class Subject<T>
    {
        private readonly IList<Observer<T>> _observers;
        private T element;


        protected Subject(T defaultValue)
        {
            _observers = new List<Observer<T>>();
            element = defaultValue;
        }

        public void Register(Observer<T> observer)
        {
            this._observers.Add(observer);
        }

        public void Emit()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }

        public T Value
        {
            get
            {
                return element;
            }
            set
            {
                element = value;
                Emit();
            }
        }
    }

    public abstract class Observer<T>
    {
        protected readonly Subject<T> _subject;

        protected Observer(Subject<T> subject)
        {
            _subject = subject;
            this._subject.Register(this);
        }

        public void Update()
        {
            Console.WriteLine($"{this}: Value: {this._subject.Value}");
        }

        public void Transmit(T newValue)
        {
            this._subject.Value = newValue;
        }
    }

    public class ConcreteSubject<T> : Subject<T>
    {
        public ConcreteSubject(T defaultValue) : base(defaultValue)
        {
        }
    }

    public class SmartphoneObserver<T> : Observer<T>
    {
        public SmartphoneObserver(Subject<T> subject): base(subject)
        {
        }
    }

    public class EmailObserver<T> : Observer<T>
    {
        public EmailObserver(Subject<T> subject) : base(subject)
        {
        }
    }
}
