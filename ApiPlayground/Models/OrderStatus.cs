using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPlayground.Models
{
    [Table("order_status")]
    public class OrderStatus
    {
        [Key]
        public double OrderStatusId { get; set; }
        public string StatusTitle { get; set; }
        public string StatusDescription { get; set; }
        public double OrderId { get; set; }
    }
}