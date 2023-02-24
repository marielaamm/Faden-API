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
        public string Depresion = string.Empty;
        public string RefDepresion = string.Empty;
        public string TrastornoBip = string.Empty;
        public string RefTrasBip = string.Empty;
        public string Esquizo = string.Empty;
        public string RefEsquizo = string.Empty;
        public string OtroDiag = string.Empty;
        public string RefOtroDiag = string.Empty;
        public string RefProbable = string.Empty;
        public string RefConfirmado = string.Empty;
        public string TrataFarma = string.Empty;
        public string TrataNoFarma = string.Empty;
        public string Recomendaciones = string.Empty;
        public string Examenes = string.Empty;
        public int IdPaciente = 0;
        public string NoExpediente = string.Empty;
        public Cls_SindromePredominante[] SindromePredominante = null;



    }
}