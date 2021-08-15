using System;
using System.Collections.Generic;

namespace Winter.Models
{
    public partial class ApplicationRoles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
