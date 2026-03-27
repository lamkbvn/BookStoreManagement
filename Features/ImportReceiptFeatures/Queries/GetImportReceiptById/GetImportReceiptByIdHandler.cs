using AutoMapper;
using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ImportReceiptFeatures.Queries.GetImportReceiptById
{
    public class GetImportReceiptByIdHandler : IRequestHandler<GetImportReceiptByIdQuery, GetImportReceiptByIdResult>
    {
        private readonly IImportReceiptRepository _importReceiptRepository;
        private readonly IMapper _mapper;

        public GetImportReceiptByIdHandler(IImportReceiptRepository importReceiptRepository, IMapper mapper)
        {
            _importReceiptRepository = importReceiptRepository;
            _mapper = mapper;
        }

        public async Task<GetImportReceiptByIdResult> Handle(GetImportReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            var receipt = await _importReceiptRepository.GetByIdAsync(request.Id);
            if (receipt == null)
                throw new InvalidOperationException($"Import receipt with id {request.Id} not found");

            return _mapper.Map<GetImportReceiptByIdResult>(receipt);
        }
    }
}
