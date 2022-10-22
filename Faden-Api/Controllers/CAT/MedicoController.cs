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
    public class MedicoController : ApiController
    {
        [Route("api/cat/Medicos/Guardar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Guardar(Cls_Medico d)
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

        private string _Guardar(Cls_Medico d)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {

                        if (d.NoMedico == "00000")
                        {

                            int x = 0;
                            string NoMedico = string.Empty;

                            Medicos _d = new Medicos();
                            _d.FechaIngreso = DateTime.Now;
                            _d.NoMedico = d.NoMedico;
                            _d.PNombre = d.PNombre;
                            _d.SNombre = d.SNombre;
                            _d.PApellido = d.PApellido;
                            _d.SApellido = d.SApellido;
                            _d.IdDepto = d.IdDepto;
                            _d.IdCiudad = d.IdCiudad;
                            _d.FechaNac = d.FechaNac;
                            _d.Identificacion = d.Identificacion;
                            _d.Especialidad = d.Especialidad;
                            _d.Direccion = d.Direccion;
                            _d.Correo = d.Correo;
                            _d.Telefono = d.Telefono;
                            _d.Celular = d.Celular;



                            _conexion.Medicos.Add(_d);
                            _conexion.SaveChanges();

                            NoMedico = _conexion.Medicos.Max(m => m.NoMedico);

                            if (NoMedico != null)
                            {

                                x = Convert.ToInt32(NoMedico);
                            }

                            x += 1;

                            _d.NoMedico = x.ToString().PadLeft(5, '0');
                            _conexion.SaveChanges();

                        }
                        else {

                            Medicos fila = _conexion.Medicos.ToList().First( f => f.NoMedico == d.NoMedico);

                            fila.FechaIngreso = d.FechaIngreso;
                            fila.NoMedico = d.NoMedico;
                            fila.PNombre = d.PNombre;
                            fila.SNombre = d.SNombre;
                            fila.PApellido = d.PApellido;
                            fila.SApellido = d.SApellido;   
                            fila.IdDepto = d.IdDepto;
                            fila.IdCiudad = d.IdCiudad;
                            fila.FechaNac = d.FechaNac;
                            fila.Identificacion = d.Identificacion;
                            fila.Especialidad = d.Especialidad;
                            fila.Direccion = d.Direccion;
                            fila.Correo = d.Correo;
                            fila.Telefono = d.Telefono;
                            fila.Celular = d.Celular;


                            _conexion.SaveChanges();
                        }


                        
                       
                        scope.Complete();

                        json = Cls_Mensaje.Tojson(null, 1, string.Empty, "Registro Guardado", 0);
                    }
                }

            }
            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", ex.Message, 1);
            }
            return json;
        }


        [Route("api/cat/Medicos/Eliminar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Eliminar(string NoMedico)
        {
            if (ModelState.IsValid)
            {
                return Ok(_Eliminar(NoMedico));
            }
            else
            {
                return BadRequest();
            }
        }

        private string _Eliminar(string NoMedico)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {


                        Medicos m = _conexion.Medicos.ToList().FirstOrDefault(f => f.NoMedico==NoMedico);

                        _conexion.Medicos.Remove(m);


                            
                        _conexion.SaveChanges();
                       
                        scope.Complete();

                        json = Cls_Mensaje.Tojson(null, 1, string.Empty, "Registro Eliminado", 0);
                    }
                }

            }
            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", ex.Message, 1);
            }
            return json;
        }




        [Route("api/cat/Medico/Buscar")]
        [HttpGet]
        public string Medico(string NoMedico)
        {
            return _Medico(NoMedico);
        }

        private string _Medico(string NoMedico)
        {
            string json = string.Empty;

            if(NoMedico==null) NoMedico = string.Empty;

            try
            {
                using (FADENEntities _conexion = new FADENEntities())
                {
                    var qMedicos = (from _m in _conexion.Medicos
                                    where _m.NoMedico==(NoMedico==string.Empty? _m.NoMedico : NoMedico)
                                      select new {
                                          IdMedico = _m.IdMedico,
                                          NoMedico = _m.NoMedico,
                                          FechaIngreso = _m.FechaIngreso,
                                          PNombre  = _m.PNombre,
                                          SNombre = _m.SNombre,
                                          PApellido = _m.PApellido,
                                          SApellido = _m.SApellido,
                                          NombreCompleto = _m.NombreCompleto,
                                          IdLugarNac = string.Concat(_m.IdDepto, "_", _m.IdCiudad),
                                          FechaNac = _m.FechaNac,
                                          Identificacion = _m.Identificacion,
                                          Especialidad = _m.Especialidad,
                                          Direccion = _m.Direccion,
                                          Correo = _m.Correo,
                                          Telefono = _m.Telefono,
                                          Celular = _m.Celular,

                                      }
                                      ).ToList();

                    json = Cls_Mensaje.Tojson(qMedicos, qMedicos.Count, string.Empty, string.Empty, 0);

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