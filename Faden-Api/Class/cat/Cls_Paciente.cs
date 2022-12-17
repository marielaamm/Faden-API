using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Faden_Api.Class.cat
{
    public class Cls_Paciente
    {
        public int IdPaciente = 0;
        public string NoExpediente = string.Empty;
        public DateTime FechaIngreso = DateTime.Now;
        public string PNombre = string.Empty;
        public string SNombre = string.Empty;
        public string PApellido = string.Empty;
        public string SApellido = string.Empty;
        public string Sexo = string.Empty;
        public int IdDepto = 0;
        public int IdCiudad = 0;
        public DateTime FechaNacim = DateTime.Now;
        public string Ocupacion = string.Empty;
        public string Identificacion = string.Empty;
        public int IdEscolaridad = 0;
        public string ECivil = string.Empty;
        public string Direccion = string.Empty;
        public string Telefono = string.Empty;
        public string Celular = string.Empty;
        public string Correo = string.Empty;
        public string Religion = string.Empty;
        public string Convive = string.Empty;
        public string Visita = string.Empty;
        public string RefVisita = string.Empty;
        public string Referencia = string.Empty;
        public bool Trabaja = false;
        public string RefTrabajo = string.Empty;
        public bool UltimoTrabajo = false;
        public string RefUltTrabajo = string.Empty;
        public bool Jubilado = false;
        public bool Pensionado = false;
        public string Estado = string.Empty;
        public Cls_TAcompanante[] TAcompanante = null;


    }
}