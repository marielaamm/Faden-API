using Faden_Api.Class;
using Faden_Api.Class.cat;
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

namespace Faden_Api.Controllers.CAT
{
    public class DepartamentoController : ApiController
    {
        [Route("api/cat/Departamento/Buscar")]
        [HttpGet]
        public string Departamento(string Codigo)
        {
            return _Departamento(Codigo);
        }

        private string _Departamento(string Codigo)
        {
            string json = string.Empty;

            if (Codigo == null) Codigo = string.Empty;

            try
            {
                using(FADENEntities _conexion = new FADENEntities())
                {
                    var qDepartamento = (from _d in _conexion.Departamento
                                         where _d.Codigo == (Codigo == string.Empty ? _d.Codigo : Codigo)
                                         select new
                                         {
                                             IdDepto = _d.IdDepto,
                                             Codigo = _d.Codigo,
                                             Nombre = _d.Nombre
                                         }).ToList();

                    json = Cls_Mensaje.Tojson(qDepartamento, qDepartamento.Count, string.Empty, string.Empty, 0);
                }
            }

            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", ex.Message, 1);
            }

            return json;
        }
       
        [Route("api/cat/Departamento/Guardar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Guardar(Cls_Departamento Departamento)
        {
            if (ModelState.IsValid)
            {
                return Ok(_Guardar(Departamento));
            }
            else
            {
                return BadRequest();
            }
        }

        private string _Guardar(Cls_Departamento Departamento)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {


                        Departamento _d = _conexion.Departamento.Find(Departamento.IdDepartamento);

                        if (_d == null)
                        {
                            _d = new Departamento();
                            _d.Codigo = Departamento.Codigo;
                            _d.Nombre = Departamento.Departamento;
                            _conexion.Departamento.Add(_d);

                        }
                        else
                        {
                            _d.Codigo = Departamento.Codigo;
                            _d.Nombre = Departamento.Departamento;
                           
                        }

                       
                        _conexion.SaveChanges();
                        scope.Complete();

                        json = Cls_Mensaje.Tojson(Departamento, 1, string.Empty, "Registro Guardado", 0);
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