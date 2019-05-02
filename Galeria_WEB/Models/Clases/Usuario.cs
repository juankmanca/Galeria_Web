using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Galeria_WEB.Models.Clases
{
    public class Usuario : Persona
    {
        private string avatar;
        private string nombreUsuario;
        private List<Album> albumlist;
        private Imagen imagenref;
        private string contrasena;

        public List<Album> Albumlist
        {
            set { albumlist = value; }
            get { return albumlist; }
        }

        public Usuario(string nombreUsuario,string contrasena, string avatar, string cedula, string nombre,string correo)
            : base(cedula, nombre,correo)
        {
            this.NombreUsuario = nombreUsuario;
            this.Contrasena = contrasena;
            this.Avatar = avatar;

        }

        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Avatar { get => avatar; set => avatar = value; }
        internal Imagen Imagenref { get => imagenref; set => imagenref = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
    }
}
