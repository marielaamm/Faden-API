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
    
    public partial class Paciente
    {
        public int IdPaciente { get; set; }
        public string NoExpediente { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public string PNombre { get; set; }
        public string SNombre { get; set; }
        public string PApellido { get; set; }
        public string SApellido { get; set; }
        public string Sexo { get; set; }
        public int IdDepto { get; set; }
        public int IdCiudad { get; set; }
        public System.DateTime FechaNacim { get; set; }
        public string Ocupacion { get; set; }
        public string Identificacion { get; set; }
        public int IdEscolaridad { get; set; }
        public string ECivil { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Religion { get; set; }
        public string Convive { get; set; }
        public string Visita { get; set; }
        public string RefVisita { get; set; }
        public string Referencia { get; set; }
        public bool Trabaja { get; set; }
        public string RefTrabajo { get; set; }
        public bool UltimoTrabajo { get; set; }
        public string RefUltTrabajo { get; set; }
        public bool Jubilado { get; set; }
        public bool Pensionado { get; set; }
        public string Estado { get; set; }
    
        public virtual Escolaridad Escolaridad { get; set; }
    }
}
