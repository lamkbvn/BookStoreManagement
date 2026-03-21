using AutoMapper;
using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.UserFeatures.Queries.GetAllUser
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserCommand, List<GetAllUserResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllUserResult>> Handle(GetAllUserCommand request, CancellationToken cancellationToken)
        {
            var listUser = await _userRepository.GetAll();

            return _mapper.Map<List<GetAllUserResult>>(listUser);
        }
    }
}
