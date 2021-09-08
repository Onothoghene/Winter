﻿using System;
using System.Collections.Generic;

namespace Winter.API.Models
{
    public partial class AdditionalInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public string AdditionalPhoneNumber { get; set; }
        public DateTime? DateAdded { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }

        public UserProfile User { get; set; }
    }
}