using System.ComponentModel.DataAnnotations;

namespace ApiPlayground.Models
{
    public class OrderStatus
    {
        [Key] public double OrderStatusId { get; set; }
        public string StatusTitle { get; set; }
        public string StatusDescription { get; set; }
        public double OrderId { get; set; }
    }
}