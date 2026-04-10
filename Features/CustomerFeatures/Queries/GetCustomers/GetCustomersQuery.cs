using MediatR;

namespace WebBanHang.Features.CustomerFeatures.Queries.GetCustomers
{
    public class GetCustomersQuery : IRequest<IEnumerable<GetCustomersResult>>
    {
    }
}
