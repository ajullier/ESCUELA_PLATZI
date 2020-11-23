using System.Collections.Generic;
using CoreEscuela.Util;
using System;

namespace CoreEscuela.Entidades
{
    public class ListaPlana
    {
        #region Propiedades
        public string Curso { get; set; }
        public string Asignatura { get; set; }
        public string Alumno { get; set; }
        public string EvaluaciónNombre { get; set; }
        public float EvaluaciónNota { get; set; }
        public TiposJornada Jornada { get; set; }
        #endregion
    }
}