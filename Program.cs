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
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;

           var engine = new EscuelaEngine();
            engine.Inicializar();
            Menu.MenuPrincipal();
            Consola.MenuPrincipal(engine.Escuela);
            Console.WriteLine("Si desea volver al menú principal coloque la letra M y presione ENTER");
            string repetir = Console.ReadLine();
            while (repetir == "m" || repetir == "M")
            {
                Menu.MenuPrincipal();
                Consola.MenuPrincipal(engine.Escuela);
                Console.WriteLine("Si desea volver al menú principal coloque la letra M y presione ENTER");
                repetir = Console.ReadLine();
            }
        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIENDO");
            //Printer.Beep(500, 1000, 3);
            Printer.WriteTitle("SALIÓ");
        }
    }
}
