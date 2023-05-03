using GameStore.Shared.DTO;

namespace GameStore.Shared.Services.Interfaces
{
    public interface IMailRepository
    {

        Task AddMailToDb(MailDTO Mail);

    }
}
