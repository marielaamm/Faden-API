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

namespace Faden_Api.Controllers.SIS
{
    public class RolesController : ApiController
    {
        [Route("api/SIS/Rol/Guardar")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Guardar(Rol d)
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

        private string _Guardar(Rol d)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    using (FADENEntities _conexion = new FADENEntities())
                    {


                        Rol _C = _conexion.Rol.FirstOrDefault(f => f.IdRol == d.IdRol);

                        if (_C == null)
                        {


                            _C = new Rol();
                            _C.Rol1 = d.Rol1;
                            _C.Activo = true;
                            _conexion.Rol.Add(_C);

                        }
                        else
                        {
                            _C.Rol1 = d.Rol1;
                            _C.Activo = d.Activo;

                        }
                        _conexion.SaveChanges();

                        foreach (Acceso p in d.Acceso)
                        {
                            Acceso a = _conexion.Acceso.Find(p.IdAcceso);
                            bool esNuevo = false;

                            if(a == null)
                            {
                                a = new Acceso();
                                esNuevo = true;
                            }
                            a.IdRol = _C.IdRol;
                            a.Seleccionar = p.Seleccionar;
                            a.EsMenu = p.EsMenu;
                            a.Modulo = p.Modulo;
                            a.ModuloNombre = p.ModuloNombre;
                            a.Id = p.Id;
                            a.Link = p.Link;
                            a.MenuPadre = p.MenuPadre;
                            a.Clase = p.Clase;

                            if (esNuevo) _conexion.Acceso.Add(a);
                            _conexion.SaveChanges();

                        }
                       

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


        [Route("api/SIS/Rol/Buscar")]
        [HttpGet]
        public string Roles()
        {
            return _Roles();
        }

        private string _Roles()
        {
            string json = string.Empty;

            try
            {
                using (FADENEntities _conexion = new FADENEntities())
                {

                    object[] obj = new object[] { null, null };

                    var qRoles = (from _m in _conexion.Rol                                       
                                  where _m.Activo == true
                                        select new
                                        {
                                            IdRol = _m.IdRol,
                                            Rol1 = _m.Rol1,
                                            Activo = _m.Activo,
                                        }).ToList();


                    var qAcceso = (from _m in _conexion.Acceso
                                  select new
                                  {
                                      _m.IdAcceso,
                                      _m.IdRol,
                                      _m.Seleccionar,
                                      _m.EsMenu,
                                      _m.Modulo,
                                      _m.ModuloNombre,
                                      _m.Id,
                                      _m.Link,
                                  }).ToList();

                    obj[0] = qRoles;
                    obj[1] = qAcceso;

                    json = Cls_Mensaje.Tojson(obj, 2, string.Empty, string.Empty, 0);




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