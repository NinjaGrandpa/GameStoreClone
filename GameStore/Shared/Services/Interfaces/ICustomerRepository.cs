using GameStore.Shared.DTO;

namespace GameStore.Shared.Services.Interfaces;

public interface ICustomerRepository
{
	Task AddCustomerToDb(CustomerDto customer);

	Task RemoveCustomerFromDb(Guid id);

	Task UpdateCustomerInDb(CustomerDto customer);

	Task<IEnumerable<CustomerDto>> FetchAllCustomersFromDb();

	Task<CustomerDto> FetchCustomerByIdFromDb(Guid id);

    Task<CustomerDto> FetchCustomerByEmailFromDb(string email);
}