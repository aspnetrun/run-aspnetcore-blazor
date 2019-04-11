using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspnetRun.Application.Dtos.Issue
{
    public class AssignIssueToUserInput
    {
        [Required]
        [MaxLength(128)]
        public int IssueId { get; set; }

        [Required]
        [MaxLength(128)]
        public int UserId { get; set; }
    }
}
