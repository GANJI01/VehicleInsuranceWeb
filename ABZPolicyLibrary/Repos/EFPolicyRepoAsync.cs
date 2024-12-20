using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZPolicyLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ABZPolicyLibrary.Repos
{
    public class EFPolicyRepoAsync : IPolicyRepoAsync
    {
        ABZPolicyDBContext ctx = new ABZPolicyDBContext();
        public async Task DeletePolicyAsync(string policyNo)
        {
            Policy policy = await GetPolicyAsync(policyNo);
            ctx.Policies.Remove(policy);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<Policy>> GetAllPoliciesAsync()
        {
            List<Policy> policies = await ctx.Policies.ToListAsync();
            return policies;
        }

        public async Task<Policy> GetPolicyAsync(string policyNo)
        {
            try
            {
                Policy policy = await (from poli in ctx.Policies where poli.PolicyNo == policyNo select poli).FirstAsync();
                return policy;
            }
            catch
            {
                throw new Exception("Invalid PolicyNo");
            }
        }

        public async Task InsertPolicyAsync(Policy policy)
        {
            await ctx.Policies.AddAsync(policy);
            await ctx.SaveChangesAsync();

        }
        public async Task UpdatePolicyAsync(string policyNo, Policy policy)
        {
            Policy policy1 = await GetPolicyAsync(policyNo);
            policy1.NoClaimBonus = policy.NoClaimBonus;
            policy1.ReceiptNo = policy.ReceiptNo;
            policy1.ReceiptDate = policy.ReceiptDate;
            policy1.PaymentMode = policy.PaymentMode;
            policy1.Amount = policy.Amount;
            await ctx.SaveChangesAsync();

        }
    }
}
