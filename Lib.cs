using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioural.Observer
{
    public class Subject<T>
    {
        private readonly IList<Action<T>> _observers;
        private T element;


        public Subject(T defaultValue)
        {
            _observers = new List<Action<T>>();
            element = defaultValue;
        }

        public void Register(Action<T> observer)
        {
            this._observers.Add(observer);
        }

        public void Emit(T value)
        {
            foreach (var observer in _observers)
            {
                observer(value);
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
                Emit(element);
            }
        }
    }    
}
