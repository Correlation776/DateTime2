using System;

namespace DateTime2
{
    public class InvalidDateException : Exception
    {
        public InvalidDateException() : base(){}
        public InvalidDateException(string message) : base(message) { }
        public InvalidDateException(string message, Exception inner) : base(message, inner) { }
    }
}