using GameStore.Server.Endpoints.Requests.Mail;
using GameStore.Shared.Services.Interfaces;
using MediatR;

namespace GameStore.Server.Endpoints.Handlers.Mails
{


    public class AddMailHandler : IRequestHandler<AddMailRequest, IResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddMailHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Handle(AddMailRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.MailRepository.AddMailToDb(request.MailDTO);
            await _unitOfWork.SaveAsync();
            return Results.Ok(request.MailDTO);
        }
    }
}
