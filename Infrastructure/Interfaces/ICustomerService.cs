using Domain.ApiResponse;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface ICustomerService
{
    Task<Response<string>> CreateCustomerAsync(Customer customer);
    Task<Response<List<Customer>>> GetAllCustomerAsync();
    Task<Response<string>> UpdateCustomerAsync(Customer customer);
    Task<Response<string>> DeleteCustomerWithIdAsync(int Id);
    Task<Response<Customer>> GetCustomerWithIdAsync(int Id);
}