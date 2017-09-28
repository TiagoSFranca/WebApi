using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CimatecGuideAPI.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public short CH { get; set; }
        public string Coordenador { get; set; }
        public short NotaMEC { get; set; }
        public float Mensalidade { get; set; }
        public short Tipo { get; set; } // 1 = Graduação; 2 = Pós
    }
}