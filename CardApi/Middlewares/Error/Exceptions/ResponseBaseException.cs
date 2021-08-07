using System;
namespace CardApi.Middlewares.Error.Exceptions
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
