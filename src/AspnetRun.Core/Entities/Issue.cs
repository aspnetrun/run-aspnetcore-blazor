using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        public int CreatorUserId { get; set; }
        public int AssignedUserId { get; set; }

        public IReadOnlyList<IssueComment> Comments => _comments.ToImmutableList();
        protected virtual ICollection<IssueComment> _comments { get; set; }

        protected Issue()
        {

        }

        public Issue(int creatorUserId, string title, string body = null)
        {

        }
    }
}
