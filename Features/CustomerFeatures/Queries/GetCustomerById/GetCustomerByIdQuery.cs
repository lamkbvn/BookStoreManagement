using MediatR;

namespace WebBanHang.Features.CustomerFeatures.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<GetCustomerByIdResult>
    {
        public int Id { get; set; }
        public GetCustomerByIdQuery(int id) => Id = id;
    }
}
