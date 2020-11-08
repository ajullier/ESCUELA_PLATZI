﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            //Printer.Beep(10000, cantidad: 10);
            //ImpimirCursosEscuela(engine.Escuela);
            int dummy = 0;
            var listaObjetos = engine.GetObjetosEscuela(
                out int conteoEvaluaciones,
                out int conteoCursos,
                out int conteoAsignaturas,
                out int conteoAlumnos
            );
            //engine.Escuela.LimpiarLugar();

            /*            var listaIlugar = from obj in listaObjetos
                        where obj is Alumno
                        select (Alumno) obj;

                        int contador = 0;
                        foreach (var alumno in listaIlugar){
                            contador ++;
                            Printer.WriteTitle($"{contador}-{alumno.Nombre}");   
                        }*/
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
