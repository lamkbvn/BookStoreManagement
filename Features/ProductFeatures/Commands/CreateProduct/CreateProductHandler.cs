using AutoMapper;
using MediatR;
using WebBanHang.Entity;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            var created = await _productRepository.AddAsync(product, request.Quantity);

            // load back with inventory for mapping quantity
            var full = await _productRepository.GetByIdAsync(created.Id) ?? created;
            return _mapper.Map<CreateProductResult>(full);
        }
    }
}

