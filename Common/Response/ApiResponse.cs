namespace WebBanHang.Common.Response
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = "Success";
        public T? Data { get; set; }

        public static ApiResponse<T> Success(T data)
            => new()
            {
                Data = data
            };

        public static ApiResponse<T> Fail()
            => new()
            {
                Message = "Error",
                Data = default
            };
    }
}
