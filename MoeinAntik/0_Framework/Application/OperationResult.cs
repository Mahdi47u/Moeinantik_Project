namespace _0_Framework.Application
{
    public class OperationResult
    {
        public string Message { get; set; }
        public bool IsSucceded { get; set; }

        public OperationResult()
        {
            IsSucceded = false;
        }
        public OperationResult Succeded(string message = "عملیات با موفقیت انجام شد") 
        {   
            IsSucceded = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message) 
        {
            IsSucceded = false;
            Message = message;
            return this;
        }
    }
}
