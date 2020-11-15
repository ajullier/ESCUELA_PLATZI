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
            return GetListaAsignaturas(out var dummy);
        }

        public IEnumerable<String> GetListaAsignaturas(out IEnumerable<Evaluación> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();
            //POR CADA EVALUACIÓN EN LA LISTA DE EVALUACIONES SELECCIONEME LA ASIGNATURA
            return (from Evaluación ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluación>> GetListaEvaluaXAsig()
        {
            var dictaRta = new Dictionary<string, IEnumerable<Evaluación>>();
            var listaAsig = GetListaAsignaturas(out var listaEval);

            foreach (var asig in listaAsig)
            {
                var evalsAsig = from eval in listaEval
                                where eval.Asignatura.Nombre == asig
                                select eval;
                dictaRta.Add(asig, evalsAsig);
            }

            return dictaRta;

        }//fin del método GetListaEvaluaXAsig

        public Dictionary<string, IEnumerable<Object>> GetPromedioPorAlumnoAsignatura()
        {
            var rta = new Dictionary<string, IEnumerable<object>>();
            var dicEvalXAsig = GetListaEvaluaXAsig();
            foreach (var asigConEval in dicEvalXAsig)
            {
                var promsAlumn = from eval in asigConEval.Value
                                 group eval by new
                                 {
                                     eval.Alumno.UniqueId,
                                     eval.Alumno.Nombre
                                 }
                            into grupoEvalsAlumno
                                 select new AlumnoPromedio
                                 {
                                     alumnoId = grupoEvalsAlumno.Key.UniqueId,
                                     alumnoNombre = grupoEvalsAlumno.Key.Nombre,
                                     promedio = grupoEvalsAlumno.Average(evaluacion => evaluacion.Nota)
                                 };
                rta.Add(asigConEval.Key, promsAlumn);
            }

            return rta;
        }

        public Dictionary<string, IEnumerable<object>> GetTopXPromedios(int X){
            var rta = new Dictionary<string, IEnumerable<object>>();
            var listaAlumnoPromAsig = GetPromedioPorAlumnoAsignatura();

            foreach(var asig in listaAlumnoPromAsig){
                var listaTopX = (from prom in asig.Value
                                 orderby ((AlumnoPromedio)prom).promedio descending
                                 select prom).Take(X);
                rta.Add( asig.Key ,listaTopX);
            }
            
            return rta;
        }

    }//fin de la clase reporteador
}//fin del espacio nombre Core Escuela