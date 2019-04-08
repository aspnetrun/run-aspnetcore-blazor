using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class IssueComment : BaseEntity
    {
        [Required]
        public string Message { get; protected set; }
        [Required]
        public int CreatorUserId { get; protected set; }
        public IssueComment([Required] int creatorUserId, [Required] string message)
        {
            Check.NotNull(creatorUserId, nameof(creatorUserId));
            Check.NotNull(message, nameof(message));

            Message = message;
            CreatorUserId = creatorUserId;
        }

        public override string ToString()
        {
            return $"[IssueComment {Id}] {Message}";            
        }
    }
}
