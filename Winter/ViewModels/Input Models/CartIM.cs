﻿using System;

namespace Winter.ViewModels.Input_Models
{
    public class CartIM
    {
        public int ProductId { get; set; }
        public long UserId { get; set; }
        public int Quantity { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
