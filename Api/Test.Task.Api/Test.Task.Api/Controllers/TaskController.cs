using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test.Task.Api.Domain.Entities;
using Test.Task.Api.Repository;
using Test.Task.Api.Service.Interfaces;

namespace Test.Task.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {      
        //Se injecta Interaz de TaskService  
        private readonly ITaskService _service;
        public TaskController(ITaskService service)
        {
            _service = service;            
        }
        //Get : para obtener todas las tareas
        [HttpGet("GetTasks")]
        [ProducesResponseType(typeof(List<ETask>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpStatusCode), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpStatusCode), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(HttpStatusCode), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetTasks()
        {
            try
            {
                var result = await _service.GetTasks();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Get : para obtener todas una parea por Id
        [HttpGet("GetTaskById")]
        [ProducesResponseType(typeof(ETask), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpStatusCode), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpStatusCode), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(HttpStatusCode), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetTaskById(int id)
        {
            try
            {
                var result = await _service.GetTaskById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Post : Inserta nueva tarea, y regresa la tarea insertada
        [HttpPost("InsTask")]
        [ProducesResponseType(typeof(ETask), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpStatusCode), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(HttpStatusCode), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> InsTask([FromBody] ETask request)
        {
            try
            {
                var result = await _service.InsTask(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Put : Actualiza una tarea en especifico y regresa si actualizo correctamente
        [HttpPut("UpdTask")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpStatusCode), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpStatusCode), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(HttpStatusCode), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdTask([FromBody] ETask request)
        {
            try
            {
                var result =  await _service.UpdTask(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Delete: borra tarea y regresa una respuesta si se borro correctamente
        [HttpDelete("DelTask")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpStatusCode), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpStatusCode), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(HttpStatusCode), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DelTask(int id)
        {
            try
            {
                var result = await _service.DelTask(id);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
