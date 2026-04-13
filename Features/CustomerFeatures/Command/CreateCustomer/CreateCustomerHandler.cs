using AutoMapper;
using MediatR;
using WebBanHang.Common.Exceptions;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.CustomerFeatures.Command.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var checkExistPhone = await _customerRepository.CheckExistPhoneNumber(request.Phone);

            if (checkExistPhone)
                throw new AppException("Số điện thoại đã tồn tại", 400);

            var customer = _mapper.Map<Customer>(request);
            await _customerRepository.AddAsync(customer);
            return _mapper.Map<CreateCustomerResult>(customer);

        }
    }
}
