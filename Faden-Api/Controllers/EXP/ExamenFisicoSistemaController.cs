using Faden_Api.Class;
using Faden_Api.Class.cat;
using Faden_Api.Class.EXP;
using Faden_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Faden_Api.Controllers.EXP
{
    public class ExamenFisicoSistemaController : ApiController
    {
        [Route("api/cat/ExamenFisicoSistema/Guardar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Guardar(ExamenFisicoSistema[] datos)
        {
            if (ModelState.IsValid)
            {
                return Ok(_Guardar(datos));
            }
            else
            {
                return BadRequest();
            }
        }

        private string _Guardar(ExamenFisicoSistema[] datos)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {

                        foreach(ExamenFisicoSistema d in datos)
                        {
                            ExamenFisicoSistema _d = _conexion.ExamenFisicoSistema.Find(d.IdExFisicoSistema);

                            if (d.Observaciones == null) d.Observaciones = string.Empty;

                            if (_d == null)
                            {
                                _d = new ExamenFisicoSistema();
                                _d.IdElemento = d.IdElemento;
                                _d.Observaciones = d.Observaciones;
                                _d.Activo = d.Activo;
                                _d.IdPaciente = d.IdPaciente;
                                _conexion.ExamenFisicoSistema.Add(_d);

                            }
                            else
                            {
                                _d.Observaciones = d.Observaciones;
                                _d.Activo = d.Activo;
                                _d.IdPaciente = d.IdPaciente;

                            }
                            _conexion.SaveChanges();

                        }



                        
                        scope.Complete();

                        json = Cls_Mensaje.Tojson(datos, datos.Length, string.Empty, "Registro Guardado", 0);
                    }
                }

            }
            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", ex.Message, 1);
            }
            return json;
        }



        [Route("api/cat/ExamenFisicoSistema/Buscar")]
        [HttpGet]
        public string Buscar(int IdPaciente)
        {
            return _Buscar(IdPaciente);
        }

        private string _Buscar(int IdPaciente)
        {
            string json = string.Empty;



            try
            {
                using (FADENEntities _conexion = new FADENEntities())
                {
                    var qDetalle = (from _d in _conexion.ExamenFisicoSistema
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdExFisicoSistema = _d.IdExFisicoSistema,
                                        IdElemento = _d.IdElemento,
                                        Observaciones = _d.Observaciones,
                                        Activo = _d.Activo,
                                        IdPaciente = _d.IdPaciente
                                    }).ToList();

                    json = Cls_Mensaje.Tojson(qDetalle, qDetalle.Count, string.Empty, string.Empty, 0);
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