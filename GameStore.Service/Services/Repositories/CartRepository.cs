using GameStore.DataAccess.Contexts;
using GameStore.Shared.DataModels.Products;
using GameStore.Shared.DTO;
using GameStore.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Service.Services.Repositories;

public class CartRepository : ICartRepository
{
	#region Fields & CTOR

	private readonly GameStoreContext _context;

	public CartRepository(GameStoreContext context)
	{
		_context = context;
	}

	#endregion

	public async Task<CartDto> AddCartToDb(CartDto cartDto)
	{
		cartDto.Id = Guid.NewGuid();
		cartDto.CartDetails = cartDto.CartDetails.Select(c => new CartDetailsDto()
		{
			Id = Guid.NewGuid(),
			CartId = cartDto.Id,
			ProductId = c.ProductId,
			OrderDetailsCost = c.OrderDetailsCost,
			Quantity = c.Quantity
		}).ToList();

		var entity = await _context.Cart!.AddAsync(ConvertToModel(cartDto));

		return ConvertToDto(entity.Entity);
	}

	public async Task<IEnumerable<CartDto>> FetchAllCartsFromDb()
	{
		var carts = await _context.Cart!.Include(c => c.CartDetails).ToListAsync();

		return carts.Select(ConvertToDto);
	}

	public async Task RemoveCartFromDb(Guid id)
	{
		var cart = await _context.Cart!.FindAsync(id);

		if (cart is null) return;

		_context.Cart.Remove(cart);
	}

	public async Task UpdateCartInDb(CartDto dto)
	{
		var cart = await _context.Cart!.FindAsync(dto.Id);

		if (cart is null) return;

		cart.CartCost = dto.CartCost;
		cart.CartDetails = dto.CartDetails.Select(x => new CartDetailsModel()
		{
			Id = x.Id,
			Quantity = x.Quantity,
			OrderDetailsCost = x.OrderDetailsCost,
			CartId = x.CartId,
			ProductId = x.ProductId
		}).ToList();

		_context.Cart.Update(cart);
	}

	public async Task<CartDto> FetchCartById(Guid id)
	{
		var cart = await _context.Cart!.FindAsync(id);

		if (cart is null) return new CartDto();

		return ConvertToDto(cart);
	}

	private CartDto ConvertToDto(CartModel model)
	{
		return new CartDto()
		{
			Id = model.Id,
			CustomerId = model.CustomerId,
			CartCost = model.CartCost,
			CartDetails = model.CartDetails.Select(c => new CartDetailsDto()
			{
				Id = c.Id,
				Quantity = c.Quantity,
				OrderDetailsCost = c.OrderDetailsCost,
				CartId = c.CartId,
				ProductId = c.ProductId
			}).ToList()
		};
	}

	private CartModel ConvertToModel(CartDto dto)
	{
		return new CartModel()
		{
			Id = dto.Id,
			CustomerId = dto.CustomerId,
			CartCost = dto.CartCost,
			CartDetails = dto.CartDetails.Select(c => new CartDetailsModel()
			{
				Id = c.Id,
				Quantity = c.Quantity,
				OrderDetailsCost = c.OrderDetailsCost,
				CartId = c.CartId,
				ProductId = c.ProductId
			}).ToList()
		};
	}
}