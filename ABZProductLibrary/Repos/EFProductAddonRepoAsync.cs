using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZProductLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ABZProductLibrary.Repos
{
    public class EFProductAddonRepoAsync : IProductAddonRepoAsync
    {
        ABZProductDBContext ctx=new ABZProductDBContext();
        public async Task DeleteProductAddonAsync(string productID, string addonId)
        {
            ProductAddon productAddon = await GetProductAddonAsync(productID, addonId);
            ctx.ProductAddons.Remove(productAddon);
            await ctx.SaveChangesAsync();
        }
        public async Task<List<ProductAddon>> GetAllProductAddonAsync()
        {
            List<ProductAddon> productAddons = await ctx.ProductAddons.ToListAsync();
            return productAddons;
        }

        public async Task<ProductAddon> GetProductAddonAsync(string productID, string addonId)
        {
            try
            {
                ProductAddon productAddon = await (from proadd in ctx.ProductAddons where proadd.ProductID == productID && proadd.AddonID == addonId select proadd).FirstAsync();
                return productAddon;
            }
            catch
            {
                throw new Exception("Invalid ProductID or AddonID");
            }
        }

        public async Task InsertProductAddonAsync(ProductAddon productAddon)
        {
            await ctx.ProductAddons.AddAsync(productAddon);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateProductAddonAsync(string productID, string addonId, ProductAddon productAddon)
        {
            ProductAddon productAddon1 = await GetProductAddonAsync(productID, addonId);
            productAddon1.AddonDescription = productAddon.AddonDescription;
            productAddon1.AddonTitle = productAddon.AddonTitle;
            await ctx.SaveChangesAsync();
        }
    }
}
