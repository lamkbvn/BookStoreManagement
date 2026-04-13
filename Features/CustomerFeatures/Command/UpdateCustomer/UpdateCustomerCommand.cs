using MediatR;

namespace WebBanHang.Features.CustomerFeatures.Command.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<UpdateCustomerResult>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required string Phone { get; set; }
        public string? Address { get; set; }
    }
}