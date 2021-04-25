namespace ApiPlayground.Models
{
    public class GetProductDetailResponse : GenericResponseModel
    {
        public ProductDetail ProductDetail { get; set; }
    }
    public class ProductDetail
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