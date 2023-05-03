using GameStore.DataAccess.Contexts;
using GameStore.Shared.DataModels;
using GameStore.Shared.DTO;
using GameStore.Shared.Services.Interfaces;

namespace GameStore.Service.Services.Repositories
{
    public class MailRepository : IMailRepository
    {
        #region Fields & CTOR
        private readonly GameStoreContext _dbContext;
        public MailRepository(GameStoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion


        #region CRUD

        private MailModel ConvertToModel(MailDTO mail)
        {
            DateTime date = DateTime.Now;
            byte[] bytes = BitConverter.GetBytes(date.Ticks);

            MailModel newRegistration = new MailModel()
            {
                Id = 0,
                EventOrderId = mail.EventOrderId,
                Email = mail.Email,
                FirstName = mail.FirstName,
                EventName = mail.EventName,
                Seats = mail.Seats,
                Date = mail.Date,
                Adress = mail.Adress,
                PostalCode = mail.PostalCode,
                RowVersion = bytes
            };
            return newRegistration;
        }

        public async Task AddMailToDb(MailDTO Mail)
        {
            await _dbContext.Mail!.AddAsync(ConvertToModel(Mail));
        }
        #endregion
    }
}
