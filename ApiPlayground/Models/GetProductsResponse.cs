using System.Collections.Generic;

namespace ApiPlayground.Models
{
    public class GetProductsResponse : GenericResponseModel
    {
        public List<Product> ProductList { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public double Discount { get; set; }
        public string Picture { get; set; }
    }
}