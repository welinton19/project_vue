using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola_API.Models
{
    public class Professor
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }

        public list <Aluno> Alunos { get; set; }
    }
}