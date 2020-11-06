using System;

namespace CoreEscuela.Entidades
{
    public class Evaluación : ObjetoEscuelaBase
    {
        #region Propiedades
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
        public float Nota { get; set; }
        #endregion
        #region Sobrecarga de métodos
        public override string ToString()
        {
            return $"{Nota}, {Alumno}, {Asignatura}";
        }
        #endregion 
    }
}