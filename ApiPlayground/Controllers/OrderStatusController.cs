using System.Collections.Generic;
using System.Threading.Tasks;
using ApiPlayground.Entities;
using ApiPlayground.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPlayground.Controllers
{
    [ApiController]
    [Route("OrderStatus")]
    [Authorize]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusRepository _iOrderStatusRepository;

        public OrderStatusController(IOrderStatusRepository iOrderStatusRepository)
        {
            _iOrderStatusRepository = iOrderStatusRepository;
        }

        [HttpGet]
        public async Task<List<OrderStatusEntity>> GetOrderStatus()
        {
            return await _iOrderStatusRepository.GetAllAsync();
        }
    }
}