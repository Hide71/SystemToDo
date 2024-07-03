using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemToDo.Models;

namespace SystemToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UsuarioModel>> BuscarTodos()
        {
            return Ok();
        }
    }
}
