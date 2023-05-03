using GameStore.Server.Endpoints.Requests.Products;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Product;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllProductsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.ProductRepository.FetchAllProductsFromDb();

        return Results.Ok(products);
    }
}