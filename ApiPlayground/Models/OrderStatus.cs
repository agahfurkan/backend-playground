using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPlayground.Models
{
    [Table("order_status")]
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }
        public string StatusTitle { get; set; }
        public string StatusDescription { get; set; }
        public long OrderId { get; set; }
    }
}