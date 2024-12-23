using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZProductLibrary.Models;

namespace ABZProductLibrary.Repos
{
    public interface IProductAddonRepoAsync
    {
        Task InsertProductAddonAsync(ProductAddon productAddon);
        Task UpdateProductAddonAsync(string productID, string addonId, ProductAddon productAddon);
        Task DeleteProductAddonAsync(string productID, string addonId);
        Task<List<ProductAddon>> GetAllProductAddonAsync();
        Task<ProductAddon> GetProductAddonAsync(string productID, string addonId);
        Task<List<ProductAddon>> GetProductAddonByProductAsync(string productID);

    }
}
