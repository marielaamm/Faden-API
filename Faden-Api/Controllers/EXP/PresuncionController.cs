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
    public class PresuncionController : ApiController
    {

        [Route("api/cat/AntPresuncion/Guardar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Guardar(AnalisisPresuncion d)
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

        private string _Guardar(AnalisisPresuncion d)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {


                        AnalisisPresuncion _d = _conexion.AnalisisPresuncion.Find(d.IdAnalisiPresuncion);

                        if (_d == null)
                        {
                            _d = new AnalisisPresuncion();
                            _d.Descripcion = d.Descripcion;
                            _d.Fecha = d.Fecha;
                            _d.IdPaciente = d.IdPaciente;
                            _conexion.AnalisisPresuncion.Add(_d);

                        }
                        else
                        {
                            _d.Descripcion = d.Descripcion;
                            _d.Fecha = d.Fecha;
                            _d.IdPaciente = d.IdPaciente;

                        }


                        _conexion.SaveChanges();
                        scope.Complete();

                        json = Cls_Mensaje.Tojson(d, 1, string.Empty, "Registro Guardado", 0);
                    }
                }

            }
            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", ex.Message, 1);
            }
            return json;
        }



        [Route("api/cat/AntPresuncion/Buscar")]
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
                    var qDetalle = (from _d in _conexion.AnalisisPresuncion
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdAnalisiPresuncion = _d.IdAnalisiPresuncion,
                                        Descripcion = _d.Descripcion,
                                        Fecha = _d.Fecha,
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


        [Route("api/cat/AntPresuncion/Eliminar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Eliminar(int IdAnalisiPresuncion)
        {
            if (ModelState.IsValid)
            {
                return Ok(_Eliminar(IdAnalisiPresuncion));
            }
            else
            {
                return BadRequest();
            }
        }

        private string _Eliminar(int IdAnalisiPresuncion)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {


                        AnalisisPresuncion _d = _conexion.AnalisisPresuncion.Find(IdAnalisiPresuncion);

                        _conexion.AnalisisPresuncion.Remove(_d);


                        _conexion.SaveChanges();
                        scope.Complete();

                        json = Cls_Mensaje.Tojson(null, 0, string.Empty, "Registro Eliminado", 0);
                    }
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