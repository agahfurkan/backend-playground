using System.ComponentModel.DataAnnotations;

namespace ApiPlayground.Models
{
    public class Product
    {
        [Key] public double ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Price { get; set; }
        public double CategoryId { get; set; }
        public double Discount { get; set; }
        public string Picture { get; set; }
    }
}