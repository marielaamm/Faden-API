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
    
    public partial class SistemaSoap
    {
        public int IdSoap { get; set; }
        public System.DateTime Fecha { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public int TipoAcompanante { get; set; }
        public string NombreAcompanante { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int PropositoVisita { get; set; }
        public string Subjetivo { get; set; }
        public string Objetivo { get; set; }
        public string Avaluo { get; set; }
        public string Planes { get; set; }
        public int IdPaciente { get; set; }
        public int IdUsuario { get; set; }
    
        public virtual Paciente Paciente { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
