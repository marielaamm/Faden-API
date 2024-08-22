using DevExpress.XtraRichEdit.Commands;
using Faden_Api.Class;
using Faden_Api.Class.EXP;
using Faden_Api.Models;
using Faden_Api.Reporte;
using Faden_Api.Reporte.DsetReporteTableAdapters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Faden_Api.Controllers.EXP
{
    public class ImprimirController : ApiController
    {
        [Route("api/Reporte/Imprimir")]
        [HttpGet]
        public string Imprimir(string op, DateTime? Fecha1, DateTime? Fecha2, string NoExpediente)
        {
            return _Imprimir(op, Fecha1, Fecha2, NoExpediente);
        }

        private string _Imprimir(string op, DateTime? Fecha1, DateTime? Fecha2, string NoExpediente)
        {
            string json = string.Empty;



            try
            {
                using (FADENEntities _conexion = new FADENEntities())
                {

                    Cls_Datos DatosReporte = new Cls_Datos();

                    DsetReporte DsetReporte = new DsetReporte();
           
                    MemoryStream stream = new MemoryStream();





                    switch (op)
                    {

                        case "1":
                            xrpExpediente xrpExpediente = new xrpExpediente();
                            SP_ExpedienteTableAdapter adpExpediente = new SP_ExpedienteTableAdapter();
                            adpExpediente.Fill(DsetReporte.SP_Expediente, NoExpediente);
                            xrpExpediente.DataSource = DsetReporte;


                            SP_AcompananteTableAdapter adpAcomp = new SP_AcompananteTableAdapter();
                            adpAcomp.Fill(DsetReporte.SP_Acompanante, NoExpediente);
                            xrpExpediente.xrpAcompanante.ReportSource = new xrpExpAcompanante();
                            xrpExpediente.xrpAcompanante.ReportSource.DataSource = DsetReporte;



                            SP_XRP_HistoriaClinicaTableAdapter adpHistoriaCli = new SP_XRP_HistoriaClinicaTableAdapter();
                            adpHistoriaCli.Fill(DsetReporte.SP_XRP_HistoriaClinica, NoExpediente);
                            xrpExpediente.xrpHistoriaClinica.ReportSource = new xrpHistoriaClinica();
                            xrpExpediente.xrpHistoriaClinica.ReportSource.DataSource = DsetReporte;


                            SP_XRP_TratamientoActualTableAdapter adpTratamientoActual = new SP_XRP_TratamientoActualTableAdapter();
                            adpTratamientoActual.Fill(DsetReporte.SP_XRP_TratamientoActual, NoExpediente);
                            xrpExpediente.xrpTratamientoActual.ReportSource = new xrpTratamientoActual();
                            xrpExpediente.xrpTratamientoActual.ReportSource.DataSource = DsetReporte;





                            SP_XRP_ExamenClinicoTableAdapter adpExamenClinico = new SP_XRP_ExamenClinicoTableAdapter();
                            adpExamenClinico.Fill(DsetReporte.SP_XRP_ExamenClinico, NoExpediente);
                            xrpExpediente.xrpExamenClinico.ReportSource = new xrpExamenClinico();
                            xrpExpediente.xrpExamenClinico.ReportSource.DataSource = DsetReporte;


                            SP_XRP_AntecedentePatologicoTableAdapter adpAntPatolo = new SP_XRP_AntecedentePatologicoTableAdapter();
                            adpAntPatolo.Fill(DsetReporte.SP_XRP_AntecedentePatologico, NoExpediente);
                            xrpExpediente.xrpAntecendentePatologico.ReportSource = new xrpAntecedentePatologico();
                            xrpExpediente.xrpAntecendentePatologico.ReportSource.DataSource = DsetReporte;


                            SP_XRP_AntecedenteQuirurgicoTableAdapter adpAntQui = new SP_XRP_AntecedenteQuirurgicoTableAdapter();
                            adpAntQui.Fill(DsetReporte.SP_XRP_AntecedenteQuirurgico, NoExpediente);
                            xrpExpediente.xrpAntecendenteQuirurgico.ReportSource = new xrpAntecedenteQuirurgico();
                            xrpExpediente.xrpAntecendenteQuirurgico.ReportSource.DataSource = DsetReporte;



                            SP_XRP_AntecedenteFamiliarTableAdapter adpAntFamiliar = new SP_XRP_AntecedenteFamiliarTableAdapter();
                            adpAntFamiliar.Fill(DsetReporte.SP_XRP_AntecedenteFamiliar, NoExpediente);
                            xrpExpediente.xrpAntecedenteFamiliar.ReportSource = new xrpAntecedenteFamiliar();
                            xrpExpediente.xrpAntecedenteFamiliar.ReportSource.DataSource = DsetReporte;


                            SP_XRP_EstiloVidaTableAdapter adpEstiloVida = new SP_XRP_EstiloVidaTableAdapter();
                            adpEstiloVida.Fill(DsetReporte.SP_XRP_EstiloVida, NoExpediente);
                            xrpExpediente.xrpEstiloVida.ReportSource = new xrpEstiloVida();
                            xrpExpediente.xrpEstiloVida.ReportSource.DataSource = DsetReporte;


                            SP_XRP_EstiloVidaEjercicioTableAdapter adpEstiloVidaEjerci = new SP_XRP_EstiloVidaEjercicioTableAdapter();
                            adpEstiloVidaEjerci.Fill(DsetReporte.SP_XRP_EstiloVidaEjercicio, NoExpediente);
                            xrpExpediente.xrpEstiloVidaEjercicio.ReportSource = new xrpEstiloVidaEjercicio();
                            xrpExpediente.xrpEstiloVidaEjercicio.ReportSource.DataSource = DsetReporte;


                            SP_XRP_EstiloVidaAlimentacionTableAdapter adpEstiloVidaAlimen = new SP_XRP_EstiloVidaAlimentacionTableAdapter();
                            adpEstiloVidaAlimen.Fill(DsetReporte.SP_XRP_EstiloVidaAlimentacion, NoExpediente);
                            xrpExpediente.xrpEstiloVidaAlimentacion.ReportSource = new xrpEstiloVidaAlimentacion();
                            xrpExpediente.xrpEstiloVidaAlimentacion.ReportSource.DataSource = DsetReporte;


                            SP_XRP_ExamenFisicoSistemaTableAdapter adpExamenFisico = new SP_XRP_ExamenFisicoSistemaTableAdapter();
                            adpExamenFisico.Fill(DsetReporte.SP_XRP_ExamenFisicoSistema, NoExpediente);
                            xrpExpediente.xrpExamenFisicoSistema.ReportSource = new xrpExamenFisicoSistema();
                            xrpExpediente.xrpExamenFisicoSistema.ReportSource.DataSource = DsetReporte;


                            SP_XRP_AnalisisPresuncionTableAdapter adpExPresun = new SP_XRP_AnalisisPresuncionTableAdapter();
                            adpExPresun.Fill(DsetReporte.SP_XRP_AnalisisPresuncion, NoExpediente);
                            xrpExpediente.xrpAnalisisPresuncion.ReportSource = new xrpAnalisisPresuncion();
                            xrpExpediente.xrpAnalisisPresuncion.ReportSource.DataSource = DsetReporte;



                            SP_XRP_SOAPTableAdapter adpSoap = new SP_XRP_SOAPTableAdapter();
                            adpSoap.Fill(DsetReporte.SP_XRP_SOAP, NoExpediente);
                            xrpExpediente.xrpSOAP.ReportSource = new xrpSOAP();
                            xrpExpediente.xrpSOAP.ReportSource.DataSource = DsetReporte;






                            xrpExpediente.ShowPrintMarginsWarning = false;
                            xrpExpediente.ExportToPdf(stream, null);

                            stream.Seek(0, SeekOrigin.Begin);

                            DatosReporte.d = stream.ToArray();
                            DatosReporte.Nombre = "Expediente";
                            break;

                        case "2":

                            SP_xrp_PacienteTableAdapter adpPacienteEdad = new SP_xrp_PacienteTableAdapter();
                            adpPacienteEdad.Fill(DsetReporte.SP_xrp_Paciente);

  

                            xrpPacienteEdad xrpPacienteEdad = new xrpPacienteEdad();
                            xrpPacienteEdad.DataSource = DsetReporte;
                            xrpPacienteEdad.ShowPrintMarginsWarning = false;
                            xrpPacienteEdad.ExportToPdf(stream, null);



                            stream.Seek(0, SeekOrigin.Begin);

                            DatosReporte.d = stream.ToArray();
                            DatosReporte.Nombre = "";


                            break;

                        case "3":


                            SP_AcompananteTableAdapter adpAcompanante = new SP_AcompananteTableAdapter();
                            adpAcompanante.Fill(DsetReporte.SP_Acompanante, "0000000000");

                 

                            xrpAcompanante xrpAcomp = new xrpAcompanante();
                            xrpAcomp.DataSource = DsetReporte;
                            xrpAcomp.ShowPrintMarginsWarning = false;
                            xrpAcomp.ExportToPdf(stream, null);

                            stream.Seek(0, SeekOrigin.Begin);

                            DatosReporte.d = stream.ToArray();
                            DatosReporte.Nombre = "Reporte Paciente Acompanante";


                            break;

                        case "4":
                            SP_Atencion_Esp_SexTableAdapter adpAtencionEspSex = new SP_Atencion_Esp_SexTableAdapter();
                            adpAtencionEspSex.Fill(DsetReporte.SP_Atencion_Esp_Sex,   Fecha1, Fecha2);

    
                            xrpAtencionEspSex xrpAtenEspSex = new xrpAtencionEspSex();
                            xrpAtenEspSex.DataSource = DsetReporte;
                            xrpAtenEspSex.ShowPrintMarginsWarning = false;
                            xrpAtenEspSex.ExportToPdf(stream, null);

                            stream.Seek(0, SeekOrigin.Begin);

                            DatosReporte.d = stream.ToArray();
                            DatosReporte.Nombre = "Atencion por Especialidad y Sexo";



                            break;
                        
                       
                        case "5":
                            break;
                        case "6":
                            break;
                        case "7":
                            break;
                    }



                    json = Cls_Mensaje.Tojson(DatosReporte, 1, string.Empty, string.Empty, 0);
                }
            }

            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", ex.Message, 1);
            }

            return json;
        }


        [Route("api/Reporte/Paciente")]
        [HttpGet]
        public string Paciente()
        {
            return _Paciente();
        }

        private string _Paciente()
        {
            string json = string.Empty;



            try
            {
                using (FADENEntities _conexion = new FADENEntities())
                {

                    var qPaciente = (from _q in _conexion.Paciente
                                     select new
                                     {
                                         _q.NoExpediente,
                                         NombreCompleto = string.Concat(_q.PNombre, " ", _q.SNombre, " ", _q.PApellido, " ", _q.SApellido),
                                         Key = string.Concat(_q.NoExpediente, " - ",_q.PNombre, " ", _q.SNombre, " ", _q.PApellido, " ", _q.SApellido)
                                     }).ToList();


                    json = Cls_Mensaje.Tojson(qPaciente, 1, string.Empty, string.Empty, 0);
                }
            }

            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", ex.Message, 1);
            }

            return json;
        }



    }
}