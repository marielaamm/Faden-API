﻿using Faden_Api.Class;
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

                            SP_Paciente_EdadTableAdapter adpPacienteEdad = new SP_Paciente_EdadTableAdapter();
                            adpPacienteEdad.Fill(DsetReporte.SP_Paciente_Edad);

  

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
                            break;
                        case "4":
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