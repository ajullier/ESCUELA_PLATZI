using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela
{
    //con sealed(selladas) indico que otros objetos pueden hacer instancias de EscuelaEngine pero no pueden heredar de esta.
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObsEsc)
        {
            if (dicObsEsc == null)
                throw new ArgumentNullException(nameof(dicObsEsc));

            _diccionario = dicObsEsc;
        }

        public IEnumerable<Evaluación> GetListaEvaluaciones()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluaciones,
                                                 out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluación>();
            }
            {
                return new List<Evaluación>();
            }
        }

        public IEnumerable<String> GetListaAsignaturas()
        {
            var listaEvaluaciones = GetListaEvaluaciones();
            //POR CADA EVALUACIÓN EN LA LISTA DE EVALUACIONES SELECCIONEME LA ASIGNATURA
            return (from Evaluación ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluación>> GetListaEvaluaXAsig()
        {
            var dictarta = new Dictionary<string, IEnumerable<Evaluación>>();

            return dictarta;

        }
    }
}