using GameStore.Server.Endpoints.Requests;
using GameStore.Shared.DTO;

namespace GameStore.Server.Endpoints.Requests.Mail
{
    public class AddMailRequest : IHttpRequest
    {
        public MailDTO MailDTO { get; set; }
    }
}

