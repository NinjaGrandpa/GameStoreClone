using MediatR;

namespace GameStore.Server.Endpoints.Requests
{
    public interface IHttpRequest : IRequest<IResult>
    {
    }
}
