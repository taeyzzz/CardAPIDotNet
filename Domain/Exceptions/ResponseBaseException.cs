using System;
namespace Domain.Exceptions
{
    public abstract class ResponseBaseException : Exception
    {
        public readonly string Name;
        public ResponseBaseException(string name, string message) : base(message)
        {
            Name = name;
        }
    }
}
