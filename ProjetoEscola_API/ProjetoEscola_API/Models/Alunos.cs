using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola_API.Models
{
    public class Alunos
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string DataNasc { get; set; }

        public int Professorid { get; set; }
        
        public Professores Professor { get; set; }
    }
}