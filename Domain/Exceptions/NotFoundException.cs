using System;
namespace Domain.Exceptions
{
    public class NotFoundException : ResponseBaseException
    {
        private const string ErrorName = "NotFoundException";
        private new const string Message = "Target resouce not found.";

        public NotFoundException() : base(ErrorName, Message) { }

        public NotFoundException(string message) : base(ErrorName, message) { }
    }
}
