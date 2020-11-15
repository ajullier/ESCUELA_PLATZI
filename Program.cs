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
            //AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            //AppDomain.CurrentDomain.ProcessExit += (sender, e)=> Printer.Beep(185, 1000, 1);

            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evalList = reporteador.GetListaEvaluaciones();
            var listaAsg = reporteador.GetListaAsignaturas();
            var listaAsigxEval = reporteador.GetListaEvaluaXAsig();
            var listaAlumnoPromAsig = reporteador.GetPromedioPorAlumnoAsignatura();
            var listaTopXPromAsig = reporteador.GetTopXPromedios(5);

            Printer.WriteTitle("Captura de una Evalución por Consola");
            var newEval = new Evaluación();
            string nombre, notaString;
            float nota;
            
            WriteLine("Ingrese el nombre de la evaluación");
            Printer.PresioneEnter();
            nombre = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(nombre)){
                throw new ArgumentException("El valor del nombre no puede ser vacío");
            }
            else 
            {   
                //Asigna el nombre de la evaluación en minúsculas
                newEval.Nombre = nombre.ToLower();
                WriteLine("El nombre de la evaluación ha sido ingresado correctamente");
            }
            WriteLine("Ingrese la nota de la evaluación");
            Printer.PresioneEnter();
            notaString = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(notaString)){
                Printer.WriteTitle("El valor de la nota no puede ser vacío");
                WriteLine("Saliendo del programa");
            }
            else 
            {   
                //Convierto la nota de string a flotante
                try{
                    newEval.Nota = float.Parse(notaString);
                    if(newEval.Nota<0 || newEval.Nota>5){
                        throw new ArgumentOutOfRangeException();
                    }
                    WriteLine("La nota de la evaluación ha sido ingresada correctamente");
                }
                catch(ArgumentOutOfRangeException){
                    Printer.WriteTitle("El valor de la nota está fuera de rango. Debe estar entre 0 y 5");
                    WriteLine("Saliendo del programa");
                }

                catch(Exception){
                    Printer.WriteTitle("El valor de la nota no es un número válido");
                    WriteLine("Saliendo del programa");
                }
                //Se ejecuta la siguiente instrucción antes de que se termine el programa. De manera que si hay una excepción no controlada, la ejecuta.
                finally{
                    Printer.WriteTitle("FINALLY");
                    Printer.Beep(2500, 500, 3);
                }
                
            }

        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIENDO");
            Printer.Beep(500, 1000, 3);
            Printer.WriteTitle("SALIÓ");
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
