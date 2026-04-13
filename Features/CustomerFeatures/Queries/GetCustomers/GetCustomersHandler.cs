using AutoMapper;
using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.CustomerFeatures.Queries.GetCustomers
{

    namespace WebBanHang.Features.CustomerFeatures.Queries.GetCustomers
    {
        public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, IEnumerable<GetCustomersResult>>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;

            public GetCustomersHandler(ICustomerRepository customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetCustomersResult>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
            {
                var customers = await _customerRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<GetCustomersResult>>(customers);
            }
        }
    }
}
