using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola_API.Controllers
{
    [Router("api/[controller]")]
    [ApiController]
    public class ProfessoresController : controller
    {
        public ProfessoresController()
        {
            
        }
        [HttpGet]
        public IActionResult get()
        {
            return Ok();
        }
        [HttpGet("Professorid}")]
        public IActionResult get(int Professorid)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult post()
        {
            return Ok();
        }
        [HttpPut("Professorid}")]
        public IActionResult put(int Professorid)
        {
            return Ok();
        }
        [HttpDelete("Professorid}")]
        public IActionResult delet(int Professorid)
        {
            return Ok();
        }
       
    }
}