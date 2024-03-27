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
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
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
    
        public virtual DbSet<Acceso> Acceso { get; set; }
        public virtual DbSet<Acompanante> Acompanante { get; set; }
        public virtual DbSet<AgendaMedica> AgendaMedica { get; set; }
        public virtual DbSet<AnalisisPresuncion> AnalisisPresuncion { get; set; }
        public virtual DbSet<AntecedenteFamiliar> AntecedenteFamiliar { get; set; }
        public virtual DbSet<AntecedentenNeuroPsiquiatrico> AntecedentenNeuroPsiquiatrico { get; set; }
        public virtual DbSet<AntecedentePatologico> AntecedentePatologico { get; set; }
        public virtual DbSet<AntecendeteQuirurgico> AntecendeteQuirurgico { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Consenso> Consenso { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Escolaridad> Escolaridad { get; set; }
        public virtual DbSet<EstiloVida> EstiloVida { get; set; }
        public virtual DbSet<EstiloVidaAlimentacion> EstiloVidaAlimentacion { get; set; }
        public virtual DbSet<EstiloVidaEjercicio> EstiloVidaEjercicio { get; set; }
        public virtual DbSet<ExamenClinico> ExamenClinico { get; set; }
        public virtual DbSet<ExamenFisicoSistema> ExamenFisicoSistema { get; set; }
        public virtual DbSet<HistoriaFamSoc> HistoriaFamSoc { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<PerfilUsuario> PerfilUsuario { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<SindromePredominante> SindromePredominante { get; set; }
        public virtual DbSet<SistemaSoap> SistemaSoap { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TratamientoHistorico> TratamientoHistorico { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<ValoracionNeuroPsico> ValoracionNeuroPsico { get; set; }
    
        public virtual ObjectResult<SP_Acompanante_Result> SP_Acompanante(string p_NoExpediente)
        {
            var p_NoExpedienteParameter = p_NoExpediente != null ?
                new ObjectParameter("P_NoExpediente", p_NoExpediente) :
                new ObjectParameter("P_NoExpediente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Acompanante_Result>("SP_Acompanante", p_NoExpedienteParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual ObjectResult<SP_Atencion_Esp_Sex_Result> SP_Atencion_Esp_Sex(Nullable<System.DateTime> p_Fecha1, Nullable<System.DateTime> p_Fecha2)
        {
            var p_Fecha1Parameter = p_Fecha1.HasValue ?
                new ObjectParameter("P_Fecha1", p_Fecha1) :
                new ObjectParameter("P_Fecha1", typeof(System.DateTime));
    
            var p_Fecha2Parameter = p_Fecha2.HasValue ?
                new ObjectParameter("P_Fecha2", p_Fecha2) :
                new ObjectParameter("P_Fecha2", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Atencion_Esp_Sex_Result>("SP_Atencion_Esp_Sex", p_Fecha1Parameter, p_Fecha2Parameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<SP_Expediente_Result> SP_Expediente(string p_NoExpediente)
        {
            var p_NoExpedienteParameter = p_NoExpediente != null ?
                new ObjectParameter("P_NoExpediente", p_NoExpediente) :
                new ObjectParameter("P_NoExpediente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Expediente_Result>("SP_Expediente", p_NoExpedienteParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<SP_Paciente_Edad_Result> SP_Paciente_Edad()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Paciente_Edad_Result>("SP_Paciente_Edad");
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<SP_XRP_Acompanante_Result> SP_XRP_Acompanante()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_XRP_Acompanante_Result>("SP_XRP_Acompanante");
        }
    
        public virtual ObjectResult<SP_XRP_AnalisisPresuncion_Result> SP_XRP_AnalisisPresuncion(string p_NoExpediente)
        {
            var p_NoExpedienteParameter = p_NoExpediente != null ?
                new ObjectParameter("P_NoExpediente", p_NoExpediente) :
                new ObjectParameter("P_NoExpediente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_XRP_AnalisisPresuncion_Result>("SP_XRP_AnalisisPresuncion", p_NoExpedienteParameter);
        }
    
        public virtual ObjectResult<SP_XRP_AntecedenteFamiliar_Result> SP_XRP_AntecedenteFamiliar(string p_NoExpediente)
        {
            var p_NoExpedienteParameter = p_NoExpediente != null ?
                new ObjectParameter("P_NoExpediente", p_NoExpediente) :
                new ObjectParameter("P_NoExpediente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_XRP_AntecedenteFamiliar_Result>("SP_XRP_AntecedenteFamiliar", p_NoExpedienteParameter);
        }
    
        public virtual ObjectResult<SP_XRP_AntecedentePatologico_Result> SP_XRP_AntecedentePatologico(string p_NoExpediente)
        {
            var p_NoExpedienteParameter = p_NoExpediente != null ?
                new ObjectParameter("P_NoExpediente", p_NoExpediente) :
                new ObjectParameter("P_NoExpediente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_XRP_AntecedentePatologico_Result>("SP_XRP_AntecedentePatologico", p_NoExpedienteParameter);
        }
    
        public virtual ObjectResult<SP_XRP_AntecedenteQuirurgico_Result> SP_XRP_AntecedenteQuirurgico(string p_NoExpediente)
        {
            var p_NoExpedienteParameter = p_NoExpediente != null ?
                new ObjectParameter("P_NoExpediente", p_NoExpediente) :
                new ObjectParameter("P_NoExpediente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_XRP_AntecedenteQuirurgico_Result>("SP_XRP_AntecedenteQuirurgico", p_NoExpedienteParameter);
        }
    
        public virtual ObjectResult<SP_XRP_CitaMedica_Result> SP_XRP_CitaMedica(Nullable<int> p_IdAgenda)
        {
            var p_IdAgendaParameter = p_IdAgenda.HasValue ?
                new ObjectParameter("P_IdAgenda", p_IdAgenda) :
                new ObjectParameter("P_IdAgenda", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_XRP_CitaMedica_Result>("SP_XRP_CitaMedica", p_IdAgendaParameter);
        }
    
        public virtual ObjectResult<SP_XRP_EstiloVida_Result> SP_XRP_EstiloVida(string p_NoExpediente)
        {
            var p_NoExpedienteParameter = p_NoExpediente != null ?
                new ObjectParameter("P_NoExpediente", p_NoExpediente) :
                new ObjectParameter("P_NoExpediente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_XRP_EstiloVida_Result>("SP_XRP_EstiloVida", p_NoExpedienteParameter);
        }
    
        public virtual ObjectResult<SP_XRP_EstiloVidaAlimentacion_Result> SP_XRP_EstiloVidaAlimentacion(string p_NoExpediente)
        {
            var p_NoExpedienteParameter = p_NoExpediente != null ?
                new ObjectParameter("P_NoExpediente", p_NoExpediente) :
                new ObjectParameter("P_NoExpediente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_XRP_EstiloVidaAlimentacion_Result>("SP_XRP_EstiloVidaAlimentacion", p_NoExpedienteParameter);
        }
    
        public virtual ObjectResult<SP_XRP_EstiloVidaEjercicio_Result> SP_XRP_EstiloVidaEjercicio(string p_NoExpediente)
        {
            var p_NoExpedienteParameter = p_NoExpediente != null ?
                new ObjectParameter("P_NoExpediente", p_NoExpediente) :
                new ObjectParameter("P_NoExpediente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_XRP_EstiloVidaEjercicio_Result>("SP_XRP_EstiloVidaEjercicio", p_NoExpedienteParameter);
        }
    
        public virtual ObjectResult<SP_XRP_ExamenClinico_Result> SP_XRP_ExamenClinico(string p_NoExpediente)
        {
            var p_NoExpedienteParameter = p_NoExpediente != null ?
                new ObjectParameter("P_NoExpediente", p_NoExpediente) :
                new ObjectParameter("P_NoExpediente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_XRP_ExamenClinico_Result>("SP_XRP_ExamenClinico", p_NoExpedienteParameter);
        }
    
        public virtual ObjectResult<SP_XRP_ExamenFisicoSistema_Result> SP_XRP_ExamenFisicoSistema(string p_NoExpediente)
        {
            var p_NoExpedienteParameter = p_NoExpediente != null ?
                new ObjectParameter("P_NoExpediente", p_NoExpediente) :
                new ObjectParameter("P_NoExpediente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_XRP_ExamenFisicoSistema_Result>("SP_XRP_ExamenFisicoSistema", p_NoExpedienteParameter);
        }
    
        public virtual ObjectResult<SP_XRP_HistoriaClinica_Result> SP_XRP_HistoriaClinica(string p_NoExpediente)
        {
            var p_NoExpedienteParameter = p_NoExpediente != null ?
                new ObjectParameter("P_NoExpediente", p_NoExpediente) :
                new ObjectParameter("P_NoExpediente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_XRP_HistoriaClinica_Result>("SP_XRP_HistoriaClinica", p_NoExpedienteParameter);
        }
    
        public virtual ObjectResult<SP_xrp_Paciente_Result> SP_xrp_Paciente()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_xrp_Paciente_Result>("SP_xrp_Paciente");
        }
    
        public virtual ObjectResult<SP_XRP_TratamientoActual_Result> SP_XRP_TratamientoActual(string p_NoExpediente)
        {
            var p_NoExpedienteParameter = p_NoExpediente != null ?
                new ObjectParameter("P_NoExpediente", p_NoExpediente) :
                new ObjectParameter("P_NoExpediente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_XRP_TratamientoActual_Result>("SP_XRP_TratamientoActual", p_NoExpedienteParameter);
        }
    }
}
