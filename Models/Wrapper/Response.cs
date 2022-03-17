namespace DotNet5.Models.Wrapper
{
    public class Response <T>
    {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
         public T Data { get; set; }

        public Response(){}

        public Response(T data)
        {
            Succeeded = true;
            Errors = null;
            Message = string.Empty;
            Data = data;
        }
    }
}