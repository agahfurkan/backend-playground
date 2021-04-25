using System.ComponentModel.DataAnnotations;
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
        [Column("product_name")] public string ProductName { get; set; }
        [Column("product_description")] public string ProductDescription { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public string Picture { get; set; }
    }
}