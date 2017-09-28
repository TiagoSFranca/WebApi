using CimatecGuideAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CimatecGuideAPI.Controllers
{
    public class CursoController : ApiController
    {
        
        // GET: api/Curso
        public IEnumerable<Curso> Get()
        {
            return ObterCursos().OrderBy(c => c.Nome);
        }

        private List<Curso> ObterCursos()
        {
            List<Curso> cursos = new List<Curso>
            {
                new Curso { Id = 1, Nome = "Análise e Desenvolvimento de Software", CH = 3000, Coordenador = "Caroline Paim", Mensalidade = 650.00f, NotaMEC = 4, Tipo = 1 },
                new Curso { Id = 2, Nome = "Engenharia de Computação", CH = 4390, Coordenador = "Caroline Paim", Mensalidade = 1035.00f, NotaMEC = 4, Tipo = 1 },
                new Curso { Id = 3, Nome = "Engenharia Mecânica", CH = 4000, Coordenador = "Guilherme Oliveira", Mensalidade = 1035.00f, NotaMEC = 4, Tipo = 1 },
                new Curso { Id = 4, Nome = "Engenharia Elétrica", CH = 5100, Coordenador = "Taniel Franklin", Mensalidade = 1035.00f, NotaMEC = 4, Tipo = 1 },
                new Curso { Id = 10, Nome = "DESENVOLVIMENTO DE APLICATIVOS PARA DISPOSITIVOS MÓVEIS", CH = 450, Coordenador = "Caroline Paim", Mensalidade = 650.00f, NotaMEC = 4, Tipo = 2 },
                new Curso { Id = 20, Nome = "AUTOMAÇÃO, CONTROLE E ROBÓTICA", CH = 450, Coordenador = "Oberdan Rocha Pinheiro", Mensalidade = 835.00f, NotaMEC = 4, Tipo = 2 }
            };
            return cursos;
        }

        // GET: api/Curso/5
        public Curso Get(int id)
        {
            return ObterCursos().FirstOrDefault(c => c.Id == id);
        }

        // GET: api/Curso/GetPosGrad
        public IEnumerable<Curso> GetPosGrad()
        {
            return ObterCursos().Where(c => c.Tipo == 2).OrderBy(cn=>cn.Nome);
        }

        // GET: api/Curso/GetGrad
        public IEnumerable<Curso> GetGrad()
        {
            return ObterCursos().Where(c => c.Tipo == 1).OrderBy(cn => cn.Nome);
        }

        // POST: api/Curso
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Curso/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Curso/5
        public void Delete(int id)
        {
        }
    }
}
