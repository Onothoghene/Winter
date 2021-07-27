using System;
using System.Collections.Generic;

namespace Winter.Models
{
    public partial class UserRoles
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public long UserId { get; set; }

        public ApplicationRoles Role { get; set; }
        public UserProfile User { get; set; }
    }
}
