using System;
using System.Collections.Generic;

namespace Winter.Models
{
    public partial class AdditionalInfo
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public string Address { get; set; }
        public string AdditionalPhoneNumber { get; set; }
        public DateTime DateAdded { get; set; }
        public bool? Isdeleted { get; set; }
        public DateTime? DateDeleted { get; set; }

        public UserProfile User { get; set; }
    }
}
