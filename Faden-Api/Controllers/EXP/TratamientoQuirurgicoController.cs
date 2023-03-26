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
    public class TratamientoQuirurgicoController : ApiController
    {
        [Route("api/cat/AntecedenteQuirurgico/Guardar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Guardar(Cls_AntecedenteQuirurgico d)
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

        private string _Guardar(Cls_AntecedenteQuirurgico d)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {


                        AntecendeteQuirurgico _d = _conexion.AntecendeteQuirurgico.Find(d.IdAntQ);

                        if (_d == null)
                        {
                            _d = new AntecendeteQuirurgico();
                            _d.Descripcion = d.Descripcion;
                            _d.Lugar = d.Lugar;
                            _d.Fecha = d.Fecha;
                            _d.IdPaciente = d.IdPaciente;
                            _conexion.AntecendeteQuirurgico.Add(_d);

                        }
                        else
                        {
                            _d.Descripcion = d.Descripcion;
                            _d.Lugar = d.Lugar;
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



        [Route("api/cat/AntecedenteQuirurgico/Buscar")]
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
                    var qDetalle = (from _d in _conexion.AntecendeteQuirurgico
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdAntQ = _d.IdAntQ,
                                        Descripcion = _d.Descripcion,
                                        Lugar = _d.Lugar,
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


        [Route("api/cat/AntecedenteQuirurgico/Eliminar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Eliminar(int IdAntQ)
        {
            if (ModelState.IsValid)
            {
                return Ok(_Eliminar(IdAntQ));
            }
            else
            {
                return BadRequest();
            }
        }

        private string _Eliminar(int IdAntQ)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {


                        AntecendeteQuirurgico _d = _conexion.AntecendeteQuirurgico.Find(IdAntQ);

                        _conexion.AntecendeteQuirurgico.Remove(_d);


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