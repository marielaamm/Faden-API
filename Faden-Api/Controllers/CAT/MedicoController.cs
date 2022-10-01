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

                        if (d.NoMedico=="00000")
                        {

                            int x = 0;
                            string NoMedico=string.Empty;

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

                            if (NoMedico != null) {
                                
                                x = Convert.ToInt32(NoMedico);
                            }

                            x += 1;

                            _d.NoMedico = x.ToString().PadLeft(5,'0');
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
    }
}