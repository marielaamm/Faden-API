using Faden_Api.Class;
using Faden_Api.Class.EXP;
using Faden_Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Faden_Api.Controllers.EXP
{
    public class ExpedienteController : ApiController
    {
        [Route("api/cat/Expediente/Buscar")]
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
                    var qTratHisto = (from _d in _conexion.TratamientoHistorico
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdTratamiento = _d.IdTratamiento,
                                        Tratamiento = _d.Tratamiento,
                                        Dosis = _d.Dosis,
                                        IdMedico = _d.IdMedico,
                                        FechaRegistro = _d.FechaRegistro,
                                        Tipo = _d.Tipo,
                                        IdPaciente = _d.IdPaciente
                                    }).ToList();



                    string strTratHisto = JsonConvert.SerializeObject(qTratHisto);





                    var qExamenClinico = (from _d in _conexion.ExamenClinico
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdExamenClinico = _d.IdExamenClinico,
                                        TipoExamen = _d.TipoExamen,
                                        Descripcion = _d.Descripcion,
                                        Fecha = _d.Fecha,
                                        IdPaciente = _d.IdPaciente
                                    }).ToList();


                    string strExamenClinico = JsonConvert.SerializeObject(qExamenClinico);




                    var qAntPatologico = (from _d in _conexion.AntecedentePatologico
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdAntecedentePatologico = _d.IdAntecedentePatologico,
                                        Enfermedad = _d.Enfermedad,
                                        Descripcion = _d.Descripcion,
                                        IdPaciente = _d.IdPaciente
                                    }).ToList();


                    string strAntPatologico = JsonConvert.SerializeObject(qAntPatologico);


                    var qAntQuirurgico = (from _d in _conexion.AntecendeteQuirurgico
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdAntQ = _d.IdAntQ,
                                        Descripcion = _d.Descripcion,
                                        Lugar = _d.Lugar,
                                        Fecha = _d.Fecha,
                                        IdPaciente = _d.IdPaciente
                                    }).ToList();


                    string strqAntQuirurgico = JsonConvert.SerializeObject(qAntQuirurgico);



                    var qAntFamiliares = (from _d in _conexion.AntecedenteFamiliar
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdAntecedente = _d.IdAntecedente,
                                        TipoAntecedente = _d.TipoAntecedente,
                                        Descripcion = _d.Descripcion,
                                        IdPaciente = _d.IdPaciente
                                    }).ToList();

                    string strqAntFamiliares = JsonConvert.SerializeObject(qAntFamiliares);


                    Cls_DatosExpediente Datos = new Cls_DatosExpediente();
                    Datos.TratHisto = strTratHisto;
                    Datos.ExamenClinico = strExamenClinico;
                    Datos.AntPatologico = strAntPatologico;
                    Datos.AntQuirurgico = strqAntQuirurgico;
                    Datos.AntFamiliares = strqAntFamiliares;


                    json = Cls_Mensaje.Tojson(Datos, 1, string.Empty, string.Empty, 0);
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