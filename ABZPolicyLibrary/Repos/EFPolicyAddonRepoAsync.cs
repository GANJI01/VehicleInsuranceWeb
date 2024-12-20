using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZPolicyLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ABZPolicyLibrary.Repos
{
    public class EFPolicyAddonRepoAsync : IPolicyAddonRepoAsync
    {
        ABZPolicyDBContext ctx = new ABZPolicyDBContext();
        public async Task DeletePolicyAddonAsync(string policyNo, string addonId)
        {
            PolicyAddon policyAddon = await GetPolicyAddonAsync(policyNo, addonId);
            ctx.PolicyAddons.Remove(policyAddon);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<PolicyAddon>> GetAllPolicyAddonAsync()
        {
            List<PolicyAddon> policyAddons = await ctx.PolicyAddons.ToListAsync();
            return policyAddons;
        }

        public async Task<PolicyAddon> GetPolicyAddonAsync(string policyNo, string addonId)
        {
            try
            {
                PolicyAddon policyAddon = await (from poliadd in ctx.PolicyAddons where poliadd.PolicyNo == policyNo && poliadd.AddonID == addonId select poliadd).FirstAsync();
                return policyAddon;
            }
            catch
            {
                throw new Exception("Invalid PolicyNo or AddonID");
            }

        }

        public async Task InsertPolicyAddonAsync(PolicyAddon policyAddon)
        {
            await ctx.PolicyAddons.AddAsync(policyAddon);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdatePolicyAddonAsync(string policyNo, string addonId, PolicyAddon policyAddon)
        {
            PolicyAddon policyAddon1 = await GetPolicyAddonAsync(policyNo, addonId);
            policyAddon1.Amount = policyAddon.Amount;
            await ctx.SaveChangesAsync();
        }
    }
}
