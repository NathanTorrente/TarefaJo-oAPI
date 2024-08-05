using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace tarefa11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        [HttpGet("Minhas Tarefas")]
        public IActionResult Get()
        {
            return Ok("Tarefas: Emprededorismo, Matemática, Saúde e Segurança de Trabalho");
        }
    }
}
