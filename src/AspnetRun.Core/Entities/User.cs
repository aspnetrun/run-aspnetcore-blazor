using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string UserName { get; protected set; }

        public User([Required] string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }

        public override string ToString()
        {
            return $"[User {Id}] {UserName}";
        }
    }
}
