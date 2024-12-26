using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZQueryLibrary.Models;

namespace ABZQueryLibrary.Repos
{
    public interface ICustomerQueryRepoAsync
    {
        Task InsertCustomerQueryAsync(CustomerQuery customerquery);
        Task DeleteCustomerQueryAsync(string queryId);
        Task UpdateCustomerQueryAsync(string queryId,CustomerQuery customerquery);
        Task<CustomerQuery> GetCustomerQueryAsync(string queryId);
        Task<List<CustomerQuery>> GetAllCustomerQueriesAsync();
        Task <List<CustomerQuery>> GetCustomerQueryByCustomerAsync(string customerId);
        Task InsertCustomerAsync(Customer customer);
    }
}
