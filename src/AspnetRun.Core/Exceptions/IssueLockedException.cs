using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Exceptions
{
    public class IssueLockedException : CoreException
    {
        public int IssueId { get; }

        public IssueLockedException(int issueId)
            : base(issueId.ToString())
        {
            IssueId = issueId;
        }
    }
}
