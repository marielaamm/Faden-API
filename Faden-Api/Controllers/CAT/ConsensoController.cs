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
                            _s.IdPaciente = s.IdPaciente;

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

    }
}