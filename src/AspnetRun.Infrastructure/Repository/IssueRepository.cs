using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AspnetRun.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Infrastructure.Repository
{
    public class IssueRepository : AspnetRunRepository<Issue>, IIssueRepository
    {
        public IssueRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }

        public List<Issue> GetCommentsWithCreatorUsers(int issueId)
        {
            throw new NotImplementedException();
        }

        public int GetOpenIssueCountOfUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
