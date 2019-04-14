using AspnetRun.Application.Dtos;
using AspnetRun.Application.Dtos.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.ViewModel
{
    public class IssueDetailViewModel : GetIssueOutput
    {
        public int CurrentUserId { get; set; }

        public string GetStateText()
        {
            if (Issue.IsClosed)
            {
                return "Closed (" + Issue.CloseReason + ")";
            }
            else
            {
                return "Open";
            }
        }

        public bool CanDeleteComment(IssueCommentDto comment)
        {
            return comment.CreatorUser.Id == CurrentUserId;
        }
    }
}
