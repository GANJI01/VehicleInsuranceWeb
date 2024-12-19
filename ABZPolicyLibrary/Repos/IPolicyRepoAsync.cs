using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZPolicyLibrary.Models;

namespace ABZPolicyLibrary.Repos
{
    public interface IPolicyRepoAsync
    {
        Task InsertPolicyAsync(Policy policy);
        Task DeletePolicyAsync(string policyNo);
        Task UpdatePolicyAsync(string policyNo,Policy policy);
        Task<List<Policy>> GetAllPoliciesAsync();
        Task<Policy> GetPolicyAsync(string policyNo);
    }
}
