using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
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
            Check.NotNull(creatorUserId, nameof(creatorUserId));
            Check.NotNull(title, nameof(title));

            // Id = Guid.NewGuid().ToString("D");

            CreatorUserId = creatorUserId;
            Title = title;
            Body = body;

            _comments = new Collection<IssueComment>();
        }
    }
}
