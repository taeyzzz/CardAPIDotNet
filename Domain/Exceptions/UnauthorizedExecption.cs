namespace Domain.Exceptions
{
    public class UnauthorizedExecption : ResponseBaseException
    {
        private const string ErrorName = "UnauthorizedExecption";
        private new const string Message = "Unauthorized";
        
        public UnauthorizedExecption() : base(ErrorName, Message) { }
        
        public UnauthorizedExecption(string name, string message) : base(name, message)
        {
            
        }
    }
}