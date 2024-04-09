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


namespace Faden_Api.Class.EXP
{
    public class EstiloVidaController : ApiController
    {
        [Route("api/cat/EstiloVida/Guardar")]
        [System.Web.Http.HttpPost]

        public IHttpActionResult Guardar(Cls_EstiloVidaDatos d)
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

        private string _Guardar(Cls_EstiloVidaDatos d)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {

                    using (FADENEntities _conexion = new FADENEntities())
                    {



                        EstiloVida e = _conexion.EstiloVida.FirstOrDefault( f=> f.IdPaciente == d.EstiloVida.IdPaciente);
                       
                        bool EsNuevo = false;

                        if(e == null)
                        {
                            e = new EstiloVida();
                            EsNuevo = true;
                        }

                        if (d.EstiloVida.Senderismo == null) d.EstiloVida.Senderismo = string.Empty;
                        if (d.EstiloVida.Alcoholismo == null) d.EstiloVida.Alcoholismo = string.Empty;
                        if (d.EstiloVida.Tabaquismo == null) d.EstiloVida.Tabaquismo = string.Empty;
                        if (d.EstiloVida.Cafe == null) d.EstiloVida.Cafe = string.Empty;
                        if (d.EstiloVida.Ruido == null) d.EstiloVida.Ruido = string.Empty;
                        if (d.EstiloVida.Horas == null) d.EstiloVida.Horas = string.Empty;
                        if (d.EstiloVida.Despertar == null) d.EstiloVida.Despertar = string.Empty;


                        e.Senderismo = d.EstiloVida.Senderismo;
                        e.Alcoholismo = d.EstiloVida.Alcoholismo;
                        e.Tabaquismo = d.EstiloVida.Tabaquismo;
                        e.Cafe = d.EstiloVida.Cafe;
                        e.Ruido = d.EstiloVida.Ruido;
                        e.Horas = d.EstiloVida.Horas;
                        e.Despertar = d.EstiloVida.Despertar;
                        e.IdPaciente = d.EstiloVida.IdPaciente;

                        if (EsNuevo) _conexion.EstiloVida.Add(e);
                        _conexion.SaveChanges();


                        foreach (var det in d.Ejercicios)
                        {
                            EstiloVidaEjercicio ej = _conexion.EstiloVidaEjercicio.FirstOrDefault( f=> f.IdElemento == det.IdElemento && f.IdPaciente == det.IdPaciente);

                            EsNuevo = false;
                            if (ej == null)
                            {
                                ej = new EstiloVidaEjercicio();
                                EsNuevo = true;
                            }

                            if (det.IdElemento == null) det.IdElemento = string.Empty;
                            if (det.Frecuencia == null) det.Frecuencia = string.Empty;
              


                            ej.IdElemento = det.IdElemento;
                            ej.Frecuencia = det.Frecuencia;
                            ej.Activo = det.Activo;
                            ej.IdPaciente = det.IdPaciente;

                            if (EsNuevo) _conexion.EstiloVidaEjercicio.Add(ej);
                            _conexion.SaveChanges();

                        }


                        foreach (var det in d.Alimentacion)
                        {

                            EstiloVidaAlimentacion ea = _conexion.EstiloVidaAlimentacion.FirstOrDefault(f => f.IdElemento == det.IdElemento && f.IdPaciente == det.IdPaciente);

                            EsNuevo = false;
                            if (ea == null)
                            {
                                ea = new EstiloVidaAlimentacion();
                                EsNuevo = true;
                            }
                            if (det.IdElemento == null) det.IdElemento = string.Empty;
                            if (det.Porcion == null) det.Porcion = string.Empty;
                            if (det.Frecuencia == null) det.Frecuencia = string.Empty;

                            ea.IdElemento = det.IdElemento;
                            ea.Porcion = det.Porcion;
                            ea.Frecuencia = det.Frecuencia;
                            ea.IdPaciente = det.IdPaciente;

                            if (EsNuevo) _conexion.EstiloVidaAlimentacion.Add(ea);
                            _conexion.SaveChanges();
                        }



                      

                        scope.Complete();

                        json = Cls_Mensaje.Tojson(d, 1, string.Empty, "Registro Guardado", 0);
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