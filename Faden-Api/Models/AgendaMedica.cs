//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Faden_Api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AgendaMedica
    {
        public int IdAgenda { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public System.DateTime Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
    
        public virtual Medicos Medicos { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}
