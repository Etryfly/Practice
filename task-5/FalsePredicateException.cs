using System;

namespace task_5
{
    public class FalsePredicateException : Exception
    {
        public FalsePredicateException()
        {
        }

        public FalsePredicateException(string message) : base(message)
        {
        }

        public FalsePredicateException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}