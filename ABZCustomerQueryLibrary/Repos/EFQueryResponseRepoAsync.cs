using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZCustomerQueryLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ABZCustomerQueryLibrary.Repos
{
    public class EFQueryResponseRepoAsync : IQueryResponseRepoAsync
    {
        ABZQueryDBContext ctx = new ABZQueryDBContext();
        public async Task DeleteQueryResponseAsync(string queryID, string srNo)
        {
            QueryResponse qr = await GetQueryResponseAsync(queryID, srNo);
            ctx.QueryResponses.Remove(qr);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<QueryResponse>> GetAllQuerysAsync()
        {
            List<QueryResponse> qr = await ctx.QueryResponses.ToListAsync();
            return qr;
        }

        public async Task<QueryResponse> GetQueryResponseAsync(string queryID, string srNo)
        {
            try
            {
                QueryResponse qe = await (from q in ctx.QueryResponses where q.SrNo == srNo && q.QueryID == queryID select q).FirstAsync();
                return qe;
            }
            catch (Exception)
            {
                throw new Exception("Invalid SrNo");
            }
        }

        public async Task<List<QueryResponse>> GetQueryResponseByCustomerQuery(string queryId)
        {
            List<QueryResponse> qrs = await (from q in ctx.QueryResponses where q.QueryID == queryId select q).ToListAsync();
            if (qrs.Count == 0)
            {
                throw new Exception("No such queryID");
            }
            else
            {
                return qrs;
            }
        }

        public async Task InsertAgentAsync(Agent agent)
        {
            await ctx.Agents.AddAsync(agent);
            await ctx.SaveChangesAsync();
        }

        public async Task InsertCustomerQueryAsync(CustomerQuery customerquery)
        {
            await ctx.CustomerQueries.AddAsync(customerquery);
            await ctx.SaveChangesAsync();
        }

        public async Task InsertQueryResponseAsync(QueryResponse queryresponse)
        {
            await ctx.QueryResponses.AddAsync(queryresponse);
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateQueryResponseAsync(string queryID, string srNo, QueryResponse queryresponse)
        {
            QueryResponse qr = await GetQueryResponseAsync(queryID, srNo);
            qr.ResponseDate = queryresponse.ResponseDate;
            qr.Description = queryresponse.Description;
            await ctx.SaveChangesAsync();
        }
    }
}
