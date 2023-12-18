using Faden_Api.Class;
using Faden_Api.Models;
using Faden_Api.Reporte;
using Faden_Api.Reporte.DsetReporteTableAdapters;
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
        public string Imprimir(string op)
        {
            return _Imprimir(op);
        }

        private string _Imprimir(string op)
        {
            string json = string.Empty;



            try
            {
                using (FADENEntities _conexion = new FADENEntities())
                {

                    Cls_Datos DatosReporte = new Cls_Datos();

                    DsetReporte DsetReporte = new DsetReporte();
           
                    MemoryStream stream = new MemoryStream();

                    DateTime Fecha1 = new DateTime(2023, 11, 01);
                    DateTime Fecha2 = new DateTime(2023, 11, 30);




                    switch (op)
                    {
                        case "1":

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
                        case "2":
                            SP_Atencion_Esp_SexTableAdapter adpAtencionEspSex = new SP_Atencion_Esp_SexTableAdapter();
                            adpAtencionEspSex.Fill(DsetReporte.SP_Atencion_Esp_Sex, Fecha1, Fecha2);

    
                            xrpAtencionEspSex xrpAtenEspSex = new xrpAtencionEspSex();
                            xrpAtenEspSex.DataSource = DsetReporte;
                            xrpAtenEspSex.ShowPrintMarginsWarning = false;
                            xrpAtenEspSex.ExportToPdf(stream, null);

                            stream.Seek(0, SeekOrigin.Begin);

                            DatosReporte.d = stream.ToArray();
                            DatosReporte.Nombre = "Atencion por Especialidad y Sexo";



                            break;
                        case "3":
                            SP_xrp_AcompananteTableAdapter adpAcompanante = new SP_xrp_AcompananteTableAdapter();
                            adpAcompanante.Fill(DsetReporte.SP_xrp_Acompanante);


                            xrpAcompanante xrpAcomp = new xrpAcompanante();
                            xrpAcomp.DataSource = DsetReporte;
                            xrpAcomp.ShowPrintMarginsWarning = false;
                            xrpAcomp.ExportToPdf(stream, null);

                            stream.Seek(0, SeekOrigin.Begin);

                            DatosReporte.d = stream.ToArray();
                            DatosReporte.Nombre = "Reporte Paciente Acompanante";


                            break;
                        case "4":
                            xrpExpediente xrpExpediente = new xrpExpediente();
                            SP_ExpedienteTableAdapter adpExpediente = new SP_ExpedienteTableAdapter();
                            adpExpediente.Fill(DsetReporte.SP_Expediente, "0000000000");
                            xrpExpediente.DataSource = DsetReporte;


                            SP_AcompananteTableAdapter adpAcomp = new SP_AcompananteTableAdapter();
                            adpAcomp.Fill(DsetReporte.SP_Acompanante, "0000000000");
                            xrpExpediente.xrpAcompanante.ReportSource = new xrpExpAcompanante();
                            xrpExpediente.xrpAcompanante.ReportSource.DataSource = DsetReporte;



                            SP_XRP_HistoriaClinicaTableAdapter adpHistoriaCli = new SP_XRP_HistoriaClinicaTableAdapter();
                            adpHistoriaCli.Fill(DsetReporte.SP_XRP_HistoriaClinica, "0000000000");
                            xrpExpediente.xrpHistoriaClinica.ReportSource = new xrpHistoriaClinica();
                            xrpExpediente.xrpHistoriaClinica.ReportSource.DataSource = DsetReporte;


                            SP_XRP_TratamientoActualTableAdapter adpTratamientoActual = new SP_XRP_TratamientoActualTableAdapter();
                            adpTratamientoActual.Fill(DsetReporte.SP_XRP_TratamientoActual, "0000000000");
                            xrpExpediente.xrpTratamientoActual.ReportSource = new xrpTratamientoActual();
                            xrpExpediente.xrpTratamientoActual.ReportSource.DataSource = DsetReporte;





                            SP_XRP_ExamenClinicoTableAdapter adpExamenClinico = new SP_XRP_ExamenClinicoTableAdapter();
                            adpExamenClinico.Fill(DsetReporte.SP_XRP_ExamenClinico, "0000000000");
                            xrpExpediente.xrpExamenClinico.ReportSource = new xrpExamenClinico();
                            xrpExpediente.xrpExamenClinico.ReportSource.DataSource = DsetReporte;



                            xrpExpediente.ShowPrintMarginsWarning = false;
                            xrpExpediente.ExportToPdf(stream, null);

                            stream.Seek(0, SeekOrigin.Begin);

                            DatosReporte.d = stream.ToArray();
                            DatosReporte.Nombre = "Expediente";
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

    }
}