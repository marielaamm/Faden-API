﻿using Faden_Api.Class;
using Faden_Api.Class.cat;
using Faden_Api.Class.EXP;
using Faden_Api.Models;
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
                                    // where _q.Fecha.Date >= Fecha1.Date && _q.Fecha.Date <= Fecha2.Date
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


                        scope.Complete();

                        json = Cls_Mensaje.Tojson(null, 1, string.Empty, "Registro Guardado", 0);
                    }
                }

            }
            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", ex.Message.Replace("\r\n", "<br>"), 1);
            }
            return json;
        }



        [Route("api/Agenda/Cancelar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Cancelar(int IdAgenda)
        {
            if (ModelState.IsValid)
            {
                return Ok(_Cancelar(IdAgenda));
            }
            else
            {
                return BadRequest();
            }
        }

        private string _Cancelar(int IdAgenda)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {

                        AgendaMedica row = _conexion.AgendaMedica.Find(IdAgenda);
          

                        row.Estado = "Cancelada";

                        _conexion.SaveChanges();


                        scope.Complete();

                        json = Cls_Mensaje.Tojson(null, 1, string.Empty, "Cita Cancelada", 0);
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