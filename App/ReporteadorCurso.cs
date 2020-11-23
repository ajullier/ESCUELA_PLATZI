using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela
{
    public static class ReporteadorCurso
    {
        public static void MostrarEvaluacionesCurso(Curso curso)
        {
            Console.Clear();
            string[] listaString1 = {
                            "ID",
                            "Curso",
                            "Alumno",
                            "Evaluación",
                            "Nota"
                            };

            int[] listaInt = { 10, 10, 40, 40, 10 };

            var listaAlumnos = (from al in curso.Alumnos
                                select al).OrderBy(al => al.Nombre);

            int contador = 0;
            foreach (Alumno alumno in listaAlumnos)
            {
                Printer.DrawLine(listaInt.Sum() + 5);
                Printer.DrawTable(listaString1, listaInt);
                Console.WriteLine("");
                Printer.DrawLine(listaInt.Sum() + 5);

                foreach (Evaluación evaluación in alumno.Evaluaciones)
                {
                    contador++;
                    string[] listaString2 = {
                            $"{contador}",
                            $"{curso.Nombre}",
                            $"{alumno.Nombre}",
                            $"{evaluación.Nombre}",
                            $"{evaluación.Nota}"
                            };

                    Printer.DrawTable(listaString2, listaInt);
                    Console.WriteLine("");
                }
            }
            Printer.DrawLine(listaInt.Sum() + 5);
        }
        public static void MostrarAlumnos(Curso curso)
        {
            Console.Clear();
            string[] listaString1 = {
                            "ID",
                            "Curso",
                            "Alumno",
                            "Prmedio"
                            };

            int[] listaInt = { 10, 10, 40, 40 };

            Printer.DrawTable(listaString1, listaInt);
            Console.WriteLine("");
            Printer.DrawLine(listaInt.Sum() + 4);

            int contador = 0;

            var listaAlumnos = (from al in curso.Alumnos
                                select al).OrderBy(al => al.Nombre);

            foreach (Alumno alumno in listaAlumnos)
            {
                contador++;
                string[] listaString2 = {
                            $"{contador}",
                            $"{curso.Nombre}",
                            $"{alumno.Nombre}",
                            $"{alumno.Evaluaciones.Average(ev => ev.Nota)}",
                            };

                Printer.DrawTable(listaString2, listaInt);
                Console.WriteLine("");
            }
            Printer.DrawLine(listaInt.Sum() + 4);
        }
        public static void MostrarPromedioAlumnosAsignatura(Curso curso)
        {
            Console.Clear();
            string[] listaString1 = {
                            "ID",
                            "Curso",
                            "Alumno",
                            "Asignatura",
                            "Promedio"
                            };

            int[] listaInt = { 5, 5, 40, 40, 10 };

            var listaAlumnos = (from al in curso.Alumnos
                                select al).OrderBy(al => al.Nombre);

            int contador = 0;

            foreach (Alumno alumno in listaAlumnos)
            {
                Printer.DrawLine(listaInt.Sum() + 5);
                Printer.DrawTable(listaString1, listaInt);
                Console.WriteLine("");
                Printer.DrawLine(listaInt.Sum() + 5);
                var alumAsig = from eval in alumno.Evaluaciones
                               group eval by eval.Asignatura.Nombre
                                    into grupoAsig
                               select grupoAsig;

                foreach (var grupo in alumAsig)
                {
                    contador++;
                    string[] listaString2 = {
                            $"{contador}",
                            $"{curso.Nombre}",
                            $"{alumno.Nombre}",
                            $"{grupo.Key}",
                            $"{grupo.Average(ev => ev.Nota)}",
                            };

                    Printer.DrawTable(listaString2, listaInt);
                    Console.WriteLine("");
                }
            }
            Printer.DrawLine(listaInt.Sum() + 5);
        }
    }
}