using System.Collections.Generic;
using System.Linq;
using ApiPlayground.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPlayground.Controllers
{
    [ApiController]
    [Route("OrderStatus")]
    [Authorize]
    public class OrderStatusController : ControllerBase
    {
        private readonly DbContextClass _contextClass;

        public OrderStatusController(DbContextClass contextClass)
        {
            _contextClass = contextClass;
        }

        [HttpGet]
        public List<OrderStatusEntity> getOrderStatus()
        {
            return _contextClass.OrderStatus.ToList();
        }
    }
}