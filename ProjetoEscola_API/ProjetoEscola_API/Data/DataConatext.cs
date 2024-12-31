using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola_API.Data
{
    public class DataConatext : Dbcontext
    {
        public DataConatext(DbContextOptions<DataConatext> options) : base(options)
        {
            
        }
        public DbSet<Alunos> Alunos { get; set; }
        
        public DbSet<Professores> Professores { get; set; }

        private override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professores>()
                .HasData(
                    new list <Professores>
                    {
                        new Professores {Id = 1, Nome = "Marta"},
                        new Professores {Id = 2, Nome = "Paula"},
                        new Professores {Id = 3, Nome = "Laura"},
                        new Professores {Id = 4, Nome = "Luiza"},
                        new Professores {Id = 5, Nome = "Lucas"}
                    }
                );
            builder.Entity<Alunos>()
               .HasData(
                    new List<Alunos>
                    {
                        new Alunos {Id = 1, Nome = "João", DataNasc = "10/12/1995", IdProfessor = 1},
                        new Alunos {Id = 2, Nome = "Maria", DataNasc = "03/06/1997", IdProfessor = 2},
                        new Alunos {Id = 3, Nome = "Pedro", DataNasc = "15/06/1998", IdProfessor = 3},
                        new Alunos {Id = 4, Nome = "Ana", DataNasc = "20/10/1991", IdProfessor = 4},
                        new Alunos {Id = 5, Nome = "Rafael", DataNasc = "19/04/2000", IdProfessor = 5}
                    }
                );
        }
    }
}