using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Dtos
{
    public class IssueDto : BaseDto
    {        
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsClosed { get; set; }
        public bool IsLocked { get; set; }
        public string CloseReason { get; set; }
        public UserDto CreatorUser { get; set; }
    }
}
