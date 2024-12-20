using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZProposalLibrary.Models;

namespace ABZProposalLibrary.RepoAsync
{
    public interface IProposalRepoAsync
    {
        Task InsertProposalAsync(Proposal proposal);
        Task UpdateProposalAsync(string proposalId,Proposal proposal);
        Task DeleteProposalAsync(string proposalId);
        Task<Proposal> GetProposalByIdAsync(string proposalId);
        Task<List<Proposal>> GetProposalByAgentAsync(string agentId);
        Task<List<Proposal>> GetProposalByCustomerAsync(string customerId);
        Task<List<Proposal>> GetProposalByProductAsync(string productId);
        Task<List<Proposal>> GetProposalByVehicleAsync(string regNo);
        Task<List<Proposal>> GetAllProposalsAsync();

    }
}
