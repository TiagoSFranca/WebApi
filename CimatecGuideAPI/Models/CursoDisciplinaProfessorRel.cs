using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CimatecGuideAPI.Models
{
    public class CursoDisciplinaProfessorRel
    {
        public int IdCurso { get; set; }
        public int IdDisciplina { get; set; }
        public int IdProfessor { get; set; }
    }
}