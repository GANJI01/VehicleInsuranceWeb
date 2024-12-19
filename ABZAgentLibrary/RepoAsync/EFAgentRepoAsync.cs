using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZAgentLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ABZAgentLibrary.Repos
{
    public class EFAgentRepoAsync : IAgentRepoAsync
    {
        ABZAgentDBContext ctx = new ABZAgentDBContext();
        public async Task DeleteAgentAsync(string agentId)
        {
            Agent agent = await GetAgentByIDAsync(agentId);
            ctx.Agents.Remove(agent);
            await ctx.SaveChangesAsync();
        }

        public async Task<Agent> GetAgentByIDAsync(string agentId)
        {
            try
            {
                Agent agent = await (from a in ctx.Agents where a.AgentID == agentId select a).FirstAsync();
                return agent;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<Agent>> GetAllAgentsAsync()
        {
            List<Agent> agentList = await ctx.Agents.ToListAsync();
            return agentList;
        }

        public async Task InsertAgentAsync(Agent agent)
        {
            await ctx.Agents.AddAsync(agent);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateAgentAsync(string agentId, Agent agent)
        {
            Agent agent1 = await GetAgentByIDAsync(agentId);
            agent1.AgentName = agent.AgentName;
            agent1.AgentPhone = agent.AgentPhone;
            agent1.AgentEmail = agent.AgentEmail;
            await ctx.SaveChangesAsync();
        }
    }
}
