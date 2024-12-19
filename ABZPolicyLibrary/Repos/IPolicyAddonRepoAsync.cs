using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZPolicyLibrary.Models;

namespace ABZPolicyLibrary.Repos
{
    public interface IPolicyAddonRepoAsync
    {
        Task InsertPolicyAddonAsync(PolicyAddon policyAddon);
        Task DeletePolicyAddonAsync(string policyNo,string addonId);
        Task<List<PolicyAddon>> GetAllPolicyAddonAsync();
        Task<PolicyAddon> GetPolicyAddonAsync(string policyNo,string addonId);
        Task UpdatePolicyAddonAsync(string policyNo,string addonId,PolicyAddon policyAddon);

    }
}
