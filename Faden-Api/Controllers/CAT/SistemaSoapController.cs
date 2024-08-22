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
    public class SistemaSoapController : ApiController
    {
        [Route("api/cat/SOAP/Guardar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Guardar(Cls_SistemaSoap s)
        {
            if (ModelState.IsValid)
            {
                return Ok(_Guardar(s));
            }
            else
            {
                return BadRequest();
            }
        }

        private string _Guardar(Cls_SistemaSoap s)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    using (FADENEntities _conexion = new FADENEntities())
                    {
                        SistemaSoap _s = _conexion.SistemaSoap.Find(s.IdSoap);
                        Usuario _U = _conexion.Usuario.FirstOrDefault(f => f.Usuario1 == s.Usuario);
                        bool esNuevo = false;
                        
                        if (_s == null)
                        {
                            _s = new SistemaSoap();
                            esNuevo = true;
                        }
                        
                       
                        _s.Fecha = s.Fecha;
                        _s.FechaRegistro = DateTime.Now;
                        _s.TipoAcompanante = s.TipoAcompanante;
                        _s.NombreAcompanante = s.NombreAcompanante;
                        _s.Direccion = s.Direccion;
                        _s.Telefono = s.Telefono;
                        _s.PropositoVisita = s.PropositoVisita;
                        _s.Subjetivo = s.Subjetivo;
                        _s.Objetivo = s.Objetivo;
                        _s.Avaluo = s.Avaluo;
                        _s.Planes = s.Planes;
                        _s.IdPaciente = s.IdPaciente;
                        _s.IdUsuario = _U.IdUsuario;



                        if (esNuevo) _conexion.SistemaSoap.Add(_s);
                        _conexion.SaveChanges();
                        scope.Complete();

                        json = Cls_Mensaje.Tojson(s, 1, string.Empty, "Registro guardado.", 0);


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