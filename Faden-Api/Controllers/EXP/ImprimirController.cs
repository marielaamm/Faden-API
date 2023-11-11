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

                    DsetReporte Dset = new DsetReporte();


                    switch (op)
                    {
                        case "1":

                            MemoryStream stream = new MemoryStream();


                            SP_Paciente_EdadTableAdapter adpPacienteEdad = new SP_Paciente_EdadTableAdapter();
                            adpPacienteEdad.Fill(Dset.SP_Paciente_Edad);

                            xrpPacienteEdad xrpPacienteEdad = new xrpPacienteEdad();
                            xrpPacienteEdad.ShowPrintMarginsWarning = false;
                            xrpPacienteEdad.ExportToPdf(stream, null);



                            stream.Seek(0, SeekOrigin.Begin);

                            DatosReporte.d = stream.ToArray();
                            DatosReporte.Nombre = "";


                            break;
                        case "2":
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