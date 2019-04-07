using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Policy
{
    public interface IIssueAssignmentPolicy
    {
        void CheckAssignment(Issue issue, User user);
    }
}
