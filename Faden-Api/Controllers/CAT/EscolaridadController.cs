using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using Newtonsoft.Json;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.Transactions;
using IsolationLevel = System.Transactions.IsolationLevel;
using Faden_Api.Models;
using Faden_Api.Class;

namespace Faden_Api.Controllers.CAT
{
    public class EscolaridadController : ApiController
    {

        [Route("api/cat/Escolaridad/Guardar")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Guardar(Escolaridad d)
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

        private string _Guardar(Escolaridad d)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    using (FADENEntities _conexion = new FADENEntities())
                    {


                        Escolaridad _C = _conexion.Escolaridad.FirstOrDefault( f=> f.IdEscolaridad == d.IdEscolaridad);

                        if (_C == null)
                        {


                            _C = new Escolaridad();
                            _C.Nombre = d.Nombre;
                            _C.Activo = true;
                            _conexion.Escolaridad.Add(_C);

                        }
                        else
                        {
                            _C.Nombre = d.Nombre;
                            _C.Activo = d.Activo; 

                        }

                        _conexion.SaveChanges();
                        scope.Complete();

                        json = Cls_Mensaje.Tojson(d, 1, string.Empty, "Registro guardado.", 0);


                    }
                }

            }
            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", "Error al ingresar el registro.", 1);

            }

            return json;

        }


        [Route("api/cat/Escolaridad/Buscar")]
        [HttpGet]
        public string Escolaridad()
        {
            return _Escolaridad();
        }

        private string _Escolaridad()
        {
            string json = string.Empty;

            try
            {
                using (FADENEntities _conexion = new FADENEntities())
                {
                    var qEscolaridad = (from _m in _conexion.Escolaridad
                                        where _m.Activo == true
                                      select new
                                      {
                                          IdEscolaridad = _m.IdEscolaridad,
                                          Nombre = _m.Nombre,
                                          Activo = _m.Activo
                                      }).ToList();

                    json = Cls_Mensaje.Tojson(qEscolaridad, qEscolaridad.Count, string.Empty, string.Empty, 0);




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