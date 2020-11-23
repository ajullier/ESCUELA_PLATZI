using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela
{
    public static class Consola
    {
        public static void MenuPrincipal(Escuela Escuela)
        {
            int input = CapturarExcepciónMenuPrincipal();
            Console.Clear();
            switch (input)
            {
                case 1:
                    int iInput1 = CapturarExcepciónListaCursos(Escuela);
                    Console.Clear();
                    ReporteadorCurso.MostrarPromedioAlumnosAsignatura(Escuela.Cursos[iInput1 - 1]);
                    break;
                case 2:
                    int iInput2 = CapturarExcepciónListaCursos(Escuela);
                    Console.Clear();
                    ReporteadorCurso.MostrarAlumnos(Escuela.Cursos[iInput2 - 1]);
                    break;
                case 3:
                    int iInput3 = CapturarExcepciónListaCursos(Escuela);
                    Console.Clear();
                    ReporteadorCurso.MostrarEvaluacionesCurso(Escuela.Cursos[iInput3 - 1]);
                    break;
                case 4:
                    ReporteadorEscuela.TopMejoresPromedios(Escuela);
                    break;
                case 5:
                    ReporteadorEscuela.TopMejoresPromediosAsignatura(Escuela);
                    break;
                default:
                    break;
            }
        }

        private static int CapturarExcepciónListaCursos(Escuela Escuela)
        {
            int iInput = 1;
            try
            {
                iInput = Int32.Parse(Menu.MenuCursos(Escuela));
                if (iInput <= 0 || iInput > Escuela.Cursos.Count())
                {
                    Console.WriteLine();
                    Printer.WriteTitle("Valor erróneo. Ingrese un entero ID de acuerdo a la lista de cursos");
                    iInput = CapturarExcepciónListaCursos(Escuela);
                }
            }
            catch
            {
                Printer.WriteTitle("Valor erróneo. Ingrese un entero ID de acuerdo a la lista de cursos");
                Console.WriteLine();
                iInput = CapturarExcepciónListaCursos(Escuela);
            }
            return iInput;
        }

        private static int CapturarExcepciónMenuPrincipal()
        {
            int iInput = 1;
            try
            {
                iInput = Int32.Parse(Console.ReadLine());
                if (iInput <= 0 || iInput > 6)
                {
                    Console.WriteLine();
                    Printer.WriteTitle("Valor erróneo. Ingrese un entero ID de acuerdo a la lista de opciones");
                    iInput = CapturarExcepciónMenuPrincipal();
                }
            }
            catch
            {
                Printer.WriteTitle("Valor erróneo. Ingrese un entero ID de acuerdo a la lista de opciones");
                Console.WriteLine();
                iInput = CapturarExcepciónMenuPrincipal();
            }
            return iInput;
        }
    }
}