using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZQueryLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ABZQueryLibrary.Repos
{
    public class EFCustomerQueryRepoAsync:ICustomerQueryRepoAsync
    {
        ABZQueryDBContext ctx=new ABZQueryDBContext();

        public async Task DeleteCustomerQueryAsync(string queryId)
        {
            CustomerQuery customerquery=await GetCustomerQueryAsync(queryId);
            ctx.CustomerQueries.Remove(customerquery);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<CustomerQuery>> GetAllCustomerQueriesAsync()
        {
            List<CustomerQuery> customerqueries=await ctx.CustomerQueries.ToListAsync();
            return customerqueries;
        }

        public async Task<CustomerQuery> GetCustomerQueryAsync(string queryId)
        {
            try
            {
                CustomerQuery customerquery = await (from cq in ctx.CustomerQueries where queryId == cq.QueryID select cq).FirstAsync();
                return customerquery;
            }
            catch (Exception ex)
            {
                throw new Exception("No such QueryId exist");
            }
        }

        public async Task<List<CustomerQuery>> GetCustomerQueryByCustomerAsync(string customerId)
        {
            List<CustomerQuery> customerqueries=await (from cq in ctx.CustomerQueries where customerId==cq.QueryID select cq).ToListAsync();
            if(customerqueries.Count == 0)
            {
                throw new Exception("No such CustomerId exist");
            }
            else
            {
                return customerqueries;
            }
        }

        public async Task InsertCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task InsertCustomerQueryAsync(CustomerQuery customerquery)
        {
            await ctx.CustomerQueries.AddAsync(customerquery);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateCustomerQueryAsync(string queryId, CustomerQuery customerquery)
        {
            CustomerQuery customerquery1=await GetCustomerQueryAsync(queryId);
            customerquery1.Description= customerquery.Description;
            customerquery1.QueryDate= customerquery.QueryDate;
            customerquery1.Status= customerquery.Status;
            await ctx.SaveChangesAsync();
        }
    }
}
