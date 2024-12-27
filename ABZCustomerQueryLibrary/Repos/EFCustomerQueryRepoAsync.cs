using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZCustomerQueryLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ABZCustomerQueryLibrary.Repos
{
    public class EFCustomerQueryRepoAsync:ICustomerQueryRepoAsync
    {
        ABZQueryDBContext ctx=new ABZQueryDBContext();

        public async Task DeleteCustomerQueryAsync(string queryId)
        {
            CustomerQuery customerQuery = await GetCustomerQueryAsync(queryId);
            ctx.CustomerQueries.Remove(customerQuery);
            await ctx.SaveChangesAsync();

        }

        public async Task<List<CustomerQuery>> GetAllCustomerQueriesAsync()
        {
            List<CustomerQuery> customerQueries = await ctx.CustomerQueries.ToListAsync();
            return customerQueries;
        }

        public async Task<CustomerQuery> GetCustomerQueryAsync(string queryId)
        {
            try
            {
                CustomerQuery customerQuery = await (from cq in ctx.CustomerQueries where queryId == cq.QueryID select cq).FirstAsync();
                return customerQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("No such queryId exist");
            }
        }

        public async Task<List<CustomerQuery>> GetCustomerQueryByCustomerAsync(string customerId)
        {
            List<CustomerQuery> customerQueries= await(from cq in ctx.CustomerQueries where customerId==cq.CustomerID select cq).ToListAsync();
            if(customerQueries.Count == 0)
            {
                throw new Exception("No Such CustomerId exist");
            }
            else
            {
                return customerQueries;
            }
        }

        public async Task InsertCustomerAsync(Customer customer)
        {
            await ctx.Customers.AddAsync(customer);
            await ctx.SaveChangesAsync();
        }

        public async Task InsertCustomerQueryAsync(CustomerQuery customerquery)
        {
            await ctx.CustomerQueries.AddAsync(customerquery);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateCustomerQueryAsync(string queryId, CustomerQuery customerquery)
        {
            CustomerQuery customerQuery1=await GetCustomerQueryAsync(queryId);
            customerQuery1.Description= customerquery.Description;
            customerQuery1.QueryDate=customerquery.QueryDate;
            customerQuery1.Status=customerquery.Status;
        }
    }
}
