using System;
using System.Collections.Generic;

namespace Winter.Models
{
    public partial class ApplicationRoles
    {
        public ApplicationRoles()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
