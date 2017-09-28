using CimatecGuideAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CimatecGuideAPI.Controllers
{
    public class ProfessorController : ApiController
    {
        // GET: api/Professor
        public IEnumerable<Professor> Get()
        {
            return ObterProfessores().OrderBy(p => p.Nome);
        }

        private List<Professor> ObterProfessores()
        {
            List<Professor> professores = new List<Professor>
            {
                new Professor { Id = 1, Nome = "Marcos Lapa dos Santos", ModContrato = "CLT" },
                new Professor { Id = 2, Nome = "Caroline Dias Paim", ModContrato = "CLT" },
                new Professor { Id = 3, Nome = "Marcio Soussa", ModContrato = "Horista" },
                new Professor { Id = 4, Nome = "André Portugal", ModContrato = "Horista" }
            };
            return professores;
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
        public IEnumerable<Professor> GetByCurso(int id)
        {
            List<CursoDisciplinaProfessorRel> cdprel = ObterRelCursoDisciplinasProf();
            List<int> idsProf = cdprel.Where(cdr => cdr.IdCurso == id).Select(cd => cd.IdProfessor).ToList<int>();
            return ObterProfessores().FindAll(p => idsProf.Contains(p.Id));
        }

        // GET: api/Disciplina/GetByCurso?id={id}
        public IEnumerable<Professor> GetByDisciplina(int id)
        {
            List<CursoDisciplinaProfessorRel> cdprel = ObterRelCursoDisciplinasProf();
            List<int> idsProf = cdprel.Where(cdr => cdr.IdDisciplina == id).Select(cd => cd.IdProfessor).ToList<int>();
            return ObterProfessores().FindAll(p => idsProf.Contains(p.Id));
        }

        // GET: api/Professor/5
        public Professor Get(int id)
        {
            return ObterProfessores().FirstOrDefault(p => p.Id == id);
        }

        // POST: api/Professor
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Professor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Professor/5
        public void Delete(int id)
        {
        }
    }
}
