using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using WebBanHang.Common.Exceptions;
using WebBanHang.DbContextConfig;
using WebBanHang.Entity;
using WebBanHang.Enum;
using WebBanHang.Features.InventoryFeatures.Commands.DecreaseInventory;
using WebBanHang.Repository.Interface;

namespace WebBanHang.Features.OrderFeatures.Commands.CreateOrder
{
    public class CreateOrderHandler
        : IRequestHandler<CreateOrderCommand, CreateOrderResult>
    {
        private readonly AppDbContext _dbContext;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateOrderHandler(
            AppDbContext dbContext,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IInventoryRepository inventoryRepository,
            IMediator mediator,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<CreateOrderResult> Handle(
            CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var normalizedPromotionId = request.PromotionId.HasValue && request.PromotionId.Value > 0
                    ? request.PromotionId
                    : null;

                var order = new Order
                {
                    CustomerId = request.CustomerId,
                    UserId = request.UserId,
                    PromotionId = normalizedPromotionId,
                    Status = OrderStatus.Paid,
                    OrderDate = DateTime.Now,
                    OrderItems = new List<OrderItem>()
                };

                foreach (var item in request.OrderItems)
                {
                    var product = await _productRepository.GetByIdAsync(item.ProductId);
                    if (product == null)
                        throw new AppException($"Product with id {item.ProductId} not found", StatusCodes.Status404NotFound);

                    var inventory = await _inventoryRepository.GetByProductIdAsync(item.ProductId);
                    if (inventory == null)
                        throw new AppException($"Inventory for product {item.ProductId} not found", StatusCodes.Status404NotFound);

                    await _mediator.Send(new DecreaseInventoryCommand
                    {
                        Id = inventory.Id,
                        Quantity = item.Quantity
                    }, cancellationToken);

                    order.OrderItems.Add(new OrderItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = product.Price
                    });
                }

                // Calculate total price
                var totalPrice = order.OrderItems.Sum(oi => oi.Quantity * oi.UnitPrice);

                // Calculate discount before saving to database
                if (normalizedPromotionId.HasValue)
                {
                    // Get promotion details to calculate discount
                    var promotion = await _orderRepository.GetPromotionByIdAsync(normalizedPromotionId.Value);
                    if (promotion == null)
                        throw new AppException("Promotion does not exist", StatusCodes.Status404NotFound);

                    var now = DateTime.Now;
                    var isPromotionAvailable = promotion.IsActive
                        && promotion.StartDate <= now
                        && promotion.EndDate >= now;

                    if (!isPromotionAvailable)
                        throw new AppException("Mã khuyến mãi không khả dụng hoặc đã hết hạn", StatusCodes.Status400BadRequest);

                    var calculatedDiscount = totalPrice * (promotion.DiscountPercentage / 100);
                    // Apply maximum discount limit
                    order.DiscountAmount = Math.Min(calculatedDiscount, promotion.MaximumDiscountAmount);
                    order.FinalPrice = totalPrice - order.DiscountAmount;
                }
                else
                {
                    order.DiscountAmount = 0;
                    order.FinalPrice = totalPrice;
                }

                var createdOrder = await _orderRepository.AddAsync(order);
                var result = await _orderRepository.GetByIdAsync(createdOrder.Id);

                if (result == null)
                    throw new AppException($"Order with id {createdOrder.Id} not found", StatusCodes.Status404NotFound);

                await transaction.CommitAsync(cancellationToken);
                return _mapper.Map<CreateOrderResult>(result);
            }
            catch
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
