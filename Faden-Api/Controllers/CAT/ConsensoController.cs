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
    public class ConsensoController : ApiController
    {
        [Route("api/cat/Consenso/Guardar")]
        [System.Web.Http.HttpPost]
                                                        
        public IHttpActionResult Guardar(Cls_Consenso c)
        {
            if (ModelState.IsValid)
            {
                return Ok(_Guardar(c));
            }
            else
            {
                return BadRequest();
            }
        }

        private string _Guardar(Cls_Consenso c)
        {
            string json = string.Empty;
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    using (FADENEntities _conexion = new FADENEntities())
                    {                       
                        Consenso _c = _conexion.Consenso.Find(c.IdConsenso);    
                        bool esNuevo = false;
                        bool esNuevoDet = false;


                        if (_c == null)
                        {
                            _c = new Consenso();
                            esNuevo = true;
                        }



                        _c.DetCognitivo = c.DetCognitivo;
                        _c.SospechaDiag = c.SospechaDiag;
                        _c.RefNormal = c.RefNormal;
                        _c.RefLeve = c.RefLeve;
                        _c.RefMayor = c.RefMayor;
                        _c.Depresion = c.Depresion;
                        _c.RefDepresion = c.RefDepresion;
                        _c.TrastornoBip = c.TrastornoBip;
                        _c.RefTrasBip = c.RefTrasBip;
                        _c.Esquizo = c.Esquizo;
                        _c.RefEsquizo = c.RefEsquizo;
                        _c.OtroDiag = c.OtroDiag;
                        _c.RefOtroDiag = c.RefOtroDiag;
                        _c.RefProbable = c.RefProbable;
                        _c.RefConfirmado = c.RefConfirmado;
                        _c.TrataFarma = c.TrataFarma;
                        _c.TrataNoFarma = c.TrataNoFarma;
                        _c.Recomendaciones = c.Recomendaciones;
                        _c.Examenes = c.Examenes;
                        _c.IdPaciente = c.IdPaciente;



                        if(esNuevo) _conexion.Consenso.Add(_c);
                        _conexion.SaveChanges();


                        foreach (Cls_SindromePredominante s in c.TSindromePredominante)
                        {

                            SindromePredominante _s = _conexion.SindromePredominante.Find(s.IdSindrome);

                            if(_s == null)
                            {
                                _s = new SindromePredominante();
                                esNuevoDet = true;
                            }


                            _s.TipoSindrome = s.TipoSindrome;
                            _s.IdPaciente = c.IdPaciente;

                            if(esNuevoDet) _conexion.SindromePredominante.Add(_s);
                            

                        }

                        _conexion.SaveChanges();

                        scope.Complete();

                        json = Cls_Mensaje.Tojson(c, 1, string.Empty, "Registro guardado.", 0);


                    }
                }

            }
            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", "Error al ingresar el registro.", 1);

            }

            return json;

        }



        [Route("api/cat/Consenso/BuscarConsenso")]
        [HttpGet]
        public string Buscar(int IdPaciente)
        {
            return _Buscar(IdPaciente);
        }

        private string _Buscar(int IdPaciente)
        {
            string json = string.Empty;

            try
            {
                using (FADENEntities _conexion = new FADENEntities())
                {
                    var qDetalle = (from _d in _conexion.Consenso
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdConsenso = _d.IdConsenso,
                                        DetCognitivo = _d.DetCognitivo,
                                        SospechaDiag = _d.SospechaDiag,
                                        RefNormal = _d.RefNormal,
                                        RefLeve = _d.RefLeve,
                                        RefMayor = _d.RefMayor,
                                        Depresion = _d.Depresion,
                                        RefDepresion = _d.RefDepresion,
                                        TrastornoBip = _d.TrastornoBip,
                                        RefTrasBip = _d.RefTrasBip,
                                        Esquizo = _d.Esquizo,
                                        RefEsquizo = _d.RefEsquizo,
                                        OtroDiag = _d.OtroDiag,
                                        RefOtroDiag = _d.RefOtroDiag,
                                        RefProbable = _d.RefProbable,
                                        RefConfirmado = _d.RefConfirmado,
                                        TrataFarma = _d.TrataFarma,
                                        TrataNoFarma = _d.TrataNoFarma,
                                        Recomendaciones = _d.Recomendaciones,
                                        Examenes = _d.Examenes,
                                        IdPaciente = _d.IdPaciente,
                                    }).ToList();

                    json = Cls_Mensaje.Tojson(qDetalle, qDetalle.Count, string.Empty, string.Empty, 0);
                }
            }

            catch (Exception ex)
            {
                json = Cls_Mensaje.Tojson(null, 0, "1", ex.Message, 1);
            }

            return json;
        }



        [Route("api/cat/Consenso/BuscarSindrome")]
        [HttpGet]
        public string BuscarSindrome(int IdPaciente)
        {
            return _BuscarSindrome(IdPaciente);
        }

        private string _BuscarSindrome(int IdPaciente)
        {
            string json = string.Empty;



            try
            {
                using (FADENEntities _conexion = new FADENEntities())
                {
                    var qDetalle = (from _d in _conexion.SindromePredominante
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdSindrome = _d.IdSindrome,
                                        TipoSindrome = _d.TipoSindrome,
                                        IdPaciente = _d.IdPaciente,
                                    }).ToList();

                    json = Cls_Mensaje.Tojson(qDetalle, qDetalle.Count, string.Empty, string.Empty, 0);
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