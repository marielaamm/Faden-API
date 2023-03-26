using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Faden_Api.Class.EXP
{
    public class Cls_AntecedenteQuirurgico
    {
        public int IdAntQ { get; set; }
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public System.DateTime Fecha { get; set; }
        public int IdPaciente { get; set; }
    }
}