using System;
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
            ImpimirCursosEscuela(engine.Escuela);
            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10, "JuanK");
            diccionario.Add(23, "Lorem Ipsum");

            foreach (var keyValPair in diccionario){
                Console.WriteLine($"Key: {keyValPair.Key} Valor:{keyValPair.Value}");
            }

            Printer.WriteTitle("Acceso a Diccionario");
            diccionario[0]= "Pekerman";
            WriteLine(diccionario[0]);

            Printer.WriteTitle("Otro Diccionario");
            var dic = new Dictionary<string, string>();
            dic["Luna"] = "Cuerpo celeste que gira alrededor de la Tierra.";
            WriteLine(dic["Luna"]);
            //Puedo reemplazar el contenido de la llave Luna de un diccionario pero no puedo adicionar.
            dic["Luna"] = "Protagonista de Soy Luna.";
            WriteLine(dic["Luna"]);
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
