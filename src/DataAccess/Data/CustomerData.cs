using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class CustomerData : ICustomerData
{
    private readonly ISqlDataAccess _dataAccess;

    public CustomerData(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task<IEnumerable<Customer>> GetCustomers() =>
        _dataAccess.LoadData<Customer, dynamic>("dbo.spCustomer_GetAll", new { });

    public async Task<Customer?> GetCustomer(int id)
    {
        var customers = await _dataAccess.LoadData<Customer, dynamic>("dbo.spCustomer_Get", new { Id = id });
        return customers.FirstOrDefault();
    }

    public Task InsertCustomer(Customer customer) =>
        _dataAccess.SaveData("dbo.spCustomer_Insert", new { customer.FirstName, customer.LastName });

    public Task UpdateCustomer(Customer customer) =>
        _dataAccess.SaveData("dbo.spCustomer_Update", customer);

    public Task DeleteCustomer(int id) =>
        _dataAccess.SaveData("dbo.spCustomer_Delete", new { Id = id });
}
