using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Notification
{
    public interface IUserEmailer
    {
        void IssueAssigned(User user, Issue issue);
        void AddedIssueComment(User user, Issue issue, IssueComment comment);
    }
}
