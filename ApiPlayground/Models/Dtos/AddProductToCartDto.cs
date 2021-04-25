namespace ApiPlayground.Models.Dtos
{
    public class AddProductToCartDto
    {
        public long UserId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public string Picture { get; set; }
    }
}