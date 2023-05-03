using GameStore.Server.Endpoints.Requests.EventOrders;
using GameStore.Server.Endpoints.Requests.Mail;
using GameStore.Server.Extensions;

namespace GameStore.Server.Extensions.EndpointsGrouped
{
    public static class MailGroupBuilderExtensions
    {
        public static RouteGroupBuilder MapMailGroup(this RouteGroupBuilder builder)
        {
            builder.MediatePost<AddMailRequest>("/");
            return builder;
        }
    }

}


