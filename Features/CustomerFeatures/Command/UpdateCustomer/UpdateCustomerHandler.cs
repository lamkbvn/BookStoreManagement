using AutoMapper;
using MediatR;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.CustomerFeatures.Command.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerResult> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if (customer == null)
                throw new AppException("Không tìm thấy khách hàng", 404);

            // Kiểm tra nếu đổi số điện thoại mới thì số đó đã tồn tại chưa
            if (customer.Phone != request.Phone)
            {
                var checkExistPhone = await _customerRepository.CheckExistPhoneNumber(request.Phone);
                if (checkExistPhone)
                    throw new AppException("Số điện thoại mới đã tồn tại", 409);
            }

            _mapper.Map(request, customer);
            await _customerRepository.Update(customer);

            return _mapper.Map<UpdateCustomerResult>(customer);
        }
    }
}