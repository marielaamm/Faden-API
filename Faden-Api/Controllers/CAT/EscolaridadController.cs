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

        private string _Guardar(Cls_Municipio d)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    using (FADENEntities _conexion = new FADENEntities())
                    {


                        Ciudad _C = _conexion.Ciudad.Find(d.IdCiudad);

                        if (_C == null)
                        {


                            _C = new Ciudad();
                            _C.Nombre = d.Nombre;
                            _C.IdDepto = d.IdDepto;
                            _conexion.Ciudad.Add(_C);

                        }
                        else
                        {
                            _C.Nombre = d.Nombre;
                            _C.IdDepto = d.IdDepto;

                        }

                        _conexion.SaveChanges();
                        scope.Complete();

                        json = Cls_Mensaje.Tojson(d, 1, string.Empty, "Registro guardado.", 0);


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