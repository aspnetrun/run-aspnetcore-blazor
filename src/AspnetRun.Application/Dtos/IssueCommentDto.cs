using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Dtos
{
    public class IssueCommentDto : BaseDto
    {
        public string Message { get; set; }
        public UserDto CreatorUser { get; set; }
    }
}
