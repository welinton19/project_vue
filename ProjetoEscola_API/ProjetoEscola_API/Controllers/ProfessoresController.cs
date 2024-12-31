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
        public IRepository _reppor { get; }
        public ProfessoresController(IRepository reppor)
        {
            _reppor = reppor;
            
        }
        [HttpGet]
        public async Task <IActionResult> get()
        {
            try:{
              var result = await _reppor.GetAllProfessoresAsync(true);
              return Ok(result);
              
            }
            catch(System.Exception){
              return this.StatusCode(StatusCode.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }
        [HttpGet("Professorid}")]
        public async Task <IActionResult> get(int Professorid)
        {
            try:{
              var result = await _reppor.GetProfessorByIdAsync(Professorid, true);
              return Ok(result);
              
            }
            catch(System.Exception){
              return this.StatusCode(StatusCode.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }
        [HttpPost]
        public async Task <IActionResult> post(Professor model)
        {
            try:{

              _reppor.Add(model)

              if (await _reppor.SaveChangesAsync()){
                 return Created($"/api/professor/{model.id}", model);
                
              }
              
            }
            catch(System.Exception){
              return this.StatusCode(StatusCode.Status500InternalServerError, "Banco de Dados Falhou");
            }
            return BadRequest("Professor não cadastrado");
        }
        [HttpPut("Professorid}")]
        public async Task <IActionResult> put(int Professorid)
        {
            try:{
              var Professor = await _reppor.GetProfessorByIdAsync(Professorid, false);
              if (Professor == null)
                return NotFound();
              _reppor.Update(Professor);
              if (await _reppor.SaveChangesAsync()){
                 return NoContent();
                
              }
            }
            catch(System.Exception){
              return this.StatusCode(StatusCode.Status500InternalServerError, "Banco de Dados Falhou");
            }
            return BadRequest("Professor não atualizado");
        }
        [HttpDelete("Professorid}")]
        public async Task <IActionResult> delet(int Professorid)
        {
            try:{
              var Professor = await _reppor.GetProfessorByIdAsync(Professorid, false);
              if (Professor == null)
                return NotFound();
              _reppor.Delete(Professor);
              if (await _reppor.SaveChangesAsync()){
                 return NoContent();
                
              }
            }
            catch(System.Exception){
              return this.StatusCode(StatusCode.Status500InternalServerError, "Banco de Dados Falhou");
            }
            return BadRequest("Professor não deletado");
        }
       
    }
}