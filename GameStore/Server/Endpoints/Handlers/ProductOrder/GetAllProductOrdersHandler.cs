using GameStore.Server.Endpoints.Requests.ProductOrder;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.ProductOrder
{
    public class GetAllProductOrdersHandler : IRequestHandler<GetAllProductOrdersRequest, IResult>
    {
        private readonly IUnitOfWork _iUnitOfWork;

        public GetAllProductOrdersHandler(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }
        public async Task<IResult> Handle(GetAllProductOrdersRequest request, CancellationToken cancellationToken)
        {
            return Results.Ok(await _iUnitOfWork.ProductOrderRepository.FetchAllProductOrdersFromDbTable());
        }
    }
}
