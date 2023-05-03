using GameStore.Server.Endpoints.Requests.Products;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Product;

public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.ProductRepository.RemoveProductFromDb(request.Id);
        await _unitOfWork.SaveAsync();

        return Results.Ok(request.Id);
    }
}