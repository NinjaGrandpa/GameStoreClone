using GameStore.DataAccess.Contexts;
using GameStore.Shared.DataModels.Products;
using GameStore.Shared.DTO;
using GameStore.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Service.Services.Repositories;

public class ProductRepository : IProductRepository
{
	#region Fields # CTOR

	private readonly GameStoreContext _dbContext;

	public ProductRepository(GameStoreContext dbContext)
	{
		_dbContext = dbContext;
	}

	#endregion

	#region CRUD Operations

	public async Task AddProductToDb(ProductDto product)
	{
		product.Id = Guid.NewGuid();

		product = SetIdOnSpecifications(product);

		await _dbContext.Product!.AddAsync(ConvertToModel(product));
	}

	private ProductDto SetIdOnSpecifications(ProductDto product)
	{
		product.SpecificationGroups!.Select(x =>
		{
			x.Id = Guid.NewGuid();
			return x;
		}).ToList();

		product.SpecificationGroups!.Select(i => i.SpecificationItems!
			.Select(x =>
			{
				x.Id = Guid.NewGuid();
				return x;
			}).ToList()
		).ToList();

		return product;
	}

	public async Task RemoveProductFromDb(Guid id)
	{
		var productToRemove = await _dbContext.Product!.FindAsync(id);

		if (productToRemove is null) return;

		_dbContext.Product.Remove(productToRemove);
	}

	public async Task UpdateProductInDb(ProductDto product)
	{
		var updateProduct = await _dbContext.Product!.FindAsync(product.Id);

		if (updateProduct is null) return;

		updateProduct.Name = product.Name;
		updateProduct.Manufacturer = product.Manufacturer;
		updateProduct.Description = product.Description;
		updateProduct.ImageData = product.ImageData;
		updateProduct.UnitPrice = product.UnitPrice;
		updateProduct.AmountInStock = product.AmountInStock;
		updateProduct.SpecificationGroups = product.SpecificationGroups!.Select(x => new SpecificationGroupModel()
		{
			Id = x.Id,
			Title = x.Title,
			SpecificationItems = x.SpecificationItems!.Select(s => new SpecificationItemModel()
			{
				Id = s.Id,
				InformationType = s.InformationType,
				InformationValue = s.InformationValue
			}).ToList()
		}).ToList();

		_dbContext.Product.Update(updateProduct);
	}

	public async Task<IEnumerable<ProductDto>> FetchAllProductsFromDb()
	{
		var products = await _dbContext.Product!
			.Include(c => c.SpecificationGroups)!
			.ThenInclude(x => x.SpecificationItems).ToListAsync();

		if (!products.Any()) return new List<ProductDto>();

		return products.Select(ConvertToDto);
	}

	public async Task<ProductDto> FetchProductByIdFromDb(Guid id)
	{
		var product = await _dbContext.Product!
			.Include(x => x.SpecificationGroups)!
			.ThenInclude(x => x.SpecificationItems)
			.FirstOrDefaultAsync(x => x.Id.Equals(id));

		if (product is null) return new ProductDto();

		return ConvertToDto(product);
	}

	private ProductModel ConvertToModel(ProductDto product)
	{
		return new ProductModel()
		{
			Id = product.Id,
			Name = product.Name,
			Manufacturer = product.Manufacturer,
			Description = product.Description,
			ImageData = product.ImageData,
			UnitPrice = product.UnitPrice,
			AmountInStock = product.AmountInStock,
			SpecificationGroups = product.SpecificationGroups!.Select(x => new SpecificationGroupModel()
			{
				Id = x.Id,
				Title = x.Title,
				SpecificationItems = x.SpecificationItems!.Select(s => new SpecificationItemModel()
				{
					Id = s.Id,
					InformationType = s.InformationType,
					InformationValue = s.InformationValue
				}).ToList()
			}).ToList()
		};
	}

	private ProductDto ConvertToDto(ProductModel product)
	{
		return new ProductDto()
		{
			Id = product.Id,
			Name = product.Name,
			Manufacturer = product.Manufacturer,
			Description = product.Description,
			ImageData = product.ImageData,
			UnitPrice = product.UnitPrice,
			AmountInStock = product.AmountInStock,
			SpecificationGroups = product.SpecificationGroups!.Select(x => new SpecificationGroupDto()
			{
				Id = x.Id,
				Title = x.Title,
				SpecificationItems = x.SpecificationItems!.Select(s => new SpecificationItemDto()
				{
					Id = s.Id,
					InformationType = s.InformationType,
					InformationValue = s.InformationValue
				}).ToList()
			}).ToList()
		};
	}

	#endregion
}
