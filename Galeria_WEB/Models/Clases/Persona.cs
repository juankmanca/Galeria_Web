using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Galeria_WEB.Models.Clases
{
    public class Persona
    {
        private string correo;
        private string nombre;
        private string cedula;

        public Persona(string cedula, string nombre,string correo)
        {
            this.correo = correo;
            this.Cedula = cedula;
            this.Nombre = nombre;
        }


        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}
