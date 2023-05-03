using GameStore.DataAccess.Contexts;
using GameStore.Shared.Services.Interfaces;

namespace GameStore.Service.Services.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly GameStoreContext _dbContext;
    public ICustomerRepository CustomerRepository { get; }
    public IEventRepository EventRepository { get; }
    public IEventOrderRepository EventOrderRepository { get; }
    public IMailRepository MailRepository { get; }
    public IProductRepository ProductRepository { get; }
    public IProductOrderRepository ProductOrderRepository { get; }
    public ICartRepository CartRepository { get; }

    public UnitOfWork(GameStoreContext dbContext)
    {
        _dbContext = dbContext;
        CustomerRepository = new CustomerRepository(_dbContext);
        EventRepository = new EventRepository(_dbContext);
        EventOrderRepository = new EventOrderRepository(_dbContext);
        MailRepository = new MailRepository(_dbContext);
        ProductRepository = new ProductRepository(_dbContext);
        ProductOrderRepository = new ProductOrderRepository(_dbContext);
        CartRepository = new CartRepository(_dbContext);
    }
    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
    public void Dispose()
    {
        _dbContext.DisposeAsync();
    }
}