using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspnetRun.Application.Dtos.Issue
{
    public class AddCommentInput
    {
        [Required]
        [MaxLength(128)]
        public int IssueId { get; set; }

        [Required]
        [MaxLength(65536)]
        public string Message { get; protected set; }
    }
}
