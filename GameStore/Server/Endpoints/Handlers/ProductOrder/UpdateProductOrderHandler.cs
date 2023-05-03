using GameStore.Server.Endpoints.Requests.ProductOrder;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.ProductOrder
{
    public class UpdateProductOrderHandler : IRequestHandler<UpdateProductOrderRequest, IResult>
    {
        private readonly IUnitOfWork _iUnitOfWork;

        public UpdateProductOrderHandler(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }
        public async Task<IResult> Handle(UpdateProductOrderRequest request, CancellationToken cancellationToken)
        {
            await _iUnitOfWork.ProductOrderRepository.UpdateProductOrderInTable(request.ProductOrder);
            await _iUnitOfWork.SaveAsync();

            return Results.Ok();
        }
    }
}
