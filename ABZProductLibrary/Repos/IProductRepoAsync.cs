using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZProductLibrary.Models;

namespace ABZProductLibrary.Repos
{
    public interface IProductRepoAsync
    {
        Task InsertProductAsync(Product product);
        Task DeleteProductAsync(string productID);
        Task UpdateProductAsync(string productID, Product product);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(string productID);
    }
}
