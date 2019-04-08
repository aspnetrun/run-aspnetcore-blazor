using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Policy
{
    public interface IIssueAssignmentConfiguration
    {
        int MaxConcurrentOpenIssueCountForAUser { get; set; }
    }
}
