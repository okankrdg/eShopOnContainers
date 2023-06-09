namespace Microsoft.eShopOnContainers.Services.Ordering.API.Application.Commands;

public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommand, bool>
{
    public IOrderRepository _orderRepository { get; }
    public CompleteOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }


    public async Task<bool> Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetAsync(request.OrderNumber);
        if (order == null)
        {
            return false;
        }
        order.SetCompletedStatus();
        return await _orderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

    }
}
public class CompleteOrderIdenfiedCommandHandler : IdentifiedCommandHandler<CompleteOrderCommand, bool>
{
    public CompleteOrderIdenfiedCommandHandler(
        IMediator mediator,
        IRequestManager requestManager,
        ILogger<IdentifiedCommandHandler<CompleteOrderCommand, bool>> logger)
        : base(mediator, requestManager, logger)
    {
    }

    protected override bool CreateResultForDuplicateRequest()
    {
        return true; 
    }
}
