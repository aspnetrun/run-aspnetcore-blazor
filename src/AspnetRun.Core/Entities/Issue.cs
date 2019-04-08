﻿using AspnetRun.Core.Exceptions;
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
        public string Title { get; protected set; }
        public string Body { get; protected set; }
        public bool IsClosed { get; protected set; }
        public bool IsLocked { get; protected set; }
        public IssueCloseReason? CloseReason { get; protected set; }
        [Required]
        public int CreatorUserId { get; protected set; }
        [Required]
        public int AssignedUserId { get; protected set; }
        public IReadOnlyList<IssueComment> Comments => _comments.ToImmutableList();
        protected virtual ICollection<IssueComment> _comments { get; set; }

        protected Issue()
        {
        }

        public Issue([Required] int creatorUserId, [Required] string title, string body = null)
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

        public IssueComment AddComment([Required] User creatorUser, [Required] string message)
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

        public void Close(IssueCloseReason reason)
        {
            CloseReason = reason;
            IsClosed = true;
        }

        public void ReOpen()
        {
            IsClosed = false;
            CloseReason = null;
        }

        public void Lock()
        {
            if (!IsClosed)
            {
                throw new InvalidOperationException("An open issue can not be locked. Should be closed first!");
            }

            IsLocked = true;
        }

        public void Unlock()
        {
            IsLocked = false;
        }

        public override string ToString()
        {
            return $"[Issue {Id}] {Title}";
        }
    }
}
