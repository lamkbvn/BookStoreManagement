// Thư viện FluentValidation để bắt ValidationException
using FluentValidation;

// Dùng để serialize object -> JSON trả về client
using System.Text.Json;

// Custom exception của project (lỗi nghiệp vụ)
using WebBanHang.Common.Exceptions;

// Wrapper response chung của API
using WebBanHang.Common.Response;

// Middleware dùng để bắt và xử lý exception toàn cục
public class ExceptionMiddleware
{
    // Delegate đại diện cho middleware tiếp theo trong pipeline
    private readonly RequestDelegate _next;

    // Constructor: ASP.NET Core sẽ inject middleware kế tiếp
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    // Hàm chính của middleware – sẽ được gọi cho mỗi HTTP request
    public async Task Invoke(HttpContext context)
    {
        try
        {
            // Cho request chạy tiếp xuống các middleware / controller / handler
            await _next(context);
        }
        // Bắt lỗi validation (FluentValidation)
        catch (ValidationException ex)
        {
            // Xử lý lỗi validate và trả response chuẩn
            await HandleValidationException(context, ex);
        }
        // Bắt lỗi nghiệp vụ do developer chủ động throw
        catch (AppException ex)
        {
            // Xử lý lỗi nghiệp vụ theo status code mong muốn
            await HandleAppException(context, ex);
        }
        // Bắt tất cả lỗi còn lại (null reference, bug, lỗi hệ thống...)
        catch (Exception)
        {
            // Trả lỗi 500 – internal server error
            await HandleUnknownException(context);
        }
    }

    // Xử lý ValidationException (DTO không hợp lệ)
    private static async Task HandleValidationException(
        HttpContext context,
        ValidationException ex)
    {
        // Set HTTP status code = 400 Bad Request
        context.Response.StatusCode = StatusCodes.Status400BadRequest;

        // Trả dữ liệu dạng JSON
        context.Response.ContentType = "application/json";

        // Gom lỗi theo từng field
        // Ví dụ:
        // {
        //   "Email": ["Email không hợp lệ"],
        //   "Password": ["Password tối thiểu 6 ký tự"]
        // }
        var errors = ex.Errors
            .GroupBy(x => x.PropertyName)          // Gom theo tên property
            .ToDictionary(
                g => g.Key,                        // Key = tên field
                g => g.Select(x => x.ErrorMessage) // Value = danh sách lỗi
                      .ToArray()
            );

        // Tạo response chuẩn
        var response = new ApiResponse<object>
        {
            StatusCode = StatusCodes.Status400BadRequest,
            Message = "Validation failed",
            Data = errors
        };

        // Ghi JSON response ra HTTP response body
        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response)
        );
    }

    // Xử lý AppException (lỗi nghiệp vụ do dev tự định nghĩa)
    private static async Task HandleAppException(
        HttpContext context,
        AppException ex)
    {
        // Status code lấy trực tiếp từ AppException
        context.Response.StatusCode = ex.StatusCode;

        // Trả dữ liệu dạng JSON
        context.Response.ContentType = "application/json";

        // Tạo response chuẩn
        var response = new ApiResponse<object>
        {
            StatusCode = ex.StatusCode,
            Message = ex.Message, // Message nghiệp vụ (VD: "Email đã tồn tại")
            Data = null
        };

        // Ghi response ra client
        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response)
        );
    }

    // Xử lý lỗi không xác định (bug, crash)
    private static async Task HandleUnknownException(HttpContext context)
    {
        // HTTP 500 – lỗi hệ thống
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        // Trả dữ liệu dạng JSON
        context.Response.ContentType = "application/json";

        // Không trả chi tiết lỗi để tránh lộ thông tin hệ thống
        var response = new ApiResponse<object>
        {
            StatusCode = StatusCodes.Status500InternalServerError,
            Message = "Internal server error",
            Data = null
        };

        // Ghi response ra client
        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response)
        );
    }
}
