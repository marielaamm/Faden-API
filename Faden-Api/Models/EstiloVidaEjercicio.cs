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
    
    public partial class EstiloVidaEjercicio
    {
        public int IdEjercicio { get; set; }
        public string IdElemento { get; set; }
        public string Frecuencia { get; set; }
        public bool Activo { get; set; }
        public int IdPaciente { get; set; }
    
        public virtual Paciente Paciente { get; set; }
    }
}
