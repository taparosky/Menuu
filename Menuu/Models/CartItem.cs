﻿using System.ComponentModel.DataAnnotations;

namespace Menuu.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public Snack Snack { get; set; }
        public int Quantity { get; set; }
        [StringLength(200)]
        public string CartId { get; set; }
    }
}
