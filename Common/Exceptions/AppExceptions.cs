// Khai báo namespace để nhóm các class liên quan đến Exception dùng chung
namespace WebBanHang.Common.Exceptions
{
    // Khai báo class AppException
    // Kế thừa từ class Exception mặc định của .NET
    public class AppException : Exception
    {
        // Thuộc tính StatusCode (chỉ đọc)
        // Dùng để lưu mã HTTP (ví dụ: 400, 401, 404, 500...)
        public int StatusCode { get; }

        // Constructor của AppException
        // message: thông báo lỗi
        // statusCode: mã HTTP tương ứng với lỗi
        public AppException(string message, int statusCode)
            : base(message) // Gọi constructor của lớp cha (Exception) và truyền message
        {
            // Gán giá trị statusCode cho thuộc tính StatusCode
            StatusCode = statusCode;
        }
    }
}
