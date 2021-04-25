using System.Collections.Generic;

namespace ApiPlayground.Models
{
    public class GetUserCartResponse : GenericResponseModel
    {
        public List<UserCart> CartList { get; set; }
    }

    public class UserCart
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public string Picture { get; set; }
    }
}