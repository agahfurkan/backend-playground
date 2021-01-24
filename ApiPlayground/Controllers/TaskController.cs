using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task = ApiPlayground.Models.Task;

namespace ApiPlayground.Controllers
{
    [ApiController]
    [Route("tasks")]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly DbContextClass _contextClass;

        public TaskController(DbContextClass contextClass)
        {
            _contextClass = contextClass;
        }
        
        [HttpPost("createnewtask")]
        public async Task<IActionResult> PostCreateNewTask([FromBody] Task task)
        {
            if (!ModelState.IsValid) return BadRequest();
            var tempTask = new Task
            {
                DueDate = task.DueDate,
                Message = task.Message,
                ReminderDate = task.ReminderDate,
                Status = task.Status,
                Title = task.Title
            };

            await _contextClass.Tasks.AddAsync(tempTask);
            await _contextClass.SaveChangesAsync();
            return new OkResult();
        }

        [HttpGet]
        public async Task<ActionResult<List<Task>>> Get()
        {
            return await _contextClass.Tasks.ToListAsync();
        }
    }
}