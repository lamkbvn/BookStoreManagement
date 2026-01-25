using Microsoft.AspNetCore.Mvc;
using WebBanHang.Common.Helpers;
using WebBanHang.Common.Response;

namespace WebBanHang.Common.Extensions;

public static class ControllerAutoResponseExtensions
{
    public static IActionResult AutoResponse<T>(
        this ControllerBase controller,
        T? data = default)
    {
        var httpMethod = controller.HttpContext.Request.Method;

        int statusCode = httpMethod switch
        {
            "POST" => StatusCodes.Status201Created,
            "PUT" or "PATCH" => StatusCodes.Status200OK,
            "DELETE" => StatusCodes.Status204NoContent,
            _ => StatusCodes.Status200OK
        };

        if (statusCode == StatusCodes.Status204NoContent)
            return controller.NoContent();

        var response = new ApiResponse<T>
        {
            StatusCode = statusCode,
            Message = ResponseMessageMapper.Map(httpMethod),
            Data = data
        };

        return controller.StatusCode(statusCode, response);
    }
}
