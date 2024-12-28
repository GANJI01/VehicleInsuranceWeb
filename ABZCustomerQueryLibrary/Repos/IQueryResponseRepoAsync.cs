using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABZCustomerQueryLibrary.Models;

namespace ABZCustomerQueryLibrary.Repos
{
    public interface IQueryResponseRepoAsync
    {
        Task InsertQueryResponseAsync(QueryResponse queryresponse);
        Task DeleteQueryResponseAsync(string queryId, string srNo);
        Task UpdateQueryResponseAsync(string queryId, string srNo, QueryResponse queryresponse);
        Task<List<QueryResponse>> GetAllQuerysAsync();
        Task<QueryResponse> GetQueryResponseAsync(string queryId, string srNo);
        Task<List<QueryResponse>> GetQueryResponseByCustomerQueryAsync(string queryId);
        Task InsertAgentAsync(Agent agent);
        Task<List<QueryResponse>> GetQueryResponseByAgentAsync(string agentID);
    }
}
