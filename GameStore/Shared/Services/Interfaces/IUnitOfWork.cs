namespace GameStore.Shared.Services.Interfaces;

public interface IUnitOfWork : IDisposable
{
	ICustomerRepository CustomerRepository { get; }

	IEventRepository EventRepository { get; }

	IEventOrderRepository EventOrderRepository { get; }

	IMailRepository MailRepository { get; }

	IProductRepository ProductRepository { get; }

	IProductOrderRepository ProductOrderRepository { get; }

	ICartRepository CartRepository { get; }
	Task SaveAsync();
}