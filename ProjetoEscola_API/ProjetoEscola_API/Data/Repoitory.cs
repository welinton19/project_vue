using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEscola_API.Data
{
    public class Repoitory : IRepository
    {
        public DataContext _context { get; }

        public Repoitory(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delet<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        //Alunos
        public async Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor)
            {
                query = query.Include(a => a.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);
            
            return query.ToArrayAsync();   
        }
        public async Task<Aluno[]> GetAllAlunosAsyncByProfessorId(int ProfessorId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor)
            {
                query = query.Include(a => a.Professor);
            }
            query = query.AsNoTracking()
            .OrderBy(a => a.Id)
            .Where(a => a.ProfessorId == ProfessorId);

            return query.ToArrayAsync();
        }
        public async Task<Aluno> GetAlunoByIdAsync(int id, bool includeProfessor)
        {
             IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor)
            {
                query = query.Include(a => a.Professor);
            }
            query = query.AsNoTracking()
            .OrderBy(a => a.Id)
            .Where(a => a.Id == id);
            
            return query.FirstOrDefaultAsync(); 
        }
        //Professor 
        public async Task<Professor[]> GetAllProfessoresAsync(bool includeAluno = false)
        {
           IQueryable<Professor> query = _context.Professores;

            if(includeAluno)
            {
                query = query.Include(p => p.Alunos);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id);
            
            return query.ToArrayAsync();
        }
        public async Task<Professor> GetProfessorByIdAsync(int ProfessorId, bool includeAluno)
        {
             IQueryable<Professor> query = _context.Professores;

            if(includeAluno)
            {
                query = query.Include(p => p.Alunos);
            }
            query = query.AsNoTracking()
            .OrderBy(p => p.Id);
            .Where(p => p.Id == ProfessorId);

            return query.FirstOrDefaultAsync();
        }   

        
    }
}