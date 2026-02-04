// Import các thư viện cần thiết
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Common.Helpers;
using WebBanHang.Common.Response;

// Namespace chứa các extension dùng chung cho Controller
namespace WebBanHang.Common.Extensions;

// Khai báo class static để chứa các extension method
public static class ControllerAutoResponseExtensions
{
    // Extension method AutoResponse
    // "this ControllerBase controller" giúp method này
    // có thể gọi trực tiếp trong Controller (controller.AutoResponse(...))
    public static IActionResult AutoResponse<T>(
        this ControllerBase controller,
        T? data = default) // data có thể null, mặc định là null
    {
        // Lấy HTTP Method hiện tại (GET, POST, PUT, DELETE, ...)
        var httpMethod = controller.HttpContext.Request.Method;

        // Xác định Status Code dựa vào HTTP Method
        int statusCode = httpMethod switch
        {
            // POST thường dùng để tạo mới → 201 Created
            "POST" => StatusCodes.Status201Created,

            // PUT / PATCH dùng để cập nhật → 200 OK
            "PUT" or "PATCH" => StatusCodes.Status200OK,

            // DELETE thành công → 204 No Content
            "DELETE" => StatusCodes.Status204NoContent,

            // Mặc định (GET, v.v.) → 200 OK
            _ => StatusCodes.Status200OK
        };

        // Nếu là 204 No Content thì không trả body
        if (statusCode == StatusCodes.Status204NoContent)
            return controller.NoContent();

        // Tạo response chuẩn theo cấu trúc ApiResponse<T>
        var response = new ApiResponse<T>
        {
            // Gán mã status
            StatusCode = statusCode,

            // Lấy message tương ứng với HTTP Method
            // Ví dụ: GET -> "Lấy dữ liệu thành công"
            Message = ResponseMessageMapper.Map(httpMethod),

            // Dữ liệu trả về cho client
            Data = data
        };

        // Trả về response với StatusCode tương ứng
        return controller.StatusCode(statusCode, response);
    }
}
