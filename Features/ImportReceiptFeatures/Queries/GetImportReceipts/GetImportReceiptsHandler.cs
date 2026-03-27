using AutoMapper;
using MediatR;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ImportReceiptFeatures.Queries.GetImportReceipts
{
    public class GetImportReceiptsHandler : IRequestHandler<GetImportReceiptsQuery, List<GetImportReceiptsResult>>
    {
        private readonly IImportReceiptRepository _importReceiptRepository;
        private readonly IMapper _mapper;

        public GetImportReceiptsHandler(IImportReceiptRepository importReceiptRepository, IMapper mapper)
        {
            _importReceiptRepository = importReceiptRepository;
            _mapper = mapper;
        }

        public async Task<List<GetImportReceiptsResult>> Handle(GetImportReceiptsQuery request, CancellationToken cancellationToken)
        {
            var receipts = await _importReceiptRepository.GetAllAsync();
            return _mapper.Map<List<GetImportReceiptsResult>>(receipts);
        }
    }
}
