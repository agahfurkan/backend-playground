using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPlayground.Controllers
{
    [ApiController]
    [Route("orderStatus")]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly DbContextClass _contextClass;

        public TaskController(DbContextClass contextClass)
        {
            _contextClass = contextClass;
        }
    }
}