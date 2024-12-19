using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZClaimsLibrary.Models;

namespace ABZClaimsLibrary.RepoAsync
{
    public interface IClaimRepoAsync
    {
        Task InsertClaimAsync(Claim claim);
        Task UpdateClaimAsync(string claimNo,Claim claim);
        Task DeleteClaimAsync(string claimNo);
        Task<Claim> GetClaimByNoAsync(string claimNo);
        Task<List<Claim>> GetClaimsByPolicyNoAsync(string policyNo);
        Task<List<Claim>> GetAllClaimAsync();
    }
}
