using static System.Console;
using System;
using CoreEscuela.Entidades;

namespace CoreEscuela.Util
{
    public static class Menu
    {
        public static void MenuPrincipal()
        {
            Console.Clear();
            string Opcion1 = "1- Listado de Promedio por Asignaturas ";
            string Opcion2 = "2- Listado de Alumnos por Curso";
            string Opcion3 = "3- Listado de Evaluaciones por Curso";
            string Opcion4 = "4- Top10MejoresPromedios";
            string Opcion5 = "5- Top10MejoresPromediosPorAsignatura";
            string Opcion6 = "6- Salir del programa";

            ForegroundColor = ConsoleColor.Green;
            Printer.WriteTitle("BIENVENIDO A LA ESCUELA");
            Printer.ElegirOpciones();
            Printer.DrawLine(100);
            Printer.WriteLargo(Opcion1, ConsoleColor.Red, 50);
            Printer.WriteLargo(Opcion2, ConsoleColor.Blue, 50);
            WriteLine();
            Printer.WriteLargo(Opcion3, ConsoleColor.Yellow, 50);
            Printer.WriteLargo(Opcion4, ConsoleColor.Magenta, 50);
            WriteLine();
            Printer.WriteLargo(Opcion5, ConsoleColor.Cyan, 50);
            Printer.WriteLargo(Opcion6, ConsoleColor.White, 50);
            WriteLine();
            ForegroundColor = ConsoleColor.Green;
            Printer.DrawLine(100);
        }
        public static string MenuCursos(Escuela Escuela)
        {
            Console.Clear();
            ReporteadorEscuela.MostrarCursosEscuela(Escuela);
            Printer.WriteTitle("Escriba un ID de curso y presione enter");
            string input = Console.ReadLine();
            return input;
        }
    }
}