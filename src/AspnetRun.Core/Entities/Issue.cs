using AspnetRun.Core.Policy;
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
        public int CreatorUserId { get; protected set; }
        public int AssignedUserId { get; protected set; }

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

        public void AssignTo([Required] User user, [Required] IIssueAssignmentPolicy policy)
        {
            Check.NotNull(user, nameof(user));
            Check.NotNull(policy, nameof(policy));

            policy.CheckAssignment(this, user);

            AssignedUserId = user.Id;
        }

        public void ClearAssignment()
        {
            AssignedUserId = 0;
        }

        public IssueComment AddComment(User creatorUser, string message)
        {
            Check.NotNull(creatorUser, nameof(creatorUser));

            if (IsLocked)
            {
                throw new IssueLockedException(Id);
            }

            var comment = new IssueComment(creatorUser.Id, message);
            _comments.Add(comment);
            return comment;
        }

    }
}
