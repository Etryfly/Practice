using System;

namespace task_5
{
    public class ZeroPredicateException : Exception
    {
        public ZeroPredicateException()
        {
        }


        public ZeroPredicateException(string message) : base(message)
        {
        }

        public ZeroPredicateException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}