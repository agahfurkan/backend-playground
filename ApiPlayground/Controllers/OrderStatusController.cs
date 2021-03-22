using ApiPlayground.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPlayground.Controllers
{
    [ApiController]
    [Route("OrderStatus")]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly DbContextClass _contextClass;

        public TaskController(DbContextClass contextClass)
        {
            _contextClass = contextClass;
        }

        [HttpGet]
        public List<OrderStatus> getOrderStatus()
        {
            return _contextClass.OrderStatus.ToList();
        }
    }
}