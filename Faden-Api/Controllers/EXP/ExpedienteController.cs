using Faden_Api.Class;
using Faden_Api.Class.EXP;
using Faden_Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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


                    var qHistoriaFamSoc = (from _h in _conexion.HistoriaFamSoc
                                           where _h.IdPaciente == IdPaciente
                                           select new
                                           {
                                               HistoriaFamiliar = _h.HistoriaFamiliar,
                                               HistoriaSocial = _h.HistoriaSocial,
                                               IdPaciente = _h.IdPaciente,

                                           }).ToList();


                    string strHistoriaFamSoc = JsonConvert.SerializeObject(qHistoriaFamSoc);


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


                    string strAntQuirurgico = JsonConvert.SerializeObject(qAntQuirurgico);



                    var qAntFamiliares = (from _d in _conexion.AntecedenteFamiliar
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdAntecedente = _d.IdAntecedente,
                                        TipoAntecedente = _d.TipoAntecedente,
                                        Descripcion = _d.Descripcion,
                                        IdPaciente = _d.IdPaciente
                                    }).ToList();

                    string strAntFamiliares = JsonConvert.SerializeObject(qAntFamiliares);


                    var qAntNeuroPsi = (from _d in _conexion.AntecedentenNeuroPsiquiatrico
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdAntNeuroPsiq = _d.IdAntNeuroPsiq,
                                        Nombre = _d.Nombre,
                                        Vive = _d.Vive,
                                        Enfermedad = _d.Enfermedad,
                                        Padece = _d.Padece,
                                        Parentesco = _d.Parentesco,
                                        IdPaciente = _d.IdPaciente
                                    }).ToList();


                    string strAntNeuroPsi = JsonConvert.SerializeObject(qAntNeuroPsi);




                    var qExamenFisicoSistema = (from _d in _conexion.ExamenFisicoSistema
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdExFisicoSistema = _d.IdExFisicoSistema,
                                        IdElemento = _d.IdElemento,
                                        Observaciones = _d.Observaciones,
                                        Activo = _d.Activo,
                                        IdPaciente = _d.IdPaciente
                                    }).ToList();

                    string strExamenFisicoSistema = JsonConvert.SerializeObject(qExamenFisicoSistema);


                    var qAnalisiPresuncion = (from _d in _conexion.AnalisisPresuncion
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdAnalisiPresuncion = _d.IdAnalisiPresuncion,
                                        Descripcion = _d.Descripcion,
                                        Fecha = _d.Fecha,
                                        IdPaciente = _d.IdPaciente
                                    }).ToList();


                    string strAnalisiPresuncion = JsonConvert.SerializeObject(qAnalisiPresuncion);


                    var qValoracionNeuro = (from _d in _conexion.ValoracionNeuroPsico
                                    where _d.IdPaciente == IdPaciente
                                    select new
                                    {
                                        IdValoracion = _d.IdValoracion,
                                        Memoria = _d.Memoria,
                                        FuncionesEjecutivas = _d.FuncionesEjecutivas,
                                        Lenguaje = _d.Lenguaje,
                                        FuncionesVisoEspaciales = _d.FuncionesVisoEspaciales,
                                        FuncionesMotoras = _d.FuncionesMotoras,
                                        Comportamiento = _d.Comportamiento,
                                        FuncionAutonomica = _d.FuncionAutonomica,
                                        IdPaciente = _d.IdPaciente,
                                    }).ToList();

                    string strValoracionNeuro = JsonConvert.SerializeObject(qValoracionNeuro);


                    var qEstiloVida = (from _e in _conexion.EstiloVida
                                       where _e.IdPaciente == IdPaciente
                                       select new
                                       {
                                           _e.IdEstiloVida,
                                           _e.Senderismo,
                                           _e.Alcoholismo,
                                           _e.Tabaquismo,
                                           _e.Cafe,
                                           _e.Ruido,
                                           _e.Horas,
                                           _e.Despertar,
                                           _e.IdPaciente
                                       }).ToList();
                   string strEstiloVIda = JsonConvert.SerializeObject(qEstiloVida);


                    var qEstiloVidaEjercicio = (from _e in _conexion.EstiloVidaEjercicio
                                                where _e.IdPaciente == IdPaciente
                                                select new
                                                {
                                                    _e.IdEjercicio,
                                                    _e.IdElemento,
                                                    _e.Frecuencia,
                                                    _e.Activo,
                                                    _e.IdPaciente
                                                }).ToList();
                    string strEstiloVidaEjercicio = JsonConvert.SerializeObject(qEstiloVidaEjercicio);


                    var qEstiloVidaAlimentacion = (from _e in _conexion.EstiloVidaAlimentacion
                                                   where _e.IdPaciente == IdPaciente
                                                   select new
                                                   {
                                                       _e.IdAlimentacion,
                                                       _e.IdElemento,
                                                       _e.Porcion,
                                                       _e.Frecuencia,
                                                       _e.IdPaciente
                                                   }).ToList();
                    string strEstiloVidaAlimentacion = JsonConvert.SerializeObject(qEstiloVidaAlimentacion);




                    Cls_DatosExpediente Datos = new Cls_DatosExpediente();
                    Datos.HistoriaFamSoc = strHistoriaFamSoc;
                    Datos.TratHisto = strTratHisto;
                    Datos.ExamenClinico = strExamenClinico;
                    Datos.AntPatologico = strAntPatologico;
                    Datos.AntQuirurgico = strAntQuirurgico;
                    Datos.AntFamiliares = strAntFamiliares;
                    Datos.AntNeuroPsi = strAntNeuroPsi;
                    Datos.ExamenFisicoSistema = strExamenFisicoSistema;
                    Datos.AnalisiPresuncion = strAnalisiPresuncion;
                    Datos.ValoracionNeuro = strAnalisiPresuncion;
                    Datos.EstiloVida = strEstiloVIda;
                    Datos.EstiloVidaAlimentacion = strEstiloVidaAlimentacion;
                    Datos.EstiloVidaEjercicio = strEstiloVidaEjercicio;


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