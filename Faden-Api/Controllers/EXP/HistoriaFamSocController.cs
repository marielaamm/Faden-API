using Faden_Api.Class;
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
    public class HistoriaFamSocController : ApiController
    {
        [Route("api/cat/Historia/Guardar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Guardar(Cls_HistoriaFamSoc h)
        {
            if (ModelState.IsValid)
            {
                return Ok(_Guardar(h));
            }
            else
            {
                return BadRequest();
            }
        }

        private string _Guardar(Cls_HistoriaFamSoc h)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    using (FADENEntities _conexion = new FADENEntities())
                    {
                        HistoriaFamSoc _h = _conexion.HistoriaFamSoc.Find(h.IdHistoriaFamSoc);
                        bool esNuevo = false;

                        if (_h == null)
                        {
                            _h = new HistoriaFamSoc();
                            esNuevo = true;
                        }

                        _h.HistoriaFamiliar = h.HistoriaFamiliar;
                        _h.HistoriaSocial = h.HistoriaSocial;
                        _h.IdPaciente = h.IdPaciente;



                        if (esNuevo) _conexion.HistoriaFamSoc.Add(_h);
                        _conexion.SaveChanges();
                        scope.Complete();

                        json = Cls_Mensaje.Tojson(h, 1, string.Empty, "Registro guardado.", 0);


                    }
                }

            }
            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", "Error al ingresar el registro.", 1);

            }

            return json;

        }


        [Route("api/cat/Historia/Buscar")]
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
                    var qDetalle = (from _h in _conexion.HistoriaFamSoc
                                    where _h.IdPaciente == IdPaciente
                                    select new
                                    {
                                        HistoriaFamiliar = _h.HistoriaFamiliar,
                                        HistoriaSocial = _h.HistoriaSocial,
                                        IdPaciente = _h.IdPaciente,

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