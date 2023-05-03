using GameStore.DataAccess.Contexts;
using GameStore.Shared.DataModels;
using GameStore.Shared.DTO;
using GameStore.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Service.Services.Repositories;

public class CustomerRepository : ICustomerRepository
{
	#region Fields & CTOR
	private readonly GameStoreContext _dbContext;
	public CustomerRepository(GameStoreContext dbContext)
	{
		_dbContext = dbContext;
	}
	#endregion

	#region CRUD Operations
	public async Task AddCustomerToDb(CustomerDto customer)
	{
		customer.Id = Guid.NewGuid();
		await _dbContext.Customer.AddAsync(ConvertToModel(customer));
	}

	public async Task RemoveCustomerFromDb(Guid id)
	{
		var customerToRemove = await _dbContext.Customer.FindAsync(id);

		if (customerToRemove is null) return;

		_dbContext.Customer.Remove(customerToRemove);
	}

	public async Task UpdateCustomerInDb(CustomerDto customer)
	{
		var updateCustomerInDbTable = await _dbContext.Customer.FindAsync(customer.Id);

		if (updateCustomerInDbTable is null) return;

		updateCustomerInDbTable.FirstName = customer.FirstName;
		updateCustomerInDbTable.LastName = customer.LastName;
		updateCustomerInDbTable.PhoneNumber = customer.PhoneNumber;
		updateCustomerInDbTable.Email = customer.Email;
		updateCustomerInDbTable.Address = customer.Address;
		updateCustomerInDbTable.PostalCode = customer.PostalCode;
		updateCustomerInDbTable.City = customer.City;
		updateCustomerInDbTable.Country = customer.Country;

		_dbContext.Customer.Update(updateCustomerInDbTable);
	}

	public async Task<IEnumerable<CustomerDto>> FetchAllCustomersFromDb()
	{
		var customers = await _dbContext.Customer.ToListAsync();

		if(!customers.Any()) return new List<CustomerDto>();

		return customers.Select(ConvertToDto);
	}

	public async Task<CustomerDto> FetchCustomerByIdFromDb(Guid id)
	{
		var customer = await _dbContext.Customer.FindAsync(id);

		if (customer is null) return new CustomerDto();

		return ConvertToDto(customer);
	}

	public async Task<CustomerDto> FetchCustomerByEmailFromDb(string email)
	{
		var customer = await _dbContext.Customer.FirstOrDefaultAsync(e => e.Email == email);

		if (customer is null) return new CustomerDto();

		return ConvertToDto(customer);
	}

	private CustomerModel ConvertToModel(CustomerDto customer)
	{
		return new CustomerModel()
		{
			Id = customer.Id,
			FirstName = customer.FirstName,
			LastName = customer.LastName,
			PhoneNumber = customer.PhoneNumber,
			Email = customer.Email,
			Address = customer.Address,
			PostalCode = customer.PostalCode,
			City = customer.City,
			Country = customer.Country
		};
	}

	private CustomerDto ConvertToDto(CustomerModel customer)
	{
		return new CustomerDto()
		{
			Id = customer.Id,
			FirstName = customer.FirstName,
			LastName = customer.LastName,
			PhoneNumber = customer.PhoneNumber,
			Email = customer.Email,
			Address = customer.Address,
			PostalCode = customer.PostalCode,
			City = customer.City,
			Country = customer.Country
		};
	}
	#endregion
}