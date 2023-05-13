namespace FsCodeBusiness.Results
{
    public class ServiceResult
    {
        public object Data { get; }
        public string Message { get; }
        public bool Success { get; }

        public ServiceResult(bool success, object data, string message)
        {
            Data = data;
            Success = success;
            Message = message;

        }

        public ServiceResult(bool success, string message)
        {
            Data = null;
            Success = success;
            Message = message;
        }

        public ServiceResult(bool success, object data)
        {
            Data = data;
            Success = success;
            Message = "";
        }

        public ServiceResult(bool success)
        {
            Data = null;
            Success = success;
            Message = "";
        }
    }
}
