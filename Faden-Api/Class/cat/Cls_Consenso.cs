using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Faden_Api.Class.cat
{
    public class Cls_Consenso
    {
        public int RdDetCognitivo = 0;
        public int RdSospechaDiag = 0;
        public string RefNormal = string.Empty;
        public string RefLeve = string.Empty;
        public string RefMayor = string.Empty;
        public bool Depresion = false;
        public string RefDepresion = string.Empty;
        public bool TrastornoBip = false;
        public string RefTrasBip = string.Empty;
        public bool Esquizo = false;
        public string RefEsquizo = string.Empty;
        public bool OtroDiag = false;
        public string RefOtroDiag = string.Empty;
        public string RefProbable = string.Empty;
        public string RefConfirmado = string.Empty;
        public string TrataFarma = string.Empty;
        public string TrataNoFarma = string.Empty;
        public string Recomendaciones = string.Empty;
        public string Examenes = string.Empty;
        public int IdPaciente = 0;       
        public Cls_SindromePredominante[] SindromePredominante = null;



    }
}