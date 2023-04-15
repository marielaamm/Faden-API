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
    public class AntNeuroPsiquiatricoController : ApiController
    {
        [Route("api/cat/AntNeuroPsiquiatrico/Guardar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Guardar(AntecedentenNeuroPsiquiatrico d)
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

        private string _Guardar(AntecedentenNeuroPsiquiatrico d)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {


                        AntecedentenNeuroPsiquiatrico _d = _conexion.AntecedentenNeuroPsiquiatrico.Find(d.IdAntNeuroPsiq);

                        if (_d == null)
                        {
                            _d = new AntecedentenNeuroPsiquiatrico();
                            _d.Nombre = d.Nombre;
                            _d.Vive = d.Vive;
                            _d.Enfermedad = d.Enfermedad;
                            _d.Padece = d.Padece;
                            _d.Parentesco = d.Parentesco;
                            _d.IdPaciente = d.IdPaciente;
                            _conexion.AntecedentenNeuroPsiquiatrico.Add(_d);

                        }
                        else
                        {
                            _d.Nombre = d.Nombre;
                            _d.Vive = d.Vive;
                            _d.Enfermedad = d.Enfermedad;
                            _d.Padece = d.Padece;
                            _d.Parentesco = d.Parentesco;
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



        [Route("api/cat/AntNeuroPsiquiatrico/Buscar")]
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
                    var qDetalle = (from _d in _conexion.AntecedentenNeuroPsiquiatrico
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdAntNeuroPsiq = _d.IdAntNeuroPsiq,
                                        Nombre = _d.Nombre,
                                        Vive = _d.Vive,
                                        Enfermedad = _d.Enfermedad,
                                        Padece = _d.Padece,
                                        Parentesco = _d.Parentesco,
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


        [Route("api/cat/AntNeuroPsiquiatrico/Eliminar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Eliminar(int IdAntNeuroPsiq)
        {
            if (ModelState.IsValid)
            {
                return Ok(_Eliminar(IdAntNeuroPsiq));
            }
            else
            {
                return BadRequest();
            }
        }

        private string _Eliminar(int IdAntNeuroPsiq)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {


                        AntecedentenNeuroPsiquiatrico _d = _conexion.AntecedentenNeuroPsiquiatrico.Find(IdAntNeuroPsiq);

                        _conexion.AntecedentenNeuroPsiquiatrico.Remove(_d);


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