using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase, ILugar
    {
        #region Propiedades
        public int AñoDeCreación { get; set; }

        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Dirección { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }

        #endregion
        #region Constructores
        public Escuela(string nombre, int año) => (Nombre, AñoDeCreación) = (nombre, año);

        public Escuela(string nombre, int año,
                       TiposEscuela tipo,
                       string pais = "", string ciudad = "") : base()
        {
            (Nombre, AñoDeCreación) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        }
        #endregion
        #region Sobrecarga de métodos
        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
        }
        #endregion
        #region Métodos de Interface
        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando escuela...");
            Printer.Beep(1500, cantidad: 3);

            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            Printer.WriteTitle($"Escuela {Nombre} está limpia");
            Printer.Beep(500, cantidad: 2);
        }
    }
    #endregion
}
