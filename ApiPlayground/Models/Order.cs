using System;
using System.ComponentModel.DataAnnotations;

namespace ApiPlayground.Models
{
    public class Order
    {
        
        [Key] 
        public double OrderId { get; set; }
        public double UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public double ProductId { get; set; }
        public double OrderStatusId { get; set; }
    }
}