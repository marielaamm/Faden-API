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
    
    public partial class Consenso
    {
        public int RdDetCognitivo { get; set; }
        public int RdSospechaDiag { get; set; }
        public string RefNormal { get; set; }
        public string RefLeve { get; set; }
        public string RefMayor { get; set; }
        public string Depresion { get; set; }
        public string RefDepresion { get; set; }
        public string TrastornoBip { get; set; }
        public string RefTrasBip { get; set; }
        public string Esquizo { get; set; }
        public string RefEsquizo { get; set; }
        public string OtroDiag { get; set; }
        public string RefOtroDiag { get; set; }
        public string RefProbable { get; set; }
        public string RefConfirmado { get; set; }
        public string TrataFarma { get; set; }
        public string TrataNoFarma { get; set; }
        public string Recomendaciones { get; set; }
        public string Examenes { get; set; }
        public int IdPaciente { get; set; }
    }
}
