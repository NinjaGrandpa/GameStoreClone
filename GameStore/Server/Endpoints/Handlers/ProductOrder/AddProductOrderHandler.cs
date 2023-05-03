using GameStore.Server.Endpoints.Requests.ProductOrder;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.ProductOrder
{
    public class AddProductOrderHandler : IRequestHandler<AddProductOrderRequest, IResult>
    {
        private readonly IUnitOfWork _iUnitOfWork;

        public AddProductOrderHandler(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }

        public async Task<IResult> Handle(AddProductOrderRequest request, CancellationToken cancellationToken)
        {
            await _iUnitOfWork.ProductOrderRepository.AddProductOrderToDb(request.Order);
            await _iUnitOfWork.SaveAsync();

            return Results.Ok();
        }
    }
}
