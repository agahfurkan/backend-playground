﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiPlayground.Models
{
    public class Product
    {
        [Key]
        [JsonIgnore]
        [Column("product_id")]
        public double ProductId { get; set; }
        [Column("product_name")]
        public string ProductName { get; set; }
        [Column("product_description")]
        public string ProductDescription { get; set; }
        public double Price { get; set; }
        [Column("category_id")]
        public double CategoryId { get; set; }
        public double Discount { get; set; }
        public string Picture { get; set; }
    }
}