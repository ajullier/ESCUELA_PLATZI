using static System.Console;
using System.Collections.Generic;
using System;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void PresioneEnter()
        {
            WriteLine("Presione ENTER para continuar");
        }
        public static void ElegirOpciones()
        {
            WriteLine("Escriba alguna de las siguientes opciones y presione ENTER para continuar");
        }
        public static void DrawLine(int tam = 10)
        {
            System.Console.WriteLine("".PadLeft(tam, '='));
        }

        public static void WriteTitle(string titulo)
        {
            WriteLine();
            var tamaño = titulo.Length + 4;
            DrawLine(tamaño);
            System.Console.WriteLine($"| {titulo} |");
            DrawLine(tamaño);
        }

        public static void Beep(int hz = 2000, int tiempo = 500, int cantidad = 1)
        {
            while (cantidad-- > 0)
            {
                System.Console.Beep(hz, tiempo);
            }
        }

        public static void WriteLargo(string cadenaString, ConsoleColor color = ConsoleColor.White, int largo = 10, bool Izq = true)
        {

            ForegroundColor = color;

            switch (Izq)
            {
                case true:
                    if (largo <= 5) { Write($"{cadenaString,-5}"); }
                    else if (largo <= 10) { Write($"{cadenaString,-10}"); }
                    else if (largo <= 15) { Write($"{cadenaString,-15}"); }
                    else if (largo <= 20) { Write($"{cadenaString,-20}"); }
                    else if (largo <= 25) { Write($"{cadenaString,-25}"); }
                    else if (largo <= 30) { Write($"{cadenaString,-30}"); }
                    else if (largo <= 35) { Write($"{cadenaString,-35}"); }
                    else if (largo <= 40) { Write($"{cadenaString,-40}"); }
                    else if (largo <= 45) { Write($"{cadenaString,-45}"); }
                    else if (largo <= 50) { Write($"{cadenaString,-50}"); }
                break;
                default:
                    if (largo <= 5) { Write($"{cadenaString,5}"); }
                    else if (largo <= 10) { Write($"{cadenaString,10}"); }
                    else if (largo <= 15) { Write($"{cadenaString,15}"); }
                    else if (largo <= 20) { Write($"{cadenaString,20}"); }
                    else if (largo <= 25) { Write($"{cadenaString,25}"); }
                    else if (largo <= 30) { Write($"{cadenaString,30}"); }
                    else if (largo <= 35) { Write($"{cadenaString,35}"); }
                    else if (largo <= 40) { Write($"{cadenaString,40}"); }
                    else if (largo <= 45) { Write($"{cadenaString,45}"); }
                    else if (largo <= 50) { Write($"{cadenaString,50}"); }
                break;
            }

        }
        public static void DrawCelda(string cadenaString, ConsoleColor color, int largo = 10)
        {
            WriteLargo(cadenaString, color, largo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("|");
        }
        public static void DrawTable(string[] String, int[] Int)
        {
            int cont = 0;
            foreach (var valor in String)
            {
                cont++;
                if (cont % 2 == 0)
                {
                    Printer.DrawCelda($"{valor}", ConsoleColor.Yellow, Int[cont - 1]);
                }
                else
                {
                    Printer.DrawCelda($"{valor}", ConsoleColor.Magenta, Int[cont - 1]);
                }
            }
        }
    }
}