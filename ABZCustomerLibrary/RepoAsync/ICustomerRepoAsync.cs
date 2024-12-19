using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZCustomerLibrary.Models;

namespace ABZCustomerLibrary.RepoAsync
{
    public interface ICustomerRepoAsync
    {
        Task InsertCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(string customerId,Customer customer);
        Task DeleteCustomerAsync(string customerId);
        Task<Customer> GetCustomerByIdAsync(string customerId);
        Task<List<Customer>> GetAllCustomersAsync();
    }
}
