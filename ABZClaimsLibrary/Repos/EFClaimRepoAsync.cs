using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZClaimsLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace ABZClaimsLibrary.RepoAsync
{
    public class EFClaimRepoAsync : IClaimRepoAsync
    {
        ABZClaimDBContext ctx = new ABZClaimDBContext();

        public async Task DeleteClaimAsync(string claimNo)
        {
            Claim claim = await GetClaimByNoAsync(claimNo);
            ctx.Claims.Remove(claim);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<Claim>> GetAllClaimAsync()
        {
            List<Claim> claims = await ctx.Claims.ToListAsync();
            return claims;
        }

        public async Task<Claim> GetClaimByNoAsync(string claimNo)
        {

            try
            {
                Claim claim = await (from c in ctx.Claims
                                     where c.ClaimNo == claimNo
                                     select c).FirstAsync();
                return claim;

                if (claim == null)
                {
                    throw new KeyNotFoundException($"No claim found with ClaimNo: {claimNo}");
                }
                return claim;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Claim>> GetClaimsByPolicyNoAsync(string policyNo)
        {
            List<Claim> claims = await (from c in ctx.Claims
                                        where c.PolicyNo == policyNo
                                        select c).ToListAsync();
            if (claims.Count == 0)
                throw new Exception("No such customer id");
            else
                return claims;
           
        }

        public async Task InsertClaimAsync(Claim claim)
        {
            await ctx.Claims.AddAsync(claim);
            await ctx.SaveChangesAsync();
        }

        public async Task InsertPolicyAsync(Policy policy)
        {
            await ctx.Policies.AddAsync(policy);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateClaimAsync(string claimNo,Claim claim)
        {
            Claim claim1 = await GetClaimByNoAsync(claimNo);
            claim1.ClaimAmount = claim.ClaimAmount;
            claim1.ClaimDate = claim.ClaimDate;
            claim1.ClaimStatus = claim.ClaimStatus;
            claim1.IncidentDate = claim.IncidentDate;
            claim1.IncidentLocation = claim.IncidentLocation;
            claim1.IncidentDescription = claim.IncidentDescription;
            claim1.SurveyorName = claim.SurveyorName;
            claim1.SurveyorPhone = claim.SurveyorPhone;
            claim1.SurveyDate = claim.SurveyDate;
            claim1.SurveyDescription = claim.SurveyDescription;
            await ctx.SaveChangesAsync();
        }
    }
}
