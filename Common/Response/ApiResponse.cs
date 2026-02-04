namespace WebBanHang.Common.Response
{
    // Lớp wrapper dùng để chuẩn hóa response trả về từ API
    // T: kiểu dữ liệu trả về (Customer, List<Order>, object, ...)
    public class ApiResponse<T>
    {
        // HTTP Status Code (200, 201, 400, 500, ...)
        public int StatusCode { get; set; }

        // Thông báo cho client
        // Mặc định là "Success" nếu không gán giá trị khác
        public string Message { get; set; } = "Success";

        // Dữ liệu trả về cho client
        // Có thể là object, list, hoặc null
        public T? Data { get; set; }

        // Factory method tạo response thành công
        // Dùng khi muốn trả kết quả thành công kèm dữ liệu
        public static ApiResponse<T> Success(T data)
            => new()
            {
                // Gán dữ liệu trả về
                Data = data
            };

        // Factory method tạo response thất bại
        // Thường dùng khi xử lý lỗi thủ công
        public static ApiResponse<T> Fail()
            => new()
            {
                // Ghi đè message mặc định thành "Error"
                Message = "Error",

                // Không có dữ liệu trả về
                Data = default
            };
    }
}
