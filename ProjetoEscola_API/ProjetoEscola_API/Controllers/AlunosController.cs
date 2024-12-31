using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola_API.Controllers
{
    [Router("api/[controller]")]
    [ApiController]
    public class AlunosController: Controllers
    {
        public AlunosController()
        {
            
        }
        [HttpGet]
        public IActionResult get()
        {
            return Ok();
        }
        [HttpGet("{Alunoid}")]
        public IActionResult get(int Alunoid)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult post()
        {
            return Ok();
        }
        [HttpPut("{Alunoid}")]
        public IActionResult put(int Alunoid)
        {
            return Ok();
        }
        [HttpDelete("{Alunoid}")]
        public IActionResult delet(int Alunoid)
        {
            return Ok();
        }
    }
}