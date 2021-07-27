using Microsoft.AspNetCore.Identity;
using System;

namespace Winter.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? LastDateLoggedIn { get; set; }
        //public bool IsDeleted { get; set; }

    }
}
