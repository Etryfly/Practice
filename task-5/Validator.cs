using System;
using System.Collections.Generic;

namespace task_5
{
    public class Validator<T>
    {
        private List<Predicate<T>> _predicates;

        private Validator(List<Predicate<T>> list)
        {
            _predicates = list;
        }
        
        private Validator()
        {
        }

        public bool Fit(T obj)
        {
            foreach (var predicate in _predicates)
            {
                if (!predicate(obj))
                {
                    throw new FalsePredicateException(obj + " " + predicate);
                }
            }

            return true;

        }

        public static ValidatorBuilder<T> CreateValidator()
        {
            return new ValidatorBuilder<T>();
        }
        
        
        public class ValidatorBuilder<T>
        {
            private List<Predicate<T>> _predicate = new List<Predicate<T>>();
            private int _count;

            public void Add(Predicate<T> predicate)
            {
                _count++;
                _predicate.Add(predicate);
            }

            public Validator<T> Get() 
            {
                if (_count == 0)
                {
                    throw new ZeroPredicateException();
                }
                return new Validator<T>(_predicate);
            }

            public void Clear()
            {
                _count = 0;
                _predicate.Clear();
            }
        }
    }
}