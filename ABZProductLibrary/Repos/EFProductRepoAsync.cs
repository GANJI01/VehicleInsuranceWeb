using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZProductLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ABZProductLibrary.Repos
{
    public class EFProductRepoAsync : IProductRepoAsync
    {
        ABZProductDBContext ctx=new ABZProductDBContext();
        public async Task DeleteProductAsync(string productID)
        {
            Product product = await GetProductAsync(productID);
            ctx.Products.Remove(product);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            List<Product> products = await ctx.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductAsync(string productID)
        {
            try
            {
                Product product = await(from pro in ctx.Products where pro.ProductID == productID select pro).FirstAsync();
                return product;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task InsertProductAsync(Product product)
        {
            await ctx.Products.AddAsync(product);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(string productID, Product product)
        {
            Product product1 = await GetProductAsync(productID);
            product1.ProductUIN = product.ProductUIN;
            product1.ProductName = product.ProductName;
            product1.ProductDescription = product.ProductDescription;
            product1.InsuredInterests = product.InsuredInterests;
            product1.PolicyCoverage = product.PolicyCoverage;
            ctx.SaveChangesAsync();
        }
    }
}
