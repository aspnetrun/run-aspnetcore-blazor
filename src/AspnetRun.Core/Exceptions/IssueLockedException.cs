using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Exceptions
{
    public class IssueLockedException : CoreException
    {
        public string IssueId { get; }

        public IssueLockedException(string issueId)
            : base(issueId)
        {
            IssueId = issueId;
        }
    }
}
