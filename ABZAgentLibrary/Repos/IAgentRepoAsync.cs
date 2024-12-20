using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZAgentLibrary.Models;

namespace ABZAgentLibrary.Repos
{
    public interface IAgentRepoAsync
    {
        Task InsertAgentAsync(Agent agent);
        Task UpdateAgentAsync(string agentId, Agent agent);
        Task DeleteAgentAsync(string agentId);
        Task<Agent> GetAgentByIDAsync(string agentId);
        Task<List<Agent>> GetAllAgentsAsync();
    }
}
