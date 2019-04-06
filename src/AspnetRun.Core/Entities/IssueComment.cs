using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class IssueComment : BaseEntity
    {
        public string Message { get; set; }
        public int CreatorUserId { get; set; }
        public IssueComment(int creatorUserId, string message)
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
