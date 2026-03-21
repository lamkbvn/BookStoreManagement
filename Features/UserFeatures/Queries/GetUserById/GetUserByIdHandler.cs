using AutoMapper;
using MediatR;
using WebBanHang.Common.Exceptions;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.UserFeatures.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdCommand, GetUserByIdResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserByIdResult> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindById(request.Id);

            if (user == null)
                throw new AppException($"User với id là {request.Id} không tồn tại", 404);


            return _mapper.Map<GetUserByIdResult>(user);
        }
    }
}
