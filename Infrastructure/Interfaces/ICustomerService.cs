using Domain.DTOs.CustomerDto;
using Domain.ApiResponse;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface ICustomerService
{
    Task<Response<string>> CreateCustomerAsync(CreateCustomerDto createCustomerDto);
    Task<Response<List<GetCustomerDto>>> GetAllCustomerAsync();
    Task<Response<string>> UpdateCustomerAsync(Guid Id, UpdateCustomerDto updateCustomerDto);
    Task<Response<string>> DeleteCustomerWithIdAsync(int Id);
}