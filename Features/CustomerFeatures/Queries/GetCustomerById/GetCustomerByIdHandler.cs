using AutoMapper;
using MediatR;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.CustomerFeatures.Queries.GetCustomerById
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerByIdHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<GetCustomerByIdResult> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if (customer == null)
                throw new AppException("Khách hàng không tồn tại", 404);

            return _mapper.Map<GetCustomerByIdResult>(customer);
        }
    }
}