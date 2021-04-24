﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPlayground.Entities
{
    [Table("active_cart")]
    public class CartEntity
    {
        [Key] [Column("id")] [JsonIgnore] public int Id { get; set; }

        [Column("user_id")] public long UserId { get; set; }

        [Column("product_id")] public int ProductId { get; set; }
    }
}