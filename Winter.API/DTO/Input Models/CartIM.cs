﻿using System;

namespace Winter.API.DTO.Input_Models
{
    public class CartIM
    {
        public int ProductId { get; set; }
        public long UserId { get; set; }
        public int Quantity { get; set; }

        public DateTime DateAdded { get; set; }
    }
}