using GameStore.DataAccess.Contexts;
using GameStore.Shared.DataModels.Enums;
using GameStore.Shared.DataModels.Products;
using GameStore.Shared.DTO;
using GameStore.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Service.Services.Repositories
{
	public class ProductOrderRepository : IProductOrderRepository
	{
		#region Fields and CTOR

		private readonly GameStoreContext _dbContext;

		public ProductOrderRepository(GameStoreContext dbContext)
		{
			_dbContext = dbContext;
		}

		#endregion

		public async Task<ProductOrderDto> AddProductOrderToDb(ProductOrderDto dto)
		{
			dto.Id = Guid.NewGuid();
			dto.Status = OrderStatus.Processing;
			dto.CreatedDate = DateTime.UtcNow;

			dto.OrderDetails = dto.OrderDetails.Select(x => new ProductOrderDetailsDto()
			{
				Id = Guid.NewGuid(),
				ProductOrderId = dto.Id,
				Quantity = x.Quantity,
				OrderDetailsCost = x.OrderDetailsCost,
				ProductId = x.ProductId
			}).ToList();

			var entity = await _dbContext.ProductOrder!.AddAsync(ConvertToModel(dto));

			return ConvertToDto(entity.Entity);
		}

		public async Task<IEnumerable<ProductOrderDto>> FetchAllProductOrdersFromDbTable()
		{
			var orderList = await _dbContext.ProductOrder!.Include(x => x.OrderDetails).ToListAsync();
			return orderList.Select(ConvertToDto);
		}

		public async Task<ProductOrderDto> FetchProductOrderById(Guid id)
		{
			var selectedOrder = await _dbContext.ProductOrder!
				.Include(x => x.OrderDetails)
				.FirstOrDefaultAsync(x => x.Id.Equals(id));

			if (selectedOrder is null) return new ProductOrderDto();

			return ConvertToDto(selectedOrder);
		}

		public async Task RemoveProductOrderFromDb(Guid id)
		{
			var selectedOrderToRemove = await _dbContext.ProductOrder!.FindAsync(id);

			if (selectedOrderToRemove is null) return;

			_dbContext.ProductOrder.Remove(selectedOrderToRemove);
		}

		public async Task UpdateProductOrderInTable(ProductOrderDto productOrderDto)
		{
			var selectedOrderToUpdate = await _dbContext.ProductOrder!.FindAsync(productOrderDto.Id);

			if (selectedOrderToUpdate is null) return;

			selectedOrderToUpdate.CreatedDate = productOrderDto.CreatedDate;
			selectedOrderToUpdate.Status = productOrderDto.Status;
			selectedOrderToUpdate.OrderCost = productOrderDto.OrderCost;
			selectedOrderToUpdate.RowVersion = productOrderDto.RowVersion;
			selectedOrderToUpdate.OrderDetails = productOrderDto.OrderDetails.Select(x => new ProductOrderDetailsModel()
			{
				Id = x.Id,
				Quantity = x.Quantity,
				OrderDetailsCost = x.OrderDetailsCost,
				ProductId = x.ProductId,
				ProductOrderId = x.ProductOrderId
			}).ToList();

			_dbContext.ProductOrder.Update(selectedOrderToUpdate);
		}

		private ProductOrderDto ConvertToDto(ProductOrderModel model)
		{
			return new ProductOrderDto
			{
				Id = model.Id,
				CustomerId = model.CustomerId,
				CreatedDate = model.CreatedDate,
				Status = model.Status,
				OrderCost = model.OrderCost,
				RowVersion = model.RowVersion,
				OrderDetails = model.OrderDetails.Select(x => new ProductOrderDetailsDto()
				{
					Id = x.Id,
					OrderDetailsCost = x.OrderDetailsCost,
					ProductId = x.ProductId,
					ProductOrderId = x.ProductOrderId,
					Quantity = x.Quantity
				}).ToList()
			};
		}

		private ProductOrderModel ConvertToModel(ProductOrderDto dto)
		{
			return new ProductOrderModel
			{
				Id = dto.Id,
				CustomerId = dto.CustomerId,
				CreatedDate = dto.CreatedDate,
				Status = dto.Status,
				OrderCost = dto.OrderCost,
				RowVersion = dto.RowVersion,
				OrderDetails = dto.OrderDetails.Select(x => new ProductOrderDetailsModel()
				{
					Id = x.Id,
					Quantity = x.Quantity,
					OrderDetailsCost = x.OrderDetailsCost,
					ProductId = x.ProductId,
					ProductOrderId = x.ProductOrderId
				}).ToList()
			};
		}
	}
}
