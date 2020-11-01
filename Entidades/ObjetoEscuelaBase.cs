using System;

namespace CoreEscuela.Entidades
{
    //Creo una clase abstracta. Como toda idea, no se puede crear una instancia(objeto) de una idea(de la clase ObjetoEscuelaBase).
    public abstract class ObjetoEscuelaBase
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        public ObjetoEscuelaBase()
        {
            UniqueId = Guid.NewGuid().ToString();
        }//End of constructor ObjetoEscuelaBase

    }//End of class ObjetoEscuelaBase

}//End of namespace CoreEscuela.Entidades