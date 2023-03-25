using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Faden_Api.Class.EXP
{
    public class cls_TratamientoHistorico
    {
        public int IdTratamiento { get; set; }
        public string Tratamiento { get; set; }
        public string Dosis { get; set; }
        public int IdMedico { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public int Tipo { get; set; }
        public int IdPaciente { get; set; }
    }
}