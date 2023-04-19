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
    public class ValoracionNeuroPsicoController : ApiController
    {
        [Route("api/cat/Valoracion/Guardar")]
        [System.Web.Http.HttpPost]


        public IHttpActionResult Guardar(Cls_ValoracionNeuroPsicologica v)
        {
            if (ModelState.IsValid)
            {
                return Ok(_Guardar(v));
            }
            else
            {
                return BadRequest();
            }
        }

        private string _Guardar(Cls_ValoracionNeuroPsicologica v)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    using (FADENEntities _conexion = new FADENEntities())
                    {
                        ValoracionNeuroPsico _v = _conexion.ValoracionNeuroPsico.Find(v.IdValoracion);
                        bool esNuevo = false;

                        if (_v == null)
                        {
                            _v = new ValoracionNeuroPsico();
                            esNuevo = true;
                        }

                        _v.Memoria = v.Memoria;
                        _v.FuncionesEjecutivas = v.FuncionesEjecutivas;
                        _v.Lenguaje = v.Lenguaje;
                        _v.FuncionesVisoEspaciales = v.FuncionesVisoEspaciales;
                        _v.FuncionesMotoras = v.FuncionesMotoras;
                        _v.Comportamiento = v.Comportamiento;
                        _v.FuncionAutonomica = v.FuncionAutonomica;
                        _v.IdPaciente = v.IdPaciente;
                        
                       
                       
                        if (esNuevo) _conexion.ValoracionNeuroPsico.Add(_v);
                        _conexion.SaveChanges();
                        scope.Complete();

                        json = Cls_Mensaje.Tojson(v, 1, string.Empty, "Registro guardado.", 0);


                    }
                }

            }
            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", "Error al ingresar el registro.", 1);

            }

            return json;

        }

    }
}