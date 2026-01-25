using FluentValidation;
using System.Text.Json;
using WebBanHang.Common.Exceptions;
using WebBanHang.Common.Response;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            await HandleValidationException(context, ex);
        }
        catch (AppException ex)
        {
            await HandleAppException(context, ex);
        }
        catch (Exception)
        {
            await HandleUnknownException(context);
        }
    }

    private static async Task HandleValidationException(
        HttpContext context,
        ValidationException ex)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Response.ContentType = "application/json";

        var errors = ex.Errors
            .GroupBy(x => x.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.ErrorMessage).ToArray()
            );

        var response = new ApiResponse<object>
        {
            StatusCode = StatusCodes.Status400BadRequest,
            Message = "Validation failed",
            Data = errors
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static async Task HandleAppException(
        HttpContext context,
        AppException ex)
    {
        context.Response.StatusCode = ex.StatusCode;
        context.Response.ContentType = "application/json";

        var response = new ApiResponse<object>
        {
            StatusCode = ex.StatusCode,
            Message = ex.Message,
            Data = null
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static async Task HandleUnknownException(HttpContext context)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        var response = new ApiResponse<object>
        {
            StatusCode = StatusCodes.Status500InternalServerError,
            Message = "Internal server error",
            Data = null
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
