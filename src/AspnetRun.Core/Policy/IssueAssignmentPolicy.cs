using System;
using System.Collections.Generic;
using System.Text;
using AspnetRun.Core.Entities;

namespace AspnetRun.Core.Policy
{
    public class IssueAssignmentPolicy : IIssueAssignmentPolicy
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IIssueAssignmentConfiguration _configuration;

        public IssueAssignmentPolicy(IIssueRepository issueRepository, IIssueAssignmentConfiguration configuration)
        {
            _issueRepository = issueRepository ?? throw new ArgumentNullException(nameof(issueRepository));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void CheckAssignment(Issue issue, User user)
        {
            throw new NotImplementedException();
        }
    }
}
