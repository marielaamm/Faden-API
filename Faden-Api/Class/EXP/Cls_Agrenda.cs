using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Faden_Api.Class.EXP
{
    public class Cls_Agrenda
    {
        public int IdAgenda { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public System.DateTime Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
    }
}