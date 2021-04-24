using System;
using System.ComponentModel.DataAnnotations;

namespace ApiPlayground.Entities
{
    public class Order
    {
        [Key] public long OrderId { get; set; }

        public long UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public int OrderStatusId { get; set; }
    }
}