using GameStore.Shared.DataModels;
using GameStore.Shared.DataModels.Products;
using Microsoft.EntityFrameworkCore;

namespace GameStore.DataAccess.Contexts;

public class GameStoreContext : DbContext
{
	public DbSet<CustomerModel>? Customer { get; set; }
	public DbSet<EventModel>? Events { get; set; }
	public DbSet<EventOrderModel>? EventOrder { get; set; }
	public DbSet<MailModel>? Mail { get; set; }
	public DbSet<ProductModel>? Product { get; set; }
	public DbSet<ProductOrderModel>? ProductOrder { get; set; }
	public DbSet<ProductOrderDetailsModel>? ProductOrderDetails { get; set; }
	public DbSet<SpecificationGroupModel>? SpecificationGroup { get; set; }
	public DbSet<SpecificationItemModel>? SpecificationItem { get; set; }
	public DbSet<CartModel>? Cart { get; set; }
	public DbSet<CartDetailsModel>? CartDetails { get; set; }


	public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
	{

	}
}