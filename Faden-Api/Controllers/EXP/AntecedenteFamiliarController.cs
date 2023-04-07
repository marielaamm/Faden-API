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
    public class AntecedenteFamiliarController : ApiController
    {
        [Route("api/cat/AntFamiliar/Guardar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Guardar(AntecedenteFamiliar d)
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

        private string _Guardar(AntecedenteFamiliar d)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {


                        AntecedenteFamiliar _d = _conexion.AntecedenteFamiliar.Find(d.IdAntecedente);

                        if (_d == null)
                        {
                            _d = new AntecedenteFamiliar();
                            _d.TipoAntecedente = d.TipoAntecedente;
                            _d.Descripcion = d.Descripcion;
                            _d.IdPaciente = d.IdPaciente;
                            _conexion.AntecedenteFamiliar.Add(_d);

                        }
                        else
                        {
                            _d.TipoAntecedente = d.TipoAntecedente;
                            _d.Descripcion = d.Descripcion;
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



        [Route("api/cat/AntFamiliar/Buscar")]
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
                    var qDetalle = (from _d in _conexion.AntecedenteFamiliar
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdAntecedente = _d.IdAntecedente,
                                        TipoAntecedente = _d.TipoAntecedente,
                                        Descripcion = _d.Descripcion,
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


        [Route("api/cat/AntFamiliar/Eliminar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Eliminar(int IdAntecedente)
        {
            if (ModelState.IsValid)
            {
                return Ok(_Eliminar(IdAntecedente));
            }
            else
            {
                return BadRequest();
            }
        }

        private string _Eliminar(int IdAntecedente)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {


                        AntecedenteFamiliar _d = _conexion.AntecedenteFamiliar.Find(IdAntecedente);

                        _conexion.AntecedenteFamiliar.Remove(_d);


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