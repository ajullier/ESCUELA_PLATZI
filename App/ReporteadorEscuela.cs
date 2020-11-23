using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela
{
    public static class ReporteadorEscuela
    {
        public static void MostrarCursosEscuela(Escuela escuela)
        {
            string[] listaString1 = {
                            "ID",
                            "Curso",
                            "Jornada",
                            "Asignaturas",
                            "Alumnos",
                            "Promedio"
                            };

            int[] listaInt = { 5, 5, 10, 15, 10, 15 };

            Printer.DrawTable(listaString1, listaInt);
            Console.WriteLine("");
            Printer.DrawLine(listaInt.Sum() + 5);

            int contador = 0;
            foreach (Curso curso in escuela.Cursos)
            {
                float nota = 0;
                float cantidad = 0;
                foreach (Alumno alumno in curso.Alumnos)
                {
                    foreach (Evaluación evaluación in alumno.Evaluaciones)
                    {
                        nota += evaluación.Nota;
                        cantidad++;
                    }
                }
                contador++;
                string[] listaString2 = {
                            $"{contador}",
                            $"{curso.Nombre}",
                            $"{curso.Jornada}",
                            $"{curso.Asignaturas.Count()}",
                            $"{curso.Alumnos.Count()}",
                            $"{nota/cantidad}",
                            };

                Printer.DrawTable(listaString2, listaInt);
                Console.WriteLine("");

            }
            Printer.DrawLine(listaInt.Sum() + 5);
        }
        public static List<ListaPlana> GetListaPlana(Escuela escuela)
        {
            var Lista = new List<ListaPlana>();
            foreach (Curso curso in escuela.Cursos)
            {
                foreach (Alumno alumno in curso.Alumnos)
                {
                    foreach (Evaluación evaluación in alumno.Evaluaciones)
                    {
                        ListaPlana contenido = new ListaPlana();
                        contenido.EvaluaciónNombre = evaluación.Nombre;
                        contenido.EvaluaciónNota = evaluación.Nota;
                        contenido.Curso = curso.Nombre;
                        contenido.Alumno = alumno.Nombre;
                        contenido.Asignatura = evaluación.Asignatura.Nombre;
                        contenido.Jornada = curso.Jornada;
                        Lista.Add(contenido);
                    }
                }
            }
            return Lista;
        }
        public static void TopMejoresPromedios(Escuela escuela, int cantidad = 10)
        {
            var Lista = GetListaPlana(escuela);

            var promsAlumn = (from eval in Lista
                              group eval by new
                              {
                                  eval.Alumno,
                                  eval.Curso,
                                  eval.Jornada
                              }
                            into grupoEvalsAlumno
                              select new
                              {
                                  alumnoNombre = grupoEvalsAlumno.Key.Alumno,
                                  curso = grupoEvalsAlumno.Key.Curso,
                                  jornada = grupoEvalsAlumno.Key.Jornada,
                                  promedio = grupoEvalsAlumno.Average(evaluacion => evaluacion.EvaluaciónNota)
                              }).OrderByDescending(ev => ev.promedio).Take(cantidad);

            string[] listaString1 = {
                            "ID",
                            "Curso",
                            "Jornada",
                            "Alumno",
                            "Promedio"
                            };

            int[] listaInt = { 5, 5, 10, 30, 10 };

            Printer.DrawTable(listaString1, listaInt);
            Console.WriteLine("");
            Printer.DrawLine(listaInt.Sum() + 5);

            int contador = 1;

            foreach (var promedio in promsAlumn)
            {

                string[] listaString2 = {
                            $"{contador}",
                            $"{promedio.curso}",
                            $"{promedio.jornada}",
                            $"{promedio.alumnoNombre}",
                            $"{promedio.promedio}",
                            };

                Printer.DrawTable(listaString2, listaInt);
                Console.WriteLine("");
                contador++;
            }
        }
        public static void TopMejoresPromediosAsignatura(Escuela escuela, int cantidad = 10)
        {
            var Lista = GetListaPlana(escuela);

            var promsAlumn = (from eval in Lista
                              group eval by new
                              {
                                  eval.Alumno,
                                  eval.Curso,
                                  eval.Jornada,
                                  eval.Asignatura
                              }
                            into grupoEvalsAlumno
                              select new
                              {
                                  alumnoNombre = grupoEvalsAlumno.Key.Alumno,
                                  curso = grupoEvalsAlumno.Key.Curso,
                                  jornada = grupoEvalsAlumno.Key.Jornada,
                                  asignatura = grupoEvalsAlumno.Key.Asignatura,
                                  promedio = grupoEvalsAlumno.Average(evaluacion => evaluacion.EvaluaciónNota)
                              }).OrderByDescending(ev => ev.promedio);

            var ListaAsignatura = (from asignatura in promsAlumn
                                   select asignatura.asignatura).Distinct();

            foreach (string asignatura in ListaAsignatura)
            {
                var promedio = (from eval in promsAlumn
                               where eval.asignatura == asignatura
                               select eval).Take(cantidad);

                string[] listaString1 = {
                                        "ID",
                                        "Curso",
                                        "Jornada",
                                        "Asignatura",
                                        "Alumno",
                                        "Promedio"
                                        };

                int[] listaInt = { 5, 5, 10, 20, 30, 10 };
                Printer.DrawLine(listaInt.Sum() + 5);
                Printer.DrawTable(listaString1, listaInt);
                Console.WriteLine("");
                Printer.DrawLine(listaInt.Sum() + 5);

                int contador = 1;

                foreach (var prom in promedio)
                {

                    string[] listaString2 = {
                                        $"{contador}",
                                        $"{prom.curso}",
                                        $"{prom.jornada}",
                                        $"{prom.asignatura}",
                                        $"{prom.alumnoNombre}",
                                        $"{prom.promedio}",
                                        };

                    Printer.DrawTable(listaString2, listaInt);
                    Console.WriteLine("");
                    contador++;
                }
            }

        }
    }
}