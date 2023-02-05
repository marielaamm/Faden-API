using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Faden_Api.Class.cat
{
    public class Cls_TAcompanante

    {
        public int IdAcpte = 0;
        public string NombreCompleto = string.Empty;
        public string Telefono = string.Empty;
        public string Direccion = string.Empty;
        public string Correo = string.Empty;
        public bool EsAcpte = false;
        public bool EsCuidador = false;
        public bool EsPrimario = false;
        public bool EsSecundario = false;
        public int IdPaciente = 0;

    }
}