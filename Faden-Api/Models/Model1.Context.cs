﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FADENEntities : DbContext
    {
        public FADENEntities()
            : base("name=FADENEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<Escolaridad> Escolaridad { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Acompanante> Acompanante { get; set; }
    }
}
