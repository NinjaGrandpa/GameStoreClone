using GameStore.Server.Endpoints.Requests.ProductOrder;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.ProductOrder
{
	public class GetProductOrderByIdHandler : IRequestHandler<GetProductOrderByIdRequest, IResult>
	{
		private readonly IUnitOfWork _iUnitOfWork;
		public GetProductOrderByIdHandler(IUnitOfWork iUnitOfWork)
		{
			_iUnitOfWork = iUnitOfWork;
		}
		public async Task<IResult> Handle(GetProductOrderByIdRequest request, CancellationToken cancellationToken)
		{
			var response = await _iUnitOfWork.ProductOrderRepository.FetchProductOrderById(request.OrderId);

			return Results.Ok(response);
		}
	}
}
