using Faden_Api.Class;
using Faden_Api.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Faden_Api.SIS
{
    public class ServerController : ApiController
    {

        [Route("api/SIS/Login")]
        [HttpGet]
        public string Login(string user, string pass)
        {
            return v_Login(user, pass);
        }

        private string v_Login(string user, string pass)
        {
            string json = string.Empty;
            try
            {
                using (FADENEntities _Conexion = new FADENEntities())
                {
                    List<Cls_Datos> lstDatos = new List<Cls_Datos>();

              
                    var qUsuario = (from _q in _Conexion.Usuario.ToList()
                                    where _q.Usuario1.TrimStart().TrimEnd() == user
                                    select new
                                    {
                                        User = _q.Usuario1,
                                        Nombre = _q.Nombre,
                                        Pwd = _q.Contrasena,
                                        Rol = string.Empty,
                                        IdMedico = _q.IdMedico == null ? -1 : _q.IdMedico,
                                        FechaLogin = string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now),
                                        Desconectar = false
                                    }).ToList();



                    if (qUsuario.Count == 0)
                    {
                        json = Cls_Mensaje.Tojson(null, 0, "1", "Usuario no encontrado.", 1);
                        return json;
                    }




                    if (!qUsuario[0].Pwd.Equals(pass))
                    {
                        json = Cls_Mensaje.Tojson(null, 0, string.Empty, "Contraseña Incorrecta.", 1);
                        return json;
                    }

                    Cls_Datos datos = new Cls_Datos();
                    datos.Nombre = "USUARIO";
                    datos.d = qUsuario;
                    lstDatos.Add(datos);


                    lstDatos.AddRange(v_FechaServidor(user, qUsuario[0].Desconectar));



                    json = Cls_Mensaje.Tojson(lstDatos, lstDatos.Count, string.Empty, string.Empty, 0);
                }



            }
            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", ex.Message, 1);
            }

            return json;
        }




        [Route("api/SIS/FechaServidor")]
        [HttpGet]
        public string FechaServidor(string user)
        {
            return v_FechaServidor(user);
        }

        private string v_FechaServidor(string user)
        {
            string json = string.Empty;
            try
            {
                using (FADENEntities _Conexion = new FADENEntities())
                {
                    List<Cls_Datos> lstDatos = new List<Cls_Datos>();
 
                    lstDatos.AddRange(v_FechaServidor(user, false));


                    json = Cls_Mensaje.Tojson(lstDatos, lstDatos.Count, string.Empty, string.Empty, 0);
                }



            }
            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", ex.Message, 1);
            }

            return json;
        }


        private Cls_Datos[] v_FechaServidor(string user, bool Desconectar)
        {

            Cls_Datos datos = new Cls_Datos();
            datos.Nombre = "FECHA SERVIDOR";
            datos.d = string.Format("{0:yyy-MM-dd hh:mm:ss}", DateTime.Now);


            Cls_Datos datos2 = new Cls_Datos();
            datos2.Nombre = "DESCONECCION";
            datos2.d = Desconectar ? "-1" : "7200";


            return new Cls_Datos[] { datos, datos2 };
        }
    }
}