using GameStore.Server.Endpoints.Requests.Products;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Product;

public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.ProductRepository.UpdateProductInDb(request.Product);
        await _unitOfWork.SaveAsync();

        return Results.Ok(request);
    }
}