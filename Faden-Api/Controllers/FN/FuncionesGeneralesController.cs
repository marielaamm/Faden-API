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

namespace Faden_Api.Controllers.FN
{
    public class FuncionesGeneralesController : ApiController
    {

        [Route("api/fn/BuscarFechaNac")]
        [HttpGet]
        public string BuscarFechaNac()
        {
            return _BuscarFechaNac();
        }

        private string _BuscarFechaNac()
        {
            string json = string.Empty;

            
            try
            {
                using (FADENEntities _conexion = new FADENEntities())
                {
                    var qLugarNac = (from _d in _conexion.Departamento
                                         join  _m in _conexion.Ciudad on _d.IdDepto equals _m.IdDepto
                                        
                                         select new
                                         {
                                             IdLugarNac = string.Concat(_d.IdDepto,"_",_m.IdCiudad),
                                             Departamento = _d.Nombre,
                                             Municipio= _m.Nombre,
                                             IdDepto = _d.IdDepto,
                                             IdMunicipio = _m.IdCiudad,
                                         }).ToList();

                    json = Cls_Mensaje.Tojson(qLugarNac, qLugarNac.Count, string.Empty, string.Empty, 0);
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