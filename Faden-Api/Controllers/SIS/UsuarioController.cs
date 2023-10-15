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
    public class UsuarioController : ApiController
    {
        [Route("api/SIS/Usuario/Guardar")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Guardar(Usuario d)
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

        private string _Guardar(Usuario d)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    using (FADENEntities _conexion = new FADENEntities())
                    {


                        Usuario _C = _conexion.Usuario.FirstOrDefault(f => f.IdUsuario == d.IdUsuario);

                        if (_C == null)
                        {

           
                            _C = new Usuario();
                            _C.IdUsuario = d.IdUsuario;
                            _C.IdRol = d.IdRol;
                            _C.Nombre = d.Nombre;
                            _C.Apellido = d.Apellido;
                            _C.Usuario1 = d.Usuario1;
                            _C.Contrasena = d.Contrasena;
                            _C.IdMedico = d.IdMedico;
                            _C.Activo = true;
                            _conexion.Usuario.Add(_C);

                        }
                        else
                        {
                            _C.IdRol = d.IdRol;
                            _C.Nombre = d.Nombre;
                            _C.Apellido = d.Apellido;
                            _C.Usuario1 = d.Usuario1;
                            _C.Contrasena = d.Contrasena;
                            _C.IdMedico = d.IdMedico;
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




        [Route("api/SIS/Usuario/Datos")]
        [HttpGet]
        public string Datos()
        {
            return v_Datos();
        }

        private string v_Datos()
        {
            string json = string.Empty;

            try
            {
                using (FADENEntities _Conexion = new FADENEntities())
                {
                    List<Cls_Datos> lstDatos = new List<Cls_Datos>();

                    Cls_Datos datos = new Cls_Datos();

                    var qRoles = (from _m in _Conexion.Rol
                                  where _m.Activo == true
                                  select new
                                  {
                                      IdRol = _m.IdRol,
                                      Rol1 = _m.Rol1,
                                      Activo = _m.Activo
                                  }).ToList();

                    json = Cls_Mensaje.Tojson(qRoles, qRoles.Count, string.Empty, string.Empty, 0);



                    datos.Nombre = "FECHA FACTURA";
                    datos.d = qRoles;
                    lstDatos.Add(datos);





                    var qMedico = (from _q in _Conexion.Medicos
                                   select new
                                   {
                                       _q.IdMedico,
                                       _q.NoMedico,
                                       _q.NombreCompleto,
                                       _q.Especialidad

                                   }).ToList();


                    json = Cls_Mensaje.Tojson(qRoles, qRoles.Count, string.Empty, string.Empty, 0);

                    datos = new Cls_Datos();
                    datos.Nombre = "MEDICOS";
                    datos.d = qMedico;
                    lstDatos.Add(datos);



                    json = Cls_Mensaje.Tojson(lstDatos, lstDatos.Count, string.Empty, string.Empty, 0);
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