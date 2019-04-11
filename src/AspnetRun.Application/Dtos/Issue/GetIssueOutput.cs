using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Dtos.Issue
{
    public class GetIssueOutput
    {
        public IssueDto Issue { get; set; }
        public List<IssueCommentDto> Comments { get; set; }
    }
}
