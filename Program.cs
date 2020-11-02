using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            //Printer.Beep(10000, cantidad:10);
            ImpimirCursosEscuela(engine.Escuela);
            //var obj = ObjetoEscuelaBase();
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.WriteTitle("Pruebas de Polimorfismo");
            var alumnoTest = new Alumno{Nombre="Chandler Bing"};
            ObjetoEscuelaBase ob = alumnoTest;
            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");
            Printer.WriteTitle("ObjetoEscuela");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.UniqueId}");
            WriteLine($"Alumno: {ob.GetType()}");

            var objDummy = new ObjetoEscuelaBase (){Nombre = "Frank Underwood"};
            Printer.WriteTitle("objDummy");
            WriteLine($"Alumno: {objDummy.Nombre}");
            WriteLine($"Alumno: {objDummy.UniqueId}");
            WriteLine($"Alumno: {objDummy.GetType()}");

            var evaluación = new Evaluación() {
              Nombre = "Evalución de matemáticas",
              Nota = 4.5f
            };

            Printer.WriteTitle("Evaluación");
            WriteLine($"evaluación: {evaluación.Nombre}");
            WriteLine($"evaluación: {evaluación.UniqueId}");
            WriteLine($"evaluación: {evaluación.Nota}");
            WriteLine($"evaluación: {evaluación.GetType()}");

            ob = evaluación;
            Printer.WriteTitle("ObjetoEscuela");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.UniqueId}");
            WriteLine($"Alumno: {ob.GetType()}");

        }

        private static void ImpimirCursosEscuela(Escuela escuela)
        {
            
            Printer.WriteTitle("Cursos de la Escuela");
            
            
            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre  }, Id  {curso.UniqueId}");
                }
            }
        }
    }
}
