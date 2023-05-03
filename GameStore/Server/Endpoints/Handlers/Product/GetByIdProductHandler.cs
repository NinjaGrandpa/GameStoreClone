using GameStore.Server.Endpoints.Requests.Products;
using GameStore.Shared.Services.Interfaces;
using MediatR;
using NuGet.Protocol.Plugins;

namespace GameStore.Server.Endpoints.Handlers.Product;

public class GetByIdProductHandler : IRequestHandler<GetByIdProductRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(GetByIdProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.FetchProductByIdFromDb(request.Id);

        return Results.Ok(product);
    }
}