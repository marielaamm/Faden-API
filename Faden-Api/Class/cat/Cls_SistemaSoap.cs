using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Faden_Api.Class.cat
{
    public class Cls_SistemaSoap
    {
        public int IdSoap = 0;
        public DateTime Fecha = DateTime.Now;
        public DateTime FechaRegistro = DateTime.Now;
        public int TipoAcompanante = 0;
        public string NombreAcompanante = string.Empty;
        public string Direccion = string.Empty;
        public string Telefono = string.Empty;
        public int PropositoVisita = 0;
        public string Subjetivo = string.Empty;
        public string Objetivo = string.Empty;
        public string Avaluo = string.Empty;
        public string Planes = string.Empty;
        public int IdPaciente = 0;

    }
}