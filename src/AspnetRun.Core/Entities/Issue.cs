using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class Issue : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsClosed { get; set; }
        public bool IsLocked { get; set; }
        public IssueCloseReason? CloseReason { get; set; }

    }
}
