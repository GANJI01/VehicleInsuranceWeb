using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZCustomerLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ABZCustomerLibrary.RepoAsync
{
    public class EFCustomerAsync : ICustomerRepoAsync
    {
        ABZCustomerDBContext ctx = new ABZCustomerDBContext();
        public async Task DeleteCustomerAsync(string customerId)
        {
            Customer custdel=await GetCustomerByIdAsync(customerId);
            ctx.Customers.Remove(custdel);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            List<Customer> customers = await ctx.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerByIdAsync(string customerId)
        {
            try
            {
                Customer customer=await ( from c in ctx.Customers where c.CustomerID == customerId select c).FirstAsync();
                return customer;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task InsertCustomerAsync(Customer customer)
        {
            await ctx.Customers.AddAsync(customer);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(string customerId, Customer customer)
        {
            Customer custedit= await GetCustomerByIdAsync(customerId);
            custedit.CustomerPhone= customer.CustomerPhone;
            custedit.CustomerName= customer.CustomerName;
            custedit.CustomerEmail= customer.CustomerEmail;
            custedit.CustomerAddress= customer.CustomerAddress;
            await ctx.SaveChangesAsync();
        }
    }
}
