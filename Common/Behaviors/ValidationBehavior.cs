using FluentValidation;          // Thư viện validate dữ liệu (rules)
using MediatR;                   // Thư viện MediatR (CQRS, pipeline)

namespace WebBanHang.Common.Behaviors
{
    // ValidationBehavior là 1 PipelineBehavior của MediatR
    // Nó sẽ chạy TRƯỚC handler của mọi Request (Command / Query)
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        // Ràng buộc: TRequest bắt buộc phải là MediatR request
        where TRequest : IRequest<TResponse>
    {
        // Danh sách tất cả validator ứng với TRequest
        // Ví dụ: CreateCustomerCommandValidator
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        // Constructor được DI container inject tất cả validator phù hợp
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        // Hàm Handle được MediatR gọi cho mỗi request
        public async Task<TResponse> Handle(
            TRequest request,                        // Command / Query được gửi từ Controller
            RequestHandlerDelegate<TResponse> next,  // Delegate gọi handler tiếp theo
            CancellationToken cancellationToken)
        {
            // Kiểm tra request này có validator nào không
            if (_validators.Any())
            {
                // Tạo ValidationContext từ request
                // FluentValidation cần context này để chạy rule
                var context = new ValidationContext<TRequest>(request);

                // Chạy tất cả validator ASYNC song song
                // Task.WhenAll giúp tăng hiệu năng
                var validationResults = await Task.WhenAll(
                    _validators.Select(v =>
                        v.ValidateAsync(context, cancellationToken)
                    )
                );

                // Gom tất cả lỗi từ các validator
                var failures = validationResults
                    .SelectMany(r => r.Errors)   // Gộp errors từ nhiều ValidationResult
                    .Where(f => f != null)       // Loại bỏ lỗi null (an toàn)
                    .ToList();                   // Chuyển sang List

                // Nếu tồn tại lỗi validate
                if (failures.Count != 0)
                {
                    // Ném ValidationException
                    // ExceptionMiddleware sẽ bắt và trả về 400 Bad Request
                    throw new ValidationException(failures);
                }
            }

            // Nếu không có lỗi → cho request đi tiếp tới Handler
            return await next();
        }
    }
}
