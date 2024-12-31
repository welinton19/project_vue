using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola_API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delet<T>(T entity) where T : class;

        Task <bool> SaveChangesAsync<T>();

        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor);

        Task<Aluno[]> GetAlunosByProfessorIdAsync(int Professorid, bool includeProfessor);

        Task<Aluno> GetAlunoByIdAsync(int Alunoid, bool includeProfessor);

        Task<Professor[]> GetAllProfessoresAsync(bool includeAluno);

        Task<Professor> GetProfessorByIdAsync(int Professorid, bool includeAluno);

    }
}