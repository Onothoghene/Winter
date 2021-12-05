﻿using System;
using System.Collections.Generic;

namespace API.Winter.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            Cart = new HashSet<Cart>();
            OrderRequest = new HashSet<OrderRequest>();
            Wish = new HashSet<Wish>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? DateAdded { get; set; }
        public string AspNetId { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<OrderRequest> OrderRequest { get; set; }
        public virtual ICollection<Wish> Wish { get; set; }
    }
}