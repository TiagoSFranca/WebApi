using CimatecGuideAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CimatecGuideAPI.Controllers
{
    public class DisciplinaController : ApiController
    {
        // GET: api/Disciplina
        public IEnumerable<Disciplina> Get()
        {
            return ObterDisciplinas().OrderBy(d => d.Nome);
        }

        private List<Disciplina> ObterDisciplinas()
        {
            List<Disciplina> disciplinas = new List<Disciplina>
            {
                new Disciplina { Id = 1, Nome = "LP I", CH = 60 },
                new Disciplina { Id = 2, Nome = "Arquitetura de Software", CH = 60 },
                new Disciplina { Id = 3, Nome = "AED I", CH = 60 },
                new Disciplina { Id = 4, Nome = "AED II", CH = 60 },
                new Disciplina { Id = 5, Nome = "Linguagem Comercial", CH = 60 },
                new Disciplina { Id = 6, Nome = "Linguagem Comercial Web", CH = 60 },
                new Disciplina { Id = 7, Nome = "Dispositivos Móveis", CH = 60 },
                new Disciplina { Id = 100, Nome = "Desenvolvimento com Xamarin I", CH = 60 },
                new Disciplina { Id = 200, Nome = "Controlando Robôs I", CH = 60 },
            };
            return disciplinas;
        }

        // GET: api/Disciplina/Get?id=5
        public Disciplina Get(int id)
        {
            return ObterDisciplinas().FirstOrDefault(d => d.Id == id);
        }

        private List<CursoDisciplinaProfessorRel> ObterRelCursoDisciplinasProf()
        {
            List<CursoDisciplinaProfessorRel> cd = new List<CursoDisciplinaProfessorRel>
            {
                new CursoDisciplinaProfessorRel{IdCurso=1, IdDisciplina=2, IdProfessor=1},
                new CursoDisciplinaProfessorRel{IdCurso=1, IdDisciplina=5, IdProfessor=3},
                new CursoDisciplinaProfessorRel{IdCurso=1, IdDisciplina=6, IdProfessor=1},
                new CursoDisciplinaProfessorRel{IdCurso=1, IdDisciplina=7, IdProfessor=4},
                new CursoDisciplinaProfessorRel{IdCurso=2, IdDisciplina=1, IdProfessor=1},
                new CursoDisciplinaProfessorRel{IdCurso=2, IdDisciplina=3, IdProfessor=3},
                new CursoDisciplinaProfessorRel{IdCurso=2, IdDisciplina=4, IdProfessor=1},
                new CursoDisciplinaProfessorRel{IdCurso=10, IdDisciplina=100, IdProfessor=1},
                new CursoDisciplinaProfessorRel{IdCurso=20, IdDisciplina=200, IdProfessor=2},
            };
            return cd;
        }

        // GET: api/Disciplina/GetByCurso?id={id}
        public IEnumerable<Disciplina> GetByCurso(int id)
        {
            List<CursoDisciplinaProfessorRel> cdprel = ObterRelCursoDisciplinasProf();
            List<int> idsDisciplinas = cdprel.Where(cdr=>cdr.IdCurso==id).Select(cd => cd.IdDisciplina).ToList<int>();
            return ObterDisciplinas().FindAll(d=>idsDisciplinas.Contains(d.Id));
        }

        // GET: api/Disciplina/GetByCurso?id={id}
        public IEnumerable<Disciplina> GetByProfessor(int id)
        {
            List<CursoDisciplinaProfessorRel> cdprel = ObterRelCursoDisciplinasProf();
            List<int> idsDisciplinas = cdprel.Where(cdr => cdr.IdProfessor == id).Select(cd => cd.IdDisciplina).ToList<int>();
            return ObterDisciplinas().FindAll(d => idsDisciplinas.Contains(d.Id));
        }

        // POST: api/Disciplina
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Disciplina/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Disciplina/5
        public void Delete(int id)
        {
        }
    }
}
