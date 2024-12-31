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
        public IRepository _reppor { get; }
        public AlunosController(IRepository reppor)
        {
            _reppor = reppor;
            
        }
        [HttpGet]
        public async Task <IActionResult> GetAllAlunosAsync()
        {
            try:{
              var result = await _reppor.GetAllAlunosAsync(true);
              return Ok(result);
            }
            catch(System.Exception){
              return this.StatusCode(StatusCode.Status500InternalServerError, "Banco de Dados Falhou");
            }
            
        }
        [HttpGet("{Alunoid}")]
        public async Task <IActionResult> GetAlunoByIdAsync(int Alunoid)
        {
            try:{
              var result = await _reppor.GetAlunoByIdAsync(Alunoid, true);
              return Ok(result);
            }
            catch(System.Exception){
              return this.StatusCode(StatusCode.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }
         [HttpGet("ByProfessor/{Professorid}")]
        public async Task <IActionResult> GetProfessorByIdAsync(int Professorid)
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
        public async Task <IActionResult> post(Aluno model)
        {
            try:{
              _reppor.Add(model)
              if (await _reppor.SaveChangesAsync()){
                 return Created($"/api/aluno/{model.id}", model);
              }
              
            }
            catch(System.Exception){
              return this.StatusCode(StatusCode.Status500InternalServerError, "Banco de Dados Falhou");
            }
            return BadRequest("Aluno não cadastrado");
        }
        [HttpPut("{Alunoid}")]
        public async Task <IActionResult> put(int Alunoid, Aluno model)
        {
            try:{
              var aluno = await _reppor.GetAlunoByIdAsync(Alunoid, false);
              if (aluno == null) return NotFound();
              _reppor.Update(model)
              if (await _reppor.SaveChangesAsync()){
                aluno = await _reppor.GetAlunoByIdAsync(Alunoid, true);
                 return Created($"/api/aluno/{model.id}", model);
              }
              
            }
            catch(System.Exception){
              return this.StatusCode(StatusCode.Status500InternalServerError, "Banco de Dados Falhou");
            }
            return BadRequest("Aluno não encontrado");
        }
        [HttpDelete("{Alunoid}")]
        public async Task <IActionResult> delet(int Alunoid)
        {
            try:{
              var aluno = await _reppor.GetAlunoByIdAsync(Alunoid, false);
              if (aluno == null) return NotFound();
              _reppor.Delet(aluno)
              return delet(aluno);
              if (await _reppor.SaveChangesAsync()){
                 return Ok();
              }
            }
            catch(System.Exception){
              return this.StatusCode(StatusCode.Status500InternalServerError, "Banco de Dados Falhou");
            }
            return BadRequest("Aluno não encontrado");
        }
    }
}