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
    
    public partial class Medicos
    {
        public int IdMedico { get; set; }
        public string NoMedico { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public string PNombre { get; set; }
        public string SNombre { get; set; }
        public string PApellido { get; set; }
        public string SApellido { get; set; }
        public string NombreCompleto { get; set; }
        public int IdDepto { get; set; }
        public int IdCiudad { get; set; }
        public System.DateTime FechaNac { get; set; }
        public string Identificacion { get; set; }
        public string Especialidad { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
    
        public virtual Ciudad Ciudad { get; set; }
    }
}
