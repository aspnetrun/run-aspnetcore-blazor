using System;
using System.Collections.Generic;
using System.Text;
using AspnetRun.Core.Entities;

namespace AspnetRun.Core.Policy
{
    public class IssueAssignmentPolicy : IIssueAssignmentPolicy
    {
        public void CheckAssignment(Issue issue, User user)
        {
            throw new NotImplementedException();
        }
    }
}
