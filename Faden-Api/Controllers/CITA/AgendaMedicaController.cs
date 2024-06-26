using Faden_Api.Class;
using Faden_Api.Class.cat;
using Faden_Api.Class.EXP;
using Faden_Api.Models;
using Faden_Api.Reporte.DsetReporteTableAdapters;
using Faden_Api.Reporte;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Transactions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using System.IO;
using System.Data.Entity;

namespace Faden_Api.Controllers.CITA
{
    public class AgendaMedicaController : ApiController
    {


        [Route("api/Agenda/Get")]
        [HttpGet]
        public string Get(DateTime Fecha1, DateTime Fecha2)
        {
            return _Get(Fecha1, Fecha2);
        }

        private string _Get(DateTime Fecha1, DateTime Fecha2)
        {
            string json = string.Empty;



            try
            {
                using (FADENEntities _conexion = new FADENEntities())
                {
                    
                 
                    var qAgenda = (from _q in _conexion.AgendaMedica
                                     where _q.Fecha  >= DbFunctions.TruncateTime(Fecha1) && _q.Fecha <= DbFunctions.TruncateTime(Fecha2)
                                   orderby _q.Fecha descending
                                     select new
                                     {
                                         _q.IdAgenda,
                                         _q.IdPaciente,
                                         _q.IdMedico,
                                         _q.Fecha,
                                         _q.HoraInicio,
                                         _q.HoraFin,
                                         _q.Observaciones,
                                         _q.Estado,
                                         Paciente = string.Concat(_q.Paciente.PNombre, " ", _q.Paciente.SNombre, " ", _q.Paciente.PApellido, " ", _q.Paciente.SApellido),
                                         Medico = _q.Medicos.NombreCompleto

                                     }).ToList();




                    json = Cls_Mensaje.Tojson(qAgenda, 1, string.Empty, string.Empty, 0);
                }
            }

            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", ex.Message, 1);
            }

            return json;
        }




        [Route("api/Agenda/Datos")]
        [HttpGet]
        public string Datos()
        {
            return _Datos();
        }

        private string _Datos()
        {
            string json = string.Empty;



            try
            {
                using (FADENEntities _conexion = new FADENEntities())
                {


                    var qPaciente = (from _q in _conexion.Paciente
                                           select new
                                           {
                                               _q.IdPaciente,
                                               _q.NoExpediente,
                                               NombreCompleto = string.Concat(_q.PNombre, " ", _q.SNombre, " ", _q.PApellido, " ", _q.SApellido)

                                           }).ToList();


                    var qMedico = (from _q in _conexion.Medicos
                                     select new
                                     {
                                         _q.IdMedico,
                                         _q.NoMedico,
                                         _q.NombreCompleto,
                                         _q.Especialidad

                                     }).ToList();



                    object[] obj = new object[] { null, null };
                    obj[0] = qPaciente;
                    obj[1] = qMedico;


                    json = Cls_Mensaje.Tojson(obj, 1, string.Empty, string.Empty, 0);
                }
            }

            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", ex.Message, 1);
            }

            return json;
        }




        [Route("api/Agenda/Guardar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Guardar(Cls_Agrenda d)
        {
            if (ModelState.IsValid)
            {
                return Ok(_Guardar(d));
            }
            else
            {
                return BadRequest();
            }
        }

        private string _Guardar(Cls_Agrenda d)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {

                        AgendaMedica row = _conexion.AgendaMedica.Find(d.IdAgenda);
                        bool esNuevo = false;
                

                        if(row == null) {
                            row = new AgendaMedica();
                            row.Estado = "Programada";
                            esNuevo = true;
                        }
                        else
                        {
                            if(row.Fecha != d.Fecha || row.HoraInicio != d.HoraInicio || row.HoraFin != d.HoraFin) row.Estado = "ReProgramada";
                        }



                        row.IdPaciente = d.IdPaciente;
                        row.IdMedico = d.IdMedico;
                        row.Fecha = d.Fecha;
                        row.HoraInicio = d.HoraInicio;
                        row.HoraFin = d.HoraFin;
                        row.Observaciones = d.Observaciones;
                      
                        if(esNuevo) _conexion.AgendaMedica.Add(row);

                        _conexion.SaveChanges();

                        Cls_Datos DatosReporte = new Cls_Datos();

                        DsetReporte DsetReporte = new DsetReporte();

                        System.Data.DataSet Dset = new System.Data.DataSet();
                        System.Data.DataTable tbl = new System.Data.DataTable();

                        MemoryStream stream = new MemoryStream();


                        xrpCitaMedica xrpCita = new xrpCitaMedica();
                        SP_XRP_CitaMedicaTableAdapter adpCita = new SP_XRP_CitaMedicaTableAdapter();
                        tbl = DsetReporte.SP_XRP_CitaMedica.Clone();
                        adpCita.Connection.ConnectionString = _conexion.Database.Connection.ConnectionString;
                        adpCita.Fill(DsetReporte.SP_XRP_CitaMedica, row.IdAgenda);

                        tbl = DsetReporte.SP_XRP_CitaMedica.Copy();
                        Dset.Tables.Add(tbl);

                        xrpCita.DataSource = Dset;



                        xrpCita.ShowPrintMarginsWarning = false;
                        xrpCita.ExportToPdf(stream, null);

                        stream.Seek(0, SeekOrigin.Begin);

                        DatosReporte.d = stream.ToArray();
                        DatosReporte.Nombre = "CitaMedica";




                        scope.Complete();

                        json = Cls_Mensaje.Tojson(DatosReporte, 1, string.Empty, "Registro Guardado", 0);
                    }
                }

            }
            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", ex.Message.Replace("\r\n", "<br>"), 1);
            }
            return json;
        }



        [Route("api/Agenda/CambiarEstado")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult CambiarEstado(int IdAgenda, string s)
        {
            if (ModelState.IsValid)
            {
                return Ok(_CambiarEstado(IdAgenda, s));
            }
            else
            {
                return BadRequest();
            }
        }

        private string _CambiarEstado(int IdAgenda, string s)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {

                        AgendaMedica row = _conexion.AgendaMedica.Find(IdAgenda);
          

                        row.Estado = s;

                        _conexion.SaveChanges();


                        scope.Complete();

                        json = Cls_Mensaje.Tojson(null, 1, string.Empty, "Cita " + s, 0);
                    }
                }

            }
            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", ex.Message.Replace("\r\n", "<br>"), 1);
            }
            return json;
        }


    }
}