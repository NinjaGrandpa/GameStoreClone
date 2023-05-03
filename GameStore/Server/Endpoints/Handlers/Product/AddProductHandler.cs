using GameStore.Server.Endpoints.Requests.Products;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Product;

public class AddProductHandler : IRequestHandler<AddProductRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(AddProductRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.ProductRepository.AddProductToDb(request.Product);
        await _unitOfWork.SaveAsync();

        return Results.Ok(request.Product);
    }
}