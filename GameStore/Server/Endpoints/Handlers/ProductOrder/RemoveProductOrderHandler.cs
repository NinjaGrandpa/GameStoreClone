using GameStore.Server.Endpoints.Requests.ProductOrder;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.ProductOrder
{
    public class RemoveProductOrderHandler : IRequestHandler<RemoveProductOrderRequest, IResult>
    {
        private readonly IUnitOfWork _iUnitOfWork;

        public RemoveProductOrderHandler(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }
        public async Task<IResult> Handle(RemoveProductOrderRequest request, CancellationToken cancellationToken)
        {
            await _iUnitOfWork.ProductOrderRepository.RemoveProductOrderFromDb(request.OrderId);
            await _iUnitOfWork.SaveAsync();

            return Results.Ok();
        }
    }
}
