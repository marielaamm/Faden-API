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
    public class PacienteController : ApiController
    {

        [Route("api/cat/Paciente/Guardar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Guardar(Cls_Paciente p)
        {
            if (ModelState.IsValid)
            {
                return Ok(_Guardar(p));
            }
            else
            {
                return BadRequest();
            }
        }

        private string _Guardar(Cls_Paciente p)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {

                        if (p.NoExpediente == string.Empty)
                        {

                            int y = 0;
                            string NoExpediente = string.Empty;

                            Paciente _p = new Paciente();

                            _p.NoExpediente = string.Empty;
                            _p.FechaIngreso = p.FechaIngreso;
                            _p.PNombre = p.PNombre;
                            _p.SNombre = p.SNombre;
                            _p.PApellido = p.PApellido;
                            _p.SApellido = p.SApellido;
                            _p.Sexo = p.Sexo;
                            _p.IdDepto = p.IdDepto;
                            _p.IdCiudad = p.IdCiudad;
                            _p.FechaNacim = p.FechaNacim;
                            _p.Ocupacion = p.Ocupacion;
                            _p.Identificacion = p.Identificacion;
                            _p.IdEscolaridad = p.IdEscolaridad;
                            _p.ECivil = p.ECivil;
                            _p.Direccion = p.Direccion;
                            _p.Telefono = p.Telefono;
                            _p.Celular = p.Celular;
                            _p.Correo = p.Correo;
                            _p.Religion = p.Religion;
                            _p.Convive = p.Convive;
                            _p.Visita = p.Visita;
                            _p.RefVisita = p.RefVisita;
                            _p.Referencia = p.Referencia;
                            _p.Trabaja = p.Trabaja;
                            _p.RefTrabajo = p.RefTrabajo;
                            _p.UltimoTrabajo = p.UltimoTrabajo;
                            _p.RefUltTrabajo = p.RefUltTrabajo;
                            _p.Jubilado = p.Jubilado;
                            _p.Pensionado = p.Pensionado;
                            _p.Estado = p.Estado;
                                                  

                            _conexion.Paciente.Add(_p);
                            _conexion.SaveChanges();

                            NoExpediente = _conexion.Paciente.Max(m => m.NoExpediente);

                            if (NoExpediente != string.Empty)
                            {

                                y = Convert.ToInt32(NoExpediente);
                            }

                            y += 1;
                            
                            _p.NoExpediente = y.ToString().PadLeft(10, '0');
                            _conexion.SaveChanges();

                            foreach (Cls_TAcompanante a in p.TAcompanante) {

                                Acompanante _a = new Acompanante();

                                _a.NombreCompleto = a.NombreCompleto;
                                _a.Telefono = a.Telefono;
                                _a.Direccion = a.Direccion;
                                _a.Correo = a.Correo;
                                _a.EsAcpte = a.EsAcpte;
                                _a.EsCuidador = a.EsCiudador;
                                _a.EsPrimario = a.EsPrimario;
                                _a.EsSecundario = a.EsSecundario;
                                _a.IdPaciente = _p.IdPaciente;

                                _conexion.Acompanante.Add(_a);
                                _conexion.SaveChanges();

                            }

                           




                        }
                        else
                        {

                            Paciente fila = _conexion.Paciente.ToList().First(f => f.NoExpediente == p.NoExpediente);

                            fila.FechaIngreso = p.FechaIngreso;
                            fila.NoExpediente = p.NoExpediente;
                            fila.PNombre = p.PNombre;
                            fila.SNombre = p.SNombre;
                            fila.PApellido = p.PApellido;
                            fila.SApellido = p.SApellido;
                            fila.Sexo = p.Sexo;
                            fila.IdDepto = p.IdDepto;
                            fila.IdCiudad = p.IdCiudad;
                            fila.FechaNacim = p.FechaNacim;
                            fila.Ocupacion = p.Ocupacion;
                            fila.Identificacion = p.Identificacion;
                            fila.IdEscolaridad = p.IdEscolaridad;
                            fila.ECivil = p.ECivil;                    
                            fila.Direccion = p.Direccion;                            
                            fila.Telefono = p.Telefono;
                            fila.Celular = p.Celular;
                            fila.Correo = p.Correo;
                            fila.Religion = p.Religion;
                            fila.Convive = p.Convive;
                            fila.Visita = p.Visita;
                            fila.Referencia = p.Referencia;
                            fila.Trabaja = p.Trabaja;
                            fila.RefTrabajo = p.RefTrabajo;
                            fila.UltimoTrabajo = p.UltimoTrabajo;
                            fila.RefUltTrabajo = p.RefUltTrabajo;
                            fila.Jubilado = p.Jubilado;
                            fila.Pensionado = p.Pensionado;
                            
                            _conexion.SaveChanges();

                            foreach (Cls_TAcompanante a in p.TAcompanante) { 

                                bool esnuevo = false;

                                Acompanante _a = _conexion.Acompanante.Find(a.IdAcpte);

                                if (a == null) {

                                    esnuevo = true;
                                    _a = new Acompanante();

                                }
                                _a.NombreCompleto = a.NombreCompleto;
                                _a.Telefono = a.Telefono;
                                _a.Direccion = a.Direccion;
                                _a.Correo = a.Correo;
                                _a.EsAcpte = a.EsAcpte;
                                _a.EsCuidador = a.EsCiudador;
                                _a.EsPrimario = a.EsPrimario;
                                _a.EsSecundario = a.EsSecundario;
                                _a.IdPaciente = fila.IdPaciente;

                                if(esnuevo) _conexion.Acompanante.Add(_a);
                                _conexion.SaveChanges();


                            }

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

        [Route("api/cat/Paciente/Buscar")]
        [HttpGet]
        public string BuscarPaciente()
        {
            return _BuscarPaciente();
        }

        private string _BuscarPaciente()
        {
            string json = string.Empty;

            

            try
            {
                using (FADENEntities _conexion = new FADENEntities())
                {

                    List<object> lst = new List<object>();

                    var LstAcompanante = (from _q in _conexion.Acompanante
                                          select new
                                          {
                                              NombreCompleto = _q.NombreCompleto,
                                              Telefono = _q.Telefono,
                                              Direccion = _q.Direccion,
                                              Correo = _q.Correo,
                                              EsAcpte = _q.EsAcpte,
                                              EsCuidador = _q.EsCuidador,
                                              EsPrimario = _q.EsPrimario,
                                              EsSecundario = _q.EsSecundario,
                                              IdPaciente = _q.IdPaciente
                                          }
                                          ).ToList();


                    var qPaciente = (from _m in _conexion.Paciente
                                     select new
                                     {
                                         Seleccionar = false,
                                         IdPaciente = _m.IdPaciente,
                                         NoExpediente = _m.NoExpediente,
                                         NombreCompleto = string.Concat(_m.PNombre, "_",_m.PApellido),
                                         FechaIngreso = _m.FechaIngreso,
                                         PNombre = _m.PNombre,
                                         SNombre = _m.SNombre,
                                         PApellido = _m.PApellido,
                                         SApellido = _m.SApellido,
                                         Sexo = _m.Sexo,
                                         IdLugarNac = string.Concat(_m.IdDepto, "_", _m.IdCiudad),
                                         FechaNacim = _m.FechaNacim,
                                         Ocupacion = _m.Ocupacion,
                                         Identificacion = _m.Identificacion,
                                         IdEscolaridad = _m.IdEscolaridad,
                                         ECivil = _m.ECivil,
                                         Direccion = _m.Direccion,
                                         Telefono = _m.Telefono,
                                         Celular = _m.Celular,
                                         Correo = _m.Correo,
                                         Religion = _m.Religion,
                                         Convive = _m.Convive,
                                         Visita = _m.Visita,
                                         Referencia = _m.Referencia,
                                         Trabaja = _m.Trabaja,
                                         RefTrabajo = _m.RefTrabajo,
                                         UltimoTrabajo = _m.UltimoTrabajo,
                                         RefUltTrabajo = _m.RefUltTrabajo,
                                         Jubilado = _m.Jubilado,
                                         Pensionado = _m.Pensionado,
 
                                      }).ToList();

                    lst.Add(qPaciente);
                    lst.Add(LstAcompanante);
                    json = Cls_Mensaje.Tojson(lst, lst.Count, string.Empty, string.Empty, 0);

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