using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Interfaces
{
    public interface IIssueRepository : IAsyncRepository<Issue>
    {
        int GetOpenIssueCountOfUser(string userId);
        List<Issue> GetCommentsWithCreatorUsers(int issueId);
    }
}
