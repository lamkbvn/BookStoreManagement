using MediatR;

namespace WebBanHang.Features.CustomerFeatures.Command.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<CreateCustomerResult>
    {
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required string Phone { get; set; }

        public string? Address { get; set; }
    }
}
