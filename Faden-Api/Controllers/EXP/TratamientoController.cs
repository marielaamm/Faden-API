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


namespace Faden_Api.Controllers.CAT.EXP
{
    public class TratamientoController : ApiController
    {
        [Route("api/cat/Tratamiento/Guardar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Guardar(cls_TratamientoHistorico d)
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

        private string _Guardar(cls_TratamientoHistorico d)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {


                        TratamientoHistorico _d = _conexion.TratamientoHistorico.Find(d.IdTratamiento);

                        if (_d == null)
                        {
                            _d = new TratamientoHistorico();
                            _d.Tratamiento = d.Tratamiento;
                            _d.Dosis = d.Dosis;
                            _d.IdMedico = d.IdMedico;
                            _d.IdPaciente = d.IdPaciente;
                            _d.FechaRegistro = DateTime.Now;
                            _d.Tipo = d.Tipo;
                            _conexion.TratamientoHistorico.Add(_d);

                        }
                        else
                        {
                            _d.Tratamiento = d.Tratamiento;
                            _d.Dosis = d.Dosis;
                            _d.IdMedico = d.IdMedico;
                            _d.IdPaciente = d.IdPaciente;
                            _d.Tipo = d.Tipo;

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



        [Route("api/cat/Tratamiento/Buscar")]
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
                    var qDetalle = (from _d in _conexion.TratamientoHistorico
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdTratamiento = _d.IdTratamiento,
                                        Tratamiento = _d.Tratamiento,
                                        Dosis = _d.Dosis,
                                        IdMedico = _d.IdMedico,
                                        FechaRegistro = _d.FechaRegistro,
                                        Tipo = _d.Tipo,
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


        [Route("api/cat/Tratamiento/Eliminar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Eliminar(int IdTratamiento)
        {
            if (ModelState.IsValid)
            {
                return Ok(_Eliminar(IdTratamiento));
            }
            else
            {
                return BadRequest();
            }
        }

        private string _Eliminar(int IdTratamiento)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {


                        TratamientoHistorico _d = _conexion.TratamientoHistorico.Find(IdTratamiento);

                        _conexion.TratamientoHistorico.Remove(_d);


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