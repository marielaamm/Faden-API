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
    
    public partial class ValoracionNeuroPsico
    {
        public int IdValoracion { get; set; }
        public string Memoria { get; set; }
        public string FuncionesEjecutivas { get; set; }
        public string Lenguaje { get; set; }
        public string FuncionesVisoEspaciales { get; set; }
        public string FuncionesMotoras { get; set; }
        public string Comportamiento { get; set; }
        public string FuncionAutonomica { get; set; }
        public int IdPaciente { get; set; }
    
        public virtual Paciente Paciente { get; set; }
    }
}
